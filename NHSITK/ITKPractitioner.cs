using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace ClaroTech.NHSITK
{
    public class ITKPractitioner
    {
        private string sdsUserId;
        private List<string> sdsRoleProfileId;
        private HumanName name;
        private Identifier id;

        public ITKPractitioner()
        {
            sdsUserId = null;
            sdsRoleProfileId = new List<string>();
            name = null;

            id = new Identifier()
            { Value = Guid.NewGuid().ToString() };
        }

        public string Id
        {
            get { return id.Value; }
        }
        public void SetSDSUserID(string value)
        {
            sdsUserId = value;
        }

        public void AddSDSRoleProfileId(string value)
        {
            sdsRoleProfileId.Add(value);
        }

        public void SetName(HumanName value)
        {
            name = value;
        }

        public string GetResourceDisplay()
        {
            string display = name.Family.ToUpper();

            if (name.Given.Count() > 0)
            {
                display = $"{display}, {name.Given.First()}";
            }

            if (name.Prefix.Count() > 0)
            {
                display = $"{display} ({name.Prefix.First()})";
            }


            return display;

        }
        public Practitioner GetResource(string id = null)
        {
            Practitioner pp = new Practitioner();

            pp.Meta = new Meta();
            pp.Meta.Profile = new string[] { ITKConstants.Profile_CC_Practitioner};

            if (id != null) pp.Id = $"urn:uuid:{id}";

            if (sdsUserId != null)
            {
                pp.Identifier.Add(
                    new Identifier
                    {
                        System = ITKConstants.System_SDS_UserIde,
                        Value = sdsUserId
                    });
            };

            if (sdsRoleProfileId.Count > 0)
            {
                foreach (var item in sdsRoleProfileId)
                {
                    pp.Identifier.Add(
                    new Identifier
                    {
                        System = ITKConstants.System_SDS_RoleProfileId,
                        Value = item
                    });
                }
            }

            pp.Name.Add(name);
            return pp;
        }
    }
}
