using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaroTech.NHSITK.Utility;

namespace ClaroTech.NHSITK
{
    public enum ITKMessageEventCode
    {
        [EnumInformation("ITK eDischarge", "ITK003D")]
        ITKeDischarge,

        [EnumInformation("ITK Mental Health eDischarge", "ITK004D")]
        ITKMentalHealtheDischarge,

        [EnumInformation("ITK Emergency Care eDischarge", "ITK005D")]
        ITKEmergencyCareeDischarge,

        [EnumInformation("ITK Outpatient Letter", "ITK006D")]
        ITKOutpatientLetter,

        [EnumInformation("ITK GP Send Document", "ITK007C")]
        ITKGPConnectWriteback,

        [EnumInformation("ITK Response", "ITK008M")]
        ITKResponse,

        [EnumInformation("ITK Digital Medicine Immunization Document", "ITK009D")]
        ITKImmunizationDocument,


        [EnumInformation("ITK Digital Medicine Immunization Document", "ITK010D")]
        ITKEmergencySupplyDocument,
        
        [EnumInformation("ITK Events Management Service", "ITK011M")]
        ITKEventManagement
    }
}