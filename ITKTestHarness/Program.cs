using System;
using System.IO;
using ClaroTech.NHSITK;
using ClaroTech.NHSITK.ExtensionMethods;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace ITKTestHaress
{
    internal class Program
    {
        private static void Main(string[] args)
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

            var oo = new ITKOperationOutcome();

            // create the issue
            var issue1 = new OperationOutcome.IssueComponent().BusinessResponseOK();
            var issue2 = new OperationOutcome.IssueComponent().BusinessResponseNotFound();
            var issue3 = new OperationOutcome.IssueComponent().BusinessResponseMoved();

            oo.Issue.Add(issue1);
            oo.Issue.Add(issue2);
            oo.Issue.Add(issue3);

            var rawxmloo = new FhirXmlSerializer().SerializeToString(oo);
            File.WriteAllText("Test-oo.xml", rawxmloo);

        }
    }
}
