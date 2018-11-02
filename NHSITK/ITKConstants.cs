namespace ClaroTech.NHSITK
{
    public static class ITKConstants
    {
        public static string Profile_Bundle = "https://fhir.nhs.uk/STU3/StructureDefinition/ITK-Message-Bundle-1";
        public static string Profile_MessageHeader = "https://fhir.nhs.uk/STU3/StructureDefinition/ITK-MessageHeader-2";
        public static string Profile_OperationOutcome = "https://fhir.nhs.uk/STU3/StructureDefinition/ITK-Ack-OperationOutcome-1";
        public static string Profile_CC_Organization = "https://fhir.nhs.uk/STU3/StructureDefinition/CareConnect-ITK-Header-Organization-1";
        public static string Profile_CC_Practitioner = "https://fhir.nhs.uk/STU3/StructureDefinition/CareConnect-ITK-Header-Practitioner-1";

        public static string Extension_HandlingSpecification = "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-ITK-MessageHandling-2";
        //public static string Extension_DocumentCareSetting = "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-ITK-CareSettingType-1";
        public static string Extension_Practitioner_Classification = "http://hl7.org/fhir/StructureDefinition/practitioner-classification";

        public static string System_HandlingKey = "https://fhir.nhs.uk/itk-handling-key-1";
        //public static string System_SNOMEDCT = "http://snomed.info/sct";
        public static string System_SDS_JobRole = "https://fhir.hl7.org.uk/CareConnect-SDSJobRoleName-1";
        public static string System_OrgType = "http://hl7.org/fhir/organization-type";
        public static string System_SDS_UserIde = "https://fhir.nhs.uk/Id/sds-user-id";
        public static string System_SDS_RoleProfileId = "https://fhir.nhs.uk/Id/sds-role-profile-id";
       

        public static string System_ODS_OrganizationCode = "https://fhir.nhs.uk/Id/ods-organization-code";
        public static string System_ODS_SiteCode = "https://fhir.nhs.uk/Id/ods-site-code";

        //public static string Identity_System_ODS = "https://fhir.nhs.uk/Id/ods-organization-code";

        public static string System_Message_Event = "https://fhir.nhs.uk/STU3/CodeSystem/ITK-MessageEvent-2";
        public static string System_ITK_Priority = "https://fhir.nhs.uk/STU3/CodeSystem/ITK-Priority-1";
        public static string System_ITK_RecipientType = "https://fhir.nhs.uk/STU3/CodeSystem/ITK-RecipientType-1";
    }
}