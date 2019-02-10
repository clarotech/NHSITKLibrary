using Hl7.Fhir.Model;

using ClaroTech.NHSITK.Utility;
using System;


namespace ClaroTech.NHSITK
{
    // [Hl7.Fhir.Introspection.FhirType("MessageHeader", IsResource = true)]

    public class ITKHandlingKeys
    {
        private bool extensionUsed;
        private bool? busAck;
        private bool? infAck;
        private ITKRecipientType? recipientType;
        private string messageDefinition;
        private string senderReference;
        private Element localExtension;

        public ITKHandlingKeys()
        {
            extensionUsed = false;
        }


        public bool BusAck
        {
            set
            {
                busAck = value;
                extensionUsed = true;
            }
        }

        public bool InfAck
        {
            set
            {
                infAck = value;
                extensionUsed = true;
            }
        }

        public ITKRecipientType RecipientType
        {
            set {
                recipientType = value;
                extensionUsed = true;
            }
        }

        public String MessageDefinition
        {
            set
            {
                messageDefinition = value;
                extensionUsed = true;
            }
        }

        public Element LocalExtension
        {
            set
            {
                localExtension = value;
                extensionUsed = true;
            }
        }

        public String SenderReference
        {
            set
            {
                senderReference = value;
                extensionUsed = true;
            }
        }

        public bool ExtensionUsed => extensionUsed;

        public Extension HandlingSpecificationExtension()
        {
            Extension ext = new Extension
            {
                Url = ITKConstants.Extension_HandlingSpecification
            };

            if (busAck != null)
            {
                ext.Extension.Add(
                    new Extension("BusAckRequested", new FhirBoolean(busAck))
                );
            }

            if (infAck != null)
            {
                ext.Extension.Add(
                    new Extension("InfAckRequested", new FhirBoolean(busAck))
                );
            }

            if (recipientType != null)
            {
                var codeInfo = recipientType.GetAttribute<EnumInformationAttribute>();

                Coding p = new Coding
                {
                    System = ITKConstants.System_ITK_RecipientType,
                    Code = codeInfo.Value,
                    Display = codeInfo.Description
                };

                ext.Extension.Add(
                    new Extension("RecipientType", p)
                );

            }

            if (messageDefinition != null)
            {
                ext.Extension.Add(
                    new Extension("MessageDefinition", new ResourceReference(messageDefinition))
                    );
            }

            if (senderReference != null)
            {
                ext.Extension.Add(
                    new Extension("SenderReference", new FhirString(senderReference))
                    );
            }

            if (localExtension != null)
            {
                ext.Extension.Add(
                    new Extension("LocalExtension", localExtension)
                    );
            }

            return ext;
        }
    }
}