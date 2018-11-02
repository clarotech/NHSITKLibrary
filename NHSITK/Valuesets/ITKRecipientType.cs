using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaroTech.NHSITK.Utility;

namespace ClaroTech.NHSITK
{
    public enum ITKRecipientType
    {
        [EnumInformation("For Action", "FA")]
        ForAction,

        [EnumInformation("For Information", "FI")]
        ForInformation
    }
}
