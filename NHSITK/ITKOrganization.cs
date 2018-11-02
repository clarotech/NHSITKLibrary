using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroTech.NHSITK
{
    public class ITKOrganization
    {
        private string odsOrganizationCode;
        private string odsSiteCode;
        private Identifier id;

        public ITKOrganization()
        {
            odsOrganizationCode = null;
            odsSiteCode = null;

            id = new Identifier()
            { Value = Guid.NewGuid().ToString() };
        }

        public string Id
        {
            get { return id.Value; }
        }

        public void SetODSOrgCode(string value)
        {
            odsOrganizationCode = value;
        }

        public void SetODSSiteCode(string value)
        {
            odsSiteCode = value;
        }

        public Organization GetResource(string id = null)
        {
            Organization org = new Organization();

            org.Meta = new Meta();
            org.Meta.Profile = new string[] { ITKConstants.Profile_CC_Organization };

            if (id != null) org.Id = id;

            if (odsSiteCode != null)
            {
                org.Identifier.Add(
                    new Identifier
                    {
                        System = ITKConstants.System_ODS_SiteCode,
                        Value = odsSiteCode
                    });
            };

            if (odsOrganizationCode != null)
            {
                org.Identifier.Add(
                    new Identifier
                    {
                        System = ITKConstants.System_ODS_OrganizationCode,
                        Value = odsOrganizationCode
                    });
            };

            return org;
        }
    }
}