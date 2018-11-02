using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using ClaroTech.NHSITK;
using System;
using System.IO;

namespace TestHaress
{
    class Program
    {
        static void Main(string[] args)
        {

            var itk = new ITKMessage("d12dc439-ca5c-4177-bb70-4fece88edab0");

            itk.Event(ITKMessageEventCode.ITKImmunizationDocument);

            var receiver = new ITKOrganization();
            receiver.SetODSOrgCode("ABC123");

            var senderName = new HumanName
            {
                Family = "Rastall",
                Given = new String[] { "Stephen", "David" },
                Prefix = new String[] { "Mr" }
            };

            var sender = new ITKPractitioner();
            sender.SetSDSUserID("033345750518");
            sender.AddSDSRoleProfileId("XYZ989");
            sender.SetName(senderName);

            itk.Sender(sender);



            itk.Receiver(receiver);

            itk.SourceEndpoint("1.2.826.0.1285.0.2.0.107");

            // A series of "message handling flags" 
            itk.SetBusinessAck(true);
            itk.SetInfrastructureAck(false);
            itk.SetRecipientType(ITKRecipientType.ForAction);
            itk.SetSenderReference("Test Message Ignore");
            itk.SetMessageDefinition("https://fhir.nhs.uk/STU3/MessageDefinition/ITK-EDIS-MessageDefinition-1");
            itk.SetLocalExtension(new FhirBoolean(true));

            itk.Focus = new Bundle() { Id = "test" }; // This is where the payload for the ITK message would go

            var rawxml = new FhirXmlSerializer().SerializeToString(itk.GenerateBundle());

            File.WriteAllText("Test02.xml", rawxml);
        }
    }
}
