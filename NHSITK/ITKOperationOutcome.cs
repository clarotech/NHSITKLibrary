using System;
using System.Collections.Generic;
using ClaroTech.NHSITK.Utility;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;

namespace ClaroTech.NHSITK
{

    [Hl7.Fhir.Introspection.FhirType("OperationOutcome", IsResource = true)]
    public class ITKOperationOutcome : OperationOutcome
    {

        [NotMapped]
        public ITKOperationOutcome() : base()
        {
            Id = Guid.NewGuid().ToString();

            Issue = new List<IssueComponent>();
            Issue.Add(new IssueComponent());
            SetProfile();
            
      
        }

        private void SetProfile()
        {
            Meta = new Meta()
            {
                Profile = new string[] { ITKConstants.Profile_OperationOutcome }
            };
        }

    }
}
