using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroTech.NHSITK
{
    public enum BusinessAckCode
    {
        [Description("Patient known here. (e.g. Patient is registered here)")]
        PatientKnownHere = 41001,

        [Description("Patient not known here. (aka ‘patient record not present in system")]
        PatientNotKnownHere = 41002,

        [Description("Patient no longer at this clinical setting")]
        PatientNoLongerKnownHere = 41022
    }
}
