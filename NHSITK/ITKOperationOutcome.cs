using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [NotMapped]
        public void SetResponseCode(string value)
        {
            //Issue[0].Code = IssueType.
        }


    }
}
