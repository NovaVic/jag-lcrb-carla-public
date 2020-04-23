﻿using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using Xunit.Gherkin.Quick;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.IO;
using Xunit;

/*
Feature: CRSApplication_society
    As a logged in business user
    I want to submit a CRS Application for a society

Scenario: Start Application
    Given I am logged in to the dashboard as a society
    And the account is deleted
    And I am logged in to the dashboard as a society
    And I click on the Start Application button
    And I complete the eligibility disclosure
    And I review the account profile
    And I review the organization structure
    And I complete the application
    And I review the security screening requirements
    And I click on the Pay for Application button
    And I enter the payment information
    And I return to the dashboard
    And the account is deleted
    Then I see the login page
*/

namespace bdd_tests
{
    [FeatureFile("./CRSApplication_society.feature")]
    public sealed class CRSApplicationSociety : TestBase
    {
        public void CheckFeatureFlagsCannabis()
        {
            string feature_flags = configuration["featureFlags"];

            // navigate to the feature flags page
            driver.Navigate().GoToUrl($"{baseUri}{feature_flags}");

            // confirm that the LiquorOne flag is enabled during this test
            Assert.True(driver.FindElement(By.XPath("//body[contains(.,'CRS-Renewal')]")).Displayed);
        }

        [Given(@"I am logged in to the dashboard as a (.*)")]
        public void I_view_the_dashboard(string businessType)
        {
            CheckFeatureFlagsCannabis();
            
            CarlaLoginNoCheck();
        }

        [And(@"I am logged in to the dashboard as a (.*)")]
        public void And_I_view_the_dashboard(string businessType)
        {
            CarlaLogin(businessType);
        }

        [And(@"I click on the Start Application button")]
        public void I_start_application()
        {
            /* 
            Page Title: Welcome to Cannabis Licensing
            */

            NgWebElement startApp_button = ngDriver.FindElement(By.XPath("//button[text()='START APPLICATION']"));
            startApp_button.Click();
        }

        [And(@"I complete the eligibility disclosure")]
        public void complete_eligibility_disclosure()
        {
            CRSEligibilityDisclosure();
        }

        [And(@"I review the account profile")]
        public void review_account_profile()
        {
            /* 
            Page Title: Please Review the Account Profile
            */

            // create the account data
            string bizNumber = "012345678";
            string societyIncorpNum = "BC1234567";
            string streetAddress1 = "645 Tyee Road";
            string streetAddress2 = "Point Ellis";

            string city = "Victoria";
            string postalCode = "V8V4Y3";
            string bizPhoneNumber = "2501811818";
            string bizEmail = "test@automation.com";
            string societyContactGiven = "SocietyGiven";
            string societyContactSurname = "SocietySurname";
            string societyContactTitle = "Director";
            string societyContactPhone = "7781811818";
            string societyContactEmail = "automated@test.com";

            string mailStreet1 = "P.O. Box 123";
            string mailStreet2 = "303 Prideaux St.";
            string mailCity = "Nanaimo";
            string mailProvince = "B.C.";
            string mailPostalCode = "V9R2N3";
            string mailCountry = "Switzerland";

            // enter the business number
            NgWebElement uiBizNumber = ngDriver.FindElement(By.XPath("(//input[@type='text'])[3]"));
            uiBizNumber.SendKeys(bizNumber);

            // enter the BC society incorporation number
            NgWebElement uiSocietyIncNumber = ngDriver.FindElement(By.Id("bcIncorporationNumber"));
            uiSocietyIncNumber.SendKeys(societyIncorpNum);

            // enter the Date of Incorporation in B.C. 
            NgWebElement uiCalendar1 = ngDriver.FindElement(By.XPath("(//input[@type='text'])[5]"));
            uiCalendar1.Click();

            NgWebElement uiCalendar2 = ngDriver.FindElement(By.XPath("//mat-calendar[@id='mat-datepicker-0']/div/mat-month-view/table/tbody/tr[1]/td[2]/div"));
            uiCalendar2.Click();

            // enter the physical street address 1
            NgWebElement uiStreetAddress1 = ngDriver.FindElement(By.XPath("(//input[@type='text'])[6]"));
            uiStreetAddress1.SendKeys(streetAddress1);

            // enter the physical street address 2
            NgWebElement uiStreetAddress2 = ngDriver.FindElement(By.XPath("(//input[@type='text'])[7]"));
            uiStreetAddress2.SendKeys(streetAddress2);

            // enter the physical city
            NgWebElement uiCity = ngDriver.FindElement(By.XPath("(//input[@type='text'])[8]"));
            uiCity.SendKeys(city);

            // enter the physical postal code
            NgWebElement uiPostalCode = ngDriver.FindElement(By.XPath("(//input[@type='text'])[10]"));
            uiPostalCode.SendKeys(postalCode);

            /* switching off use of checkbox "Same as physical address" in order to test mailing address fields
            NgWebElement uiSameAsMailingAddress = ngDriver.FindElement(By.XPath("//input[@type='checkbox']"));
            uiSameAsMailingAddress.Click(); */

            // enter the mailing street address 1
            NgWebElement uiMailingStreetAddress1 = ngDriver.FindElement(By.XPath("(//input[@type='text'])[12]"));
            uiMailingStreetAddress1.SendKeys(mailStreet1);

            // enter the mailing street address 2
            NgWebElement uiMailingStreetAddress2 = ngDriver.FindElement(By.XPath("(//input[@type='text'])[13]"));
            uiMailingStreetAddress2.SendKeys(mailStreet2);

            // enter the mailing city
            NgWebElement uiMailingCity = ngDriver.FindElement(By.XPath("(//input[@type='text'])[14]"));
            uiMailingCity.SendKeys(mailCity);

            // enter the mailing province
            NgWebElement uiMailingProvince = ngDriver.FindElement(By.XPath("(//input[@type='text'])[15]"));
            uiMailingProvince.SendKeys(mailProvince);

            // enter the mailing postal code
            NgWebElement uiMailingPostalCode = ngDriver.FindElement(By.XPath("(//input[@type='text'])[16]"));
            uiMailingPostalCode.SendKeys(mailPostalCode);

            // enter the mailing country
            NgWebElement uiMailingCountry = ngDriver.FindElement(By.XPath("(//input[@type='text'])[17]"));
            uiMailingCountry.SendKeys(mailCountry);

            // enter the business phone number
            NgWebElement uiBizPhoneNumber = ngDriver.FindElement(By.XPath("(//input[@type='text'])[18]"));
            uiBizPhoneNumber.SendKeys(bizPhoneNumber);

            // enter the business email
            NgWebElement uiBizEmail = ngDriver.FindElement(By.XPath("(//input[@type='text'])[19]"));
            uiBizEmail.SendKeys(bizEmail);

            // (re)enter the society contact first name
            NgWebElement uiSocietyContactGiven = ngDriver.FindElement(By.XPath("(//input[@type='text'])[20]"));
            uiSocietyContactGiven.SendKeys(societyContactGiven);

            // (re)enter the society contact surname
            NgWebElement uiSocietyContactSurname = ngDriver.FindElement(By.XPath("(//input[@type='text'])[21]"));
            uiSocietyContactSurname.SendKeys(societyContactSurname);

            // enter the society contact title
            NgWebElement uiSocietyContactTitle = ngDriver.FindElement(By.XPath("(//input[@type='text'])[22]"));
            uiSocietyContactTitle.SendKeys(societyContactTitle);

            // enter the society contact phone number
            NgWebElement uiSocietyContactPhone = ngDriver.FindElement(By.XPath("(//input[@type='text'])[23]"));
            uiSocietyContactPhone.SendKeys(societyContactPhone);

            // enter the society contact phone email
            NgWebElement uiSocietyContactEmail = ngDriver.FindElement(By.XPath("(//input[@type='text'])[24]"));
            uiSocietyContactEmail.SendKeys(societyContactEmail);

            // select 'No' for society's connection to a federal producer
            NgWebElement corpConnectionFederalProducer = ngDriver.FindElement(By.XPath("(//input[@type='radio'])[2]"));
            corpConnectionFederalProducer.Click();

            // click on Continue to Organization Review button
            NgWebElement continueApp_button = ngDriver.FindElement(By.Id("continueToApp"));
            continueApp_button.Click();
        }

        [And(@"I review the organization structure")]
        public void I_continue_to_organization_review()
        {
            // create society data
            string membershipFee = "2500";
            string membershipNumber = "200";

            // enter Annual Membership Fee
            NgWebElement uiMemberFee = ngDriver.FindElement(By.XPath("//input[@type='text']"));
            uiMemberFee.SendKeys(membershipFee);

            // enter Number of Members
            NgWebElement uiMemberNumber = ngDriver.FindElement(By.XPath("(//input[@type='number'])"));
            uiMemberNumber.SendKeys(membershipNumber);

            // open the director row 
            NgWebElement openKeyPersonnelForm = ngDriver.FindElement(By.XPath("//div[@id='cdk-step-content-0-1']/app-application-licensee-changes/div/section/app-org-structure/div[3]/section/app-associate-list/div/button"));
            openKeyPersonnelForm.Click();

            // create the director info
            string firstName = "Jane";
            string lastName = "Bond";
            string title = "Adventurer";
            string email = "jane@bond.com";

            // enter the director first name
            NgWebElement uiFirstName = ngDriver.FindElement(By.XPath("(//input[@type='text'])[2]"));
            uiFirstName.SendKeys(firstName);

            // enter the director last name
            NgWebElement uiLastName = ngDriver.FindElement(By.XPath("(//input[@type='text'])[3]"));
            uiLastName.SendKeys(lastName);

            // select the director position
            NgWebElement uiPosition = ngDriver.FindElement(By.XPath("//input[@type='checkbox']"));
            uiPosition.Click();

            // enter the director title
            NgWebElement uiTitle = ngDriver.FindElement(By.XPath("(//input[@type='text'])[4]"));
            uiTitle.SendKeys(title);

            // enter the director email
            NgWebElement uiEmail = ngDriver.FindElement(By.XPath("(//input[@type='text'])[5]"));
            uiEmail.SendKeys(email);

            // select the director DOB
            NgWebElement openKeyPersonnelDOB = ngDriver.FindElement(By.XPath("(//input[@type='text'])[6]"));
            openKeyPersonnelDOB.Click();

            NgWebElement openKeyPersonnelDOB1 = ngDriver.FindElement(By.XPath("//mat-calendar[@id='mat-datepicker-3']/div/mat-month-view/table/tbody/tr[2]/td[1]/div"));
            openKeyPersonnelDOB1.Click();

            // click on the Submit Organization Information button
            NgWebElement submitOrgInfoButton = ngDriver.FindElement(By.XPath("//button[contains(.,'SUBMIT ORGANIZATION INFORMATION')]"));
            submitOrgInfoButton.Click();
        }

        [And(@"I complete the application")]
        public void I_complete_the_application()
        {
            /* 
            Page Title: Submit the Cannabis Retail Store Application
            */

            // create application info
            string estName = "Point Ellis Greenhouse";
            string estAddress = "645 Tyee Rd";
            string estCity = "Victoria";
            string estPostal = "V9A6X5";
            string estPID = "012345678";
            string estEmail = "test@test.com";
            string estPhone = "2505555555";
            string conGiven = "Given";
            string conSurname = "Surname";
            string conRole = "CEO";
            string conPhone = "2508888888";
            string conEmail = "contact@email.com";

            System.Threading.Thread.Sleep(7000);

            // enter the establishment name
            NgWebElement estabName = ngDriver.FindElement(By.Id("establishmentName"));
            estabName.SendKeys(estName);

            // enter the establishment address
            NgWebElement estabAddress = ngDriver.FindElement(By.Id("establishmentAddressStreet"));
            estabAddress.SendKeys(estAddress);

            // enter the establishment city
            NgWebElement estabCity = ngDriver.FindElement(By.Id("establishmentAddressCity"));
            estabCity.SendKeys(estCity);

            // enter the establishment postal code
            NgWebElement estabPostal = ngDriver.FindElement(By.Id("establishmentAddressPostalCode"));
            estabPostal.SendKeys(estPostal);

            // enter the PID
            NgWebElement estabPID = ngDriver.FindElement(By.Id("establishmentParcelId"));
            estabPID.SendKeys(estPID);

            // enter the store email
            NgWebElement estabEmail = ngDriver.FindElement(By.Id("establishmentEmail"));
            estabEmail.SendKeys(estEmail);

            // enter the store phone number
            NgWebElement estabPhone = ngDriver.FindElement(By.Id("establishmentPhone"));
            estabPhone.SendKeys(estPhone);

            // find the upload test files in the bdd-tests\upload_files folder
            var environment = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(environment).Parent.FullName;
            string projectDirectory2 = Directory.GetParent(projectDirectory).Parent.FullName;

            // upload a store signage document
            string signagePath = Path.Combine(projectDirectory2 + Path.DirectorySeparatorChar + "bdd-tests" + Path.DirectorySeparatorChar + "upload_files" + Path.DirectorySeparatorChar + "signage.pdf");
            NgWebElement uploadSignage = ngDriver.FindElement(By.XPath("(//input[@type='file'])[2]"));
            uploadSignage.SendKeys(signagePath);

            // upload a valid interest document
            string validInterestPath = Path.Combine(projectDirectory2 + Path.DirectorySeparatorChar + "bdd-tests" + Path.DirectorySeparatorChar + "upload_files" + Path.DirectorySeparatorChar + "valid_interest.pdf");
            NgWebElement uploadValidInterest = ngDriver.FindElement(By.XPath("(//input[@type='file'])[6]"));
            uploadValidInterest.SendKeys(validInterestPath);

            // upload a floor plan document
            string floorplanPath = Path.Combine(projectDirectory2 + Path.DirectorySeparatorChar + "bdd-tests" + Path.DirectorySeparatorChar + "upload_files" + Path.DirectorySeparatorChar + "floor_plan.pdf");
            NgWebElement uploadFloorplan = ngDriver.FindElement(By.XPath("(//input[@type='file'])[8]"));
            uploadFloorplan.SendKeys(floorplanPath);

            // upload a site plan document
            string sitePlanPath = Path.Combine(projectDirectory2 + Path.DirectorySeparatorChar + "bdd-tests" + Path.DirectorySeparatorChar + "upload_files" + Path.DirectorySeparatorChar + "site_plan.pdf");
            NgWebElement uploadSitePlan = ngDriver.FindElement(By.XPath("(//input[@type='file'])[11]"));
            uploadSitePlan.SendKeys(sitePlanPath);

            // upload a financial integrity form
            string finIntegrityPath = Path.Combine(projectDirectory2 + Path.DirectorySeparatorChar + "bdd-tests" + Path.DirectorySeparatorChar + "upload_files" + Path.DirectorySeparatorChar + "fin_integrity.pdf");
            NgWebElement uploadFinIntegrity = ngDriver.FindElement(By.XPath("(//input[@type='file'])[15]"));
            uploadFinIntegrity.SendKeys(finIntegrityPath);

            // enter the first name of the application contact
            NgWebElement contactGiven = ngDriver.FindElement(By.Id("contactPersonFirstName"));
            contactGiven.SendKeys(conGiven);

            // enter the last name of the application contact
            NgWebElement contactSurname = ngDriver.FindElement(By.Id("contactPersonLastName"));
            contactSurname.SendKeys(conSurname);

            // enter the role of the application contact
            NgWebElement contactRole = ngDriver.FindElement(By.CssSelector("input[formControlName=contactPersonRole]"));
            contactRole.SendKeys(conRole);

            // enter the phone number of the application contact
            NgWebElement contactPhone = ngDriver.FindElement(By.CssSelector("input[formControlName=contactPersonPhone]"));
            contactPhone.SendKeys(conPhone);

            // enter the email of the application contact
            NgWebElement contactEmail = ngDriver.FindElement(By.Id("contactPersonEmail"));
            contactEmail.SendKeys(conEmail);

            // click on the authorized to submit checkbox
            NgWebElement authorizedSubmit = ngDriver.FindElement(By.Id("authorizedToSubmit"));
            authorizedSubmit.Click();

            // click on the signature agreement checkbox
            NgWebElement signatureAgree = ngDriver.FindElement(By.Id("signatureAgreement"));
            signatureAgree.Click();

            // click on the Submit button
            NgWebElement submit_button = ngDriver.FindElement(By.XPath("//button[contains(.,'SUBMIT')]"));
            submit_button.Click();
        }

        [And(@"I review the security screening requirements")]
        public void review_security_screening_reqs()
        {
            /* 
            Page Title: Security Screening Requirements
                      : placeholder for future testing
            */
        }

        [And(@"I click on the Pay for Application button")]
        public void click_on_pay()
        {
            NgWebElement pay_button = ngDriver.FindElement(By.XPath("//button[contains(.,'Pay for Application')]"));
            pay_button.Click();
        }

        [And(@"I enter the payment information")]
        public void enter_payment_info()
        {
            MakePayment();
        }

        [And(@"I return to the dashboard")]
        public void return_to_dashboard()
        {
            CRSReturnToDashboard();
        }

        [And(@"the account is deleted")]
        public void Delete_my_account()
        {
            this.CarlaDeleteCurrentAccount();
        }

        [Then(@"I see the login page")]
        public void I_see_login()
        {
            /* 
            Page Title: Apply for a cannabis licence
            */

            Assert.True (ngDriver.FindElement(By.XPath("//a[text()='Log In']")).Displayed);
        }
    }
}
