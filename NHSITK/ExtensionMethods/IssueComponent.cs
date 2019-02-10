using Hl7.Fhir.Model;
using static Hl7.Fhir.Model.OperationOutcome;

namespace ClaroTech.NHSITK.ExtensionMethods
{
    public static class IssueComponentMethods
    {
        public static IssueComponent BusinessResponseOK(this IssueComponent thisIssueComponent)
        {
            thisIssueComponent.Severity = IssueSeverity.Information;
            thisIssueComponent.Code = IssueType.Informational;

            thisIssueComponent.Details = new CodeableConcept();
            thisIssueComponent.Details.Coding.Add(
                new Coding()
                {
                    System = ITKConstants.System_ITK_ResposeCode,
                    Code = "30001",
                    Display = "Patient known here. (e.g. Patient is registered here)"
                }
            );

            return thisIssueComponent;
        }

        public static IssueComponent BusinessResponseNotFound(this IssueComponent thisIssueComponent)
        {
            thisIssueComponent.Severity = IssueSeverity.Fatal;
            thisIssueComponent.Code = IssueType.NotFound;

            thisIssueComponent.Details = new CodeableConcept();
            thisIssueComponent.Details.Coding.Add(
                new Coding()
                {
                    System = ITKConstants.System_ITK_ResposeCode,
                    Code = "30002",
                    Display = "Patient not known here. (aka 'patient record not present in system')"
                }
            );

            return thisIssueComponent;
        }

        public static IssueComponent BusinessResponseMoved(this IssueComponent thisIssueComponent)
        {
            thisIssueComponent.Severity = IssueSeverity.Fatal;
            thisIssueComponent.Code = IssueType.BusinessRule;

            thisIssueComponent.Details = new CodeableConcept();
            thisIssueComponent.Details.Coding.Add(
                new Coding()
                {
                    System = ITKConstants.System_ITK_ResposeCode,
                    Code = "30003",
                    Display = "Patient no longer at this clinical setting"
                }
            );

            return thisIssueComponent;
        }

    }
}