// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Microsoft.Dynamics.CRM.adoxio_investigationactivity
    /// </summary>
    public partial class MicrosoftDynamicsCRMadoxioInvestigationactivity
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioInvestigationactivity class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioInvestigationactivity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioInvestigationactivity class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioInvestigationactivity(int? utcconversiontimezonecode = default(int?), string _adoxioInspectionidValue = default(string), string adoxioOtheractivitytype = default(string), string adoxioDescription = default(string), System.DateTimeOffset? adoxioInvestigationactivitydate = default(System.DateTimeOffset?), int? importsequencenumber = default(int?), string _adoxioContraventionidValue = default(string), int? adoxioType = default(int?), string _createdbyValue = default(string), int? statuscode = default(int?), string adoxioInvestigationactivityid = default(string), System.DateTimeOffset? adoxioDatefrom = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedon = default(System.DateTimeOffset?), string _modifiedbyValue = default(string), int? statecode = default(int?), string _adoxioInvestigationidValue = default(string), string adoxioName = default(string), string _owningbusinessunitValue = default(string), System.DateTimeOffset? overriddencreatedon = default(System.DateTimeOffset?), string _owneridValue = default(string), System.DateTimeOffset? createdon = default(System.DateTimeOffset?), string _owninguserValue = default(string), int? timezoneruleversionnumber = default(int?), string _modifiedonbehalfbyValue = default(string), string versionnumber = default(string), System.DateTimeOffset? adoxioDateto = default(System.DateTimeOffset?), string _owningteamValue = default(string), string _createdonbehalfbyValue = default(string), string _adoxioComplaintidValue = default(string), MicrosoftDynamicsCRMsystemuser createdbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser createdonbehalfbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedonbehalfbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser owninguser = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMteam owningteam = default(MicrosoftDynamicsCRMteam), MicrosoftDynamicsCRMprincipal ownerid = default(MicrosoftDynamicsCRMprincipal), MicrosoftDynamicsCRMbusinessunit owningbusinessunit = default(MicrosoftDynamicsCRMbusinessunit), IList<MicrosoftDynamicsCRMsyncerror> adoxioInvestigationactivitySyncErrors = default(IList<MicrosoftDynamicsCRMsyncerror>), IList<MicrosoftDynamicsCRMduplicaterecord> adoxioInvestigationactivityDuplicateMatchingRecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>), IList<MicrosoftDynamicsCRMduplicaterecord> adoxioInvestigationactivityDuplicateBaseRecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>), IList<MicrosoftDynamicsCRMasyncoperation> adoxioInvestigationactivityAsyncOperations = default(IList<MicrosoftDynamicsCRMasyncoperation>), IList<MicrosoftDynamicsCRMmailboxtrackingfolder> adoxioInvestigationactivityMailboxTrackingFolders = default(IList<MicrosoftDynamicsCRMmailboxtrackingfolder>), IList<MicrosoftDynamicsCRMprocesssession> adoxioInvestigationactivityProcessSession = default(IList<MicrosoftDynamicsCRMprocesssession>), IList<MicrosoftDynamicsCRMbulkdeletefailure> adoxioInvestigationactivityBulkDeleteFailures = default(IList<MicrosoftDynamicsCRMbulkdeletefailure>), IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> adoxioInvestigationactivityPrincipalObjectAttributeAccesses = default(IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess>), MicrosoftDynamicsCRMadoxioComplianceinvestigation adoxioInvestigationId = default(MicrosoftDynamicsCRMadoxioComplianceinvestigation), MicrosoftDynamicsCRMadoxioComplaint adoxioComplaintId = default(MicrosoftDynamicsCRMadoxioComplaint), MicrosoftDynamicsCRMadoxioContravention adoxioContraventionId = default(MicrosoftDynamicsCRMadoxioContravention), MicrosoftDynamicsCRMincident adoxioInspectionId = default(MicrosoftDynamicsCRMincident))
        {
            Utcconversiontimezonecode = utcconversiontimezonecode;
            this._adoxioInspectionidValue = _adoxioInspectionidValue;
            AdoxioOtheractivitytype = adoxioOtheractivitytype;
            AdoxioDescription = adoxioDescription;
            AdoxioInvestigationactivitydate = adoxioInvestigationactivitydate;
            Importsequencenumber = importsequencenumber;
            this._adoxioContraventionidValue = _adoxioContraventionidValue;
            AdoxioType = adoxioType;
            this._createdbyValue = _createdbyValue;
            Statuscode = statuscode;
            AdoxioInvestigationactivityid = adoxioInvestigationactivityid;
            AdoxioDatefrom = adoxioDatefrom;
            Modifiedon = modifiedon;
            this._modifiedbyValue = _modifiedbyValue;
            Statecode = statecode;
            this._adoxioInvestigationidValue = _adoxioInvestigationidValue;
            AdoxioName = adoxioName;
            this._owningbusinessunitValue = _owningbusinessunitValue;
            Overriddencreatedon = overriddencreatedon;
            this._owneridValue = _owneridValue;
            Createdon = createdon;
            this._owninguserValue = _owninguserValue;
            Timezoneruleversionnumber = timezoneruleversionnumber;
            this._modifiedonbehalfbyValue = _modifiedonbehalfbyValue;
            Versionnumber = versionnumber;
            AdoxioDateto = adoxioDateto;
            this._owningteamValue = _owningteamValue;
            this._createdonbehalfbyValue = _createdonbehalfbyValue;
            this._adoxioComplaintidValue = _adoxioComplaintidValue;
            Createdbyname = createdbyname;
            Createdonbehalfbyname = createdonbehalfbyname;
            Modifiedbyname = modifiedbyname;
            Modifiedonbehalfbyname = modifiedonbehalfbyname;
            Owninguser = owninguser;
            Owningteam = owningteam;
            Ownerid = ownerid;
            Owningbusinessunit = owningbusinessunit;
            AdoxioInvestigationactivitySyncErrors = adoxioInvestigationactivitySyncErrors;
            AdoxioInvestigationactivityDuplicateMatchingRecord = adoxioInvestigationactivityDuplicateMatchingRecord;
            AdoxioInvestigationactivityDuplicateBaseRecord = adoxioInvestigationactivityDuplicateBaseRecord;
            AdoxioInvestigationactivityAsyncOperations = adoxioInvestigationactivityAsyncOperations;
            AdoxioInvestigationactivityMailboxTrackingFolders = adoxioInvestigationactivityMailboxTrackingFolders;
            AdoxioInvestigationactivityProcessSession = adoxioInvestigationactivityProcessSession;
            AdoxioInvestigationactivityBulkDeleteFailures = adoxioInvestigationactivityBulkDeleteFailures;
            AdoxioInvestigationactivityPrincipalObjectAttributeAccesses = adoxioInvestigationactivityPrincipalObjectAttributeAccesses;
            AdoxioInvestigationId = adoxioInvestigationId;
            AdoxioComplaintId = adoxioComplaintId;
            AdoxioContraventionId = adoxioContraventionId;
            AdoxioInspectionId = adoxioInspectionId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utcconversiontimezonecode")]
        public int? Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_inspectionid_value")]
        public string _adoxioInspectionidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_otheractivitytype")]
        public string AdoxioOtheractivitytype { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_description")]
        public string AdoxioDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivitydate")]
        public System.DateTimeOffset? AdoxioInvestigationactivitydate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "importsequencenumber")]
        public int? Importsequencenumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_contraventionid_value")]
        public string _adoxioContraventionidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_type")]
        public int? AdoxioType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdby_value")]
        public string _createdbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statuscode")]
        public int? Statuscode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivityid")]
        public string AdoxioInvestigationactivityid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_datefrom")]
        public System.DateTimeOffset? AdoxioDatefrom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedon")]
        public System.DateTimeOffset? Modifiedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedby_value")]
        public string _modifiedbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statecode")]
        public int? Statecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_investigationid_value")]
        public string _adoxioInvestigationidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_name")]
        public string AdoxioName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningbusinessunit_value")]
        public string _owningbusinessunitValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "overriddencreatedon")]
        public System.DateTimeOffset? Overriddencreatedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_ownerid_value")]
        public string _owneridValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdon")]
        public System.DateTimeOffset? Createdon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owninguser_value")]
        public string _owninguserValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timezoneruleversionnumber")]
        public int? Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedonbehalfby_value")]
        public string _modifiedonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public string Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_dateto")]
        public System.DateTimeOffset? AdoxioDateto { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningteam_value")]
        public string _owningteamValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdonbehalfby_value")]
        public string _createdonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_complaintid_value")]
        public string _adoxioComplaintidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdbyname")]
        public MicrosoftDynamicsCRMsystemuser Createdbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdonbehalfbyname")]
        public MicrosoftDynamicsCRMsystemuser Createdonbehalfbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedbyname")]
        public MicrosoftDynamicsCRMsystemuser Modifiedbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedonbehalfbyname")]
        public MicrosoftDynamicsCRMsystemuser Modifiedonbehalfbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owninguser")]
        public MicrosoftDynamicsCRMsystemuser Owninguser { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningteam")]
        public MicrosoftDynamicsCRMteam Owningteam { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ownerid")]
        public MicrosoftDynamicsCRMprincipal Ownerid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningbusinessunit")]
        public MicrosoftDynamicsCRMbusinessunit Owningbusinessunit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_SyncErrors")]
        public IList<MicrosoftDynamicsCRMsyncerror> AdoxioInvestigationactivitySyncErrors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_DuplicateMatchingRecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> AdoxioInvestigationactivityDuplicateMatchingRecord { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_DuplicateBaseRecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> AdoxioInvestigationactivityDuplicateBaseRecord { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_AsyncOperations")]
        public IList<MicrosoftDynamicsCRMasyncoperation> AdoxioInvestigationactivityAsyncOperations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_MailboxTrackingFolders")]
        public IList<MicrosoftDynamicsCRMmailboxtrackingfolder> AdoxioInvestigationactivityMailboxTrackingFolders { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_ProcessSession")]
        public IList<MicrosoftDynamicsCRMprocesssession> AdoxioInvestigationactivityProcessSession { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_BulkDeleteFailures")]
        public IList<MicrosoftDynamicsCRMbulkdeletefailure> AdoxioInvestigationactivityBulkDeleteFailures { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_investigationactivity_PrincipalObjectAttributeAccesses")]
        public IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> AdoxioInvestigationactivityPrincipalObjectAttributeAccesses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_InvestigationId")]
        public MicrosoftDynamicsCRMadoxioComplianceinvestigation AdoxioInvestigationId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_ComplaintId")]
        public MicrosoftDynamicsCRMadoxioComplaint AdoxioComplaintId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_ContraventionId")]
        public MicrosoftDynamicsCRMadoxioContravention AdoxioContraventionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_InspectionId")]
        public MicrosoftDynamicsCRMincident AdoxioInspectionId { get; set; }

    }
}
