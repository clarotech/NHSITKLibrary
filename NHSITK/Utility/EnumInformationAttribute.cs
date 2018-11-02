using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroTech.NHSITK.Utility
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumInformationAttribute : DescriptionAttribute
    {
        public EnumInformationAttribute(string description, string value)
        {
            this.Description = description;
            this.Value = value;
        }

        public override string Description { get;  }
        public string Value { get; set; }
    }
}
