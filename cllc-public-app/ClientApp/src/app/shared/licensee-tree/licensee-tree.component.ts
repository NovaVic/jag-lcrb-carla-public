import { Component, OnInit, Injectable, ViewChild, OnDestroy } from '@angular/core';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTree } from '@angular/material/tree';
import { Store } from '@ngrx/store';
import { AppState } from '@app/app-state/models/app-state';
import { Account } from '@models/account.model';
import { LegalEntity } from '@models/legal-entity.model';
import { LicenseeChangeLog } from '@models/legal-entity-change.model';
import { LegalEntityDataService } from '@services/legal-entity-data.service';
import { MatDialog } from '@angular/material';
import { ShareholdersAndPartnersComponent } from './dialog-boxes/shareholders-and-partners/shareholders-and-partners.component';
import { OrganizationLeadershipComponent } from './dialog-boxes/organization-leadership/organization-leadership.component';
import { filter, takeWhile } from 'rxjs/operators';
import { Route, ActivatedRoute } from '@angular/router';
import { ApplicationDataService } from '@services/application-data.service';
import { FormBase } from '@shared/form-base';
import { Application } from '@models/application.model';
import { forkJoin } from 'rxjs';



/**
 * Food; data; with nested structure.
 * Each; node; has; a; name; and; an; optiona; list; of; children.
 */
interface FoodNode {
  name: string;
  newName?: string;
  children?: FoodNode[];
  isNew?: boolean;
  deleted?: boolean;
  edited?: boolean;
}

@Component({
  selector: 'app-licensee-tree',
  templateUrl: './licensee-tree.component.html',
  styleUrls: ['./licensee-tree.component.scss'],
})
export class LicenseeTreeComponent extends FormBase implements OnInit {
  treeControl = new NestedTreeControl<FoodNode>(node => node.children);
  dataSource = new MatTreeNestedDataSource<any>();
  @ViewChild('tree') tree: MatTree<any>;
  componentActive = true;
  account: Account;
  changeTree: LicenseeChangeLog;
  individualShareholderChanges: LicenseeChangeLog[];
  organizationShareholderChanges: LicenseeChangeLog[];
  leadershipChanges: LicenseeChangeLog[];
  treeRoot: LicenseeChangeLog;
  applicationId: string;
  application: Application;
  changeLogs: LicenseeChangeLog[];

  constructor(private store: Store<AppState>,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private applicationDataService: ApplicationDataService,
    private legalEntityDataService: LegalEntityDataService) {
    super();
    this.route.paramMap.subscribe(pmap => this.applicationId = pmap.get('applicationId'));
  }

  hasChild = (_: number, node: FoodNode) => !!node.children && node.children.length > 0;

  ngOnInit() {
    forkJoin(this.applicationDataService.getApplicationById(this.applicationId),
      this.legalEntityDataService.getChangeLogs(this.applicationId),
      this.legalEntityDataService.getCurrentHierachy())
      .pipe(takeWhile(() => this.componentActive))
      .subscribe((data: [Application, LicenseeChangeLog[], LegalEntity]) => {
        this.application = data[0];
        this.changeLogs = data[1] || [];

        // convert legal entity tree to change logs
        this.treeRoot = this.processLegalEntityTree(data[2]);
        this.treeRoot.isRoot = true;
        this.changeTree = this.treeRoot;
        this.dataSource.data = [this.treeRoot];
        this.applySavedChangeLogs();
        this.refreshTreeAndChangeTables();
      },
        () => {
          console.log('Error occured');
        }
      );
  }

  applySavedChangeLogs() {
    const changesWithLegalEntityId = this.changeLogs.filter(item => !!item.legalEntityId);
    const changesWithParentLegalEntityId = this.changeLogs.filter(item => !item.legalEntityId && !!item.parentLegalEntityId);
    const changesWithParentChangeLogId =
      this.changeLogs.filter(item => !item.legalEntityId && !item.parentLegalEntityId && !item.parentLinceseeChangeLogId);

    changesWithLegalEntityId.forEach(change => {
      const node = this.findNodeInTree(this.treeRoot, change.legalEntityId);
      if (node) {
        Object.assign(node, change);
      }
    });

    changesWithParentLegalEntityId.forEach(change => {
      const node = this.findNodeInTree(this.treeRoot, change.parentLegalEntityId);
      if (node) {
        node.children = node.children || [];
        const newNode = Object.assign(new LicenseeChangeLog(), change);
        if (newNode.firstNameNew) {
          newNode.nameNew = `${newNode.firstNameNew} ${newNode.lastNameNew}`;
        }
        node.children.push(newNode);
      }
    });

    changesWithParentChangeLogId.forEach(change => {
      const node = this.findNodeInTree(this.treeRoot, null, change.parentLinceseeChangeLogId);
      if (node) {
        node.children = node.children || [];
        const newNode = Object.assign(new LicenseeChangeLog(), change);
        node.children.push(newNode);
      }
    });
  }

  findNodeInTree(node: LicenseeChangeLog, legalEntityId: string = null, changeLogId: string = null): LicenseeChangeLog {
    let result = null;

    if (legalEntityId && node.legalEntityId === legalEntityId) {
      result = node;
    } else if (changeLogId && node.id === changeLogId) {
      result = node;
    } else {
      const children = node.children || [];
      for (const child of children) {
        const res = this.findNodeInTree(child, legalEntityId, changeLogId);
        if (res) {
          result = res;
          break;
        }
      }
    }
    return result;
  }

  editAssociate(node) {
    if (node.isShareholderNew) {
      this.openShareholderDialog(node)
        .pipe(filter(data => !!data))
        .subscribe(
          formData => {
            if (node.changeType !== 'add') {
              formData.changeType = 'edit';
            }
            node = Object.assign(node, formData);
            this.refreshTreeAndChangeTables();
          }
        );
    } else {
      this.openLeadershipDialog(node)
        .pipe(filter(data => !!data))
        .subscribe(
          formData => {
            if (node.changeType !== 'add') {
              formData.changeType = 'edit';
            }
            node = Object.assign(node, formData);
            this.refreshTreeAndChangeTables();
          }
        );
    }
  }

  addLeadership(node) {
    this.openLeadershipDialog({})
      .pipe(filter(data => !!data))
      .subscribe((formData: LicenseeChangeLog) => {
        formData.changeType = 'add';
        formData.isIndividual = true;
        // formData.parentLinceseeChangeLog = node;
        node.children = node.children || [];
        node.children.push(formData);
        this.refreshTreeAndChangeTables();
      }
      );
  }

  addShareholder(node) {
    this.openShareholderDialog({})
      .pipe(filter(data => !!data))
      .subscribe(
        formData => {
          formData.changeType = 'add';
          // formData.parentLinceseeChangeLog = node;
          node.children = node.children || [];
          node.children.push(formData);
          this.refreshTreeAndChangeTables();
        }
      );
  }

  deleteAssociate(node: LicenseeChangeLog, changeType = 'delete') {
    // if (node.changeType === 'add') {
    //   const index = node.parentLinceseeChangeLog.children.indexOf(node);
    //   node.parentLinceseeChangeLog.children.splice(index, 1);
    // } else {
    node.changeType = changeType;
    const children = node.children || [];
    children.forEach(child => {
      this.deleteAssociate(child, 'parent-deleted');
    });
    // }
    this.refreshTreeAndChangeTables();
  }

  /*
  * Perform Depth First Traversal and transform tree to change objects
  */
  processLegalEntityTree(node: LegalEntity): LicenseeChangeLog {
    const newNode = new LicenseeChangeLog(node);
    if (node.children && node.children.length) {
      newNode.children = [];
      node.children.forEach(child => {
        const childNode = this.processLegalEntityTree(child);
        // childNode.parentLinceseeChangeLog = newNode;
        newNode.children.push(childNode);
      });
    }
    return newNode;
  }

  openShareholderDialog(shareholder) {
    // set dialogConfig settings
    const dialogConfig = {
      disableClose: true,
      autoFocus: true,
      maxWidth: '400px',
      data: {
        businessType: 'PrivateCorporation',
        shareholder: shareholder
      }
    };

    // open dialog, get reference and process returned data from dialog
    const dialogRef = this.dialog.open(ShareholdersAndPartnersComponent, dialogConfig);
    return dialogRef.afterClosed();
  }

  openLeadershipDialog(leader) {
    // set dialogConfig settings
    const dialogConfig = {
      disableClose: true,
      autoFocus: true,
      width: '500px',
      data: {
        person: leader,
        businessType: 'PrivateCorporation'
      }
    };

    // open dialog, get reference and process returned data from dialog
    const dialogRef = this.dialog.open(OrganizationLeadershipComponent, dialogConfig);
    return dialogRef.afterClosed();

  }


  refreshTreeAndChangeTables() {
    const data = [...this.dataSource.data];
    this.dataSource.data = [];
    this.dataSource.data = data;
    this.refreshChangeTables();
  }

  refreshChangeTables() {
    this.individualShareholderChanges = [];
    this.organizationShareholderChanges = [];
    this.leadershipChanges = [];
    this.populateChangeTables(this.treeRoot);

    const sortByChangeType = (a: LicenseeChangeLog, b: LicenseeChangeLog) => {
      if (a.titleOld <= b.changeType) {
        return 1;
      }
      return -1;
    };

    this.individualShareholderChanges.sort(sortByChangeType);
    this.organizationShareholderChanges.sort(sortByChangeType);
    this.leadershipChanges.sort(sortByChangeType);
  }

  populateChangeTables(node: LicenseeChangeLog) {
    if (node.isShareholderNew && node.isIndividual && node.changeType !== 'unchanged') {
      this.individualShareholderChanges.push(node);
    } else if (node.isShareholderNew && node.changeType !== 'unchanged') {
      this.organizationShareholderChanges.push(node);
    } else if (!node.isShareholderNew && node.changeType !== 'unchanged') {
      this.leadershipChanges.push(node);
    }

    if (node.children && node.children.length) {
      node.children.forEach(child => {
        this.populateChangeTables(child);
      });
    }
  }

  save() {
    this.legalEntityDataService.saveLicenseeChanges(this.treeRoot, this.applicationId)
      .subscribe((data) => {
        debugger;
      });
  }

  OnDestroy() {
    this.componentActive = false;
  }
}
