using Hl7.Fhir.Model;

using ClaroTech.NHSITK.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroTech.NHSITK
{
    public class ITKMessage
    {
        private ITKMessageEventCode? eventCode;
        private Identifier id;
        private FhirUri source;
        private ITKPractitioner receiverPractioner;
        private ITKOrganization receiverOrganization;
        private ITKPractitioner senderPractioner;
        private ITKOrganization senderOrganization;
        private Resource focus;
        private ITKHandlingKeys handlingSpecification;

        public ITKMessage()
        {
            this.id = new Identifier()
            { Value = Guid.NewGuid().ToString() };
            SetUpResource();
        }


        public ITKMessage(string id)
        {
            this.id = new Identifier()
            { Value = id };
            SetUpResource();
        }

        private void SetUpResource()
        {
            eventCode = null;
            receiverPractioner = null;
            receiverOrganization = null;
            senderPractioner = null;
            senderOrganization = null;
            focus = null;
            source = null;
            handlingSpecification = new ITKHandlingKeys();

        }

        public Bundle GenerateBundle()
        {
            Bundle itk = new Bundle();
            MessageHeader mh = GenerateMessageHeader();

            itk.Identifier = id;

            itk.Meta = new Meta()
            {
                Profile = new string[] { ITKConstants.Profile_Bundle }
            };

            itk.Type = Bundle.BundleType.Message;

            itk.Entry.Add(new Bundle.EntryComponent
            {
                FullUrl = $"urn:uuid:{mh.Id}",
                Resource = mh
            }
            );

            if (senderOrganization != null)
            {
                itk.Entry.Add(new Bundle.EntryComponent
                {
                    FullUrl = $"urn:uuid:{senderOrganization.Id}",
                    Resource = senderOrganization.GetResource()
                }
                );
            }

            if (senderPractioner != null)
            {
                itk.Entry.Add(new Bundle.EntryComponent
                {
                    FullUrl = $"urn:uuid:{senderPractioner.Id}",
                    Resource = senderPractioner.GetResource()
                }
                );
            }

            if (receiverOrganization != null)
            {
                itk.Entry.Add(new Bundle.EntryComponent
                {
                    FullUrl = $"urn:uuid:{receiverOrganization.Id}",
                    Resource = receiverOrganization.GetResource()
                }
                );
            }

            if (receiverPractioner != null)
            {
                itk.Entry.Add(new Bundle.EntryComponent
                {
                    FullUrl = $"urn:uuid:{receiverPractioner.Id}",
                    Resource = receiverPractioner.GetResource()
                }
                );
            }

            if (focus != null)
            {
                itk.Entry.Add(new Bundle.EntryComponent
                {
                    FullUrl = $"urn:uuid:{focus.Id}",
                    Resource = focus
                }
                );
            }

            return itk;
        }

        public void Event(ITKMessageEventCode eventCode)
        {
            this.eventCode = eventCode;
        }

        public Resource Focus
        {
            set { focus = value; }
        }

        #region sender methods
        public void Sender(ITKPractitioner sender)
        {
            senderPractioner = sender;
            senderOrganization = null;
        }

        public void Sender(ITKOrganization sender)
        {
            senderPractioner = null;
            senderOrganization = sender;
        }
        #endregion

        #region receiver methods
        public void Receiver(ITKPractitioner receiver)
        {
            receiverPractioner = receiver;
            receiverOrganization = null;
        }

        public void Receiver(ITKOrganization receiver)
        {
            receiverPractioner = null;
            receiverOrganization = receiver;
        }

        #endregion

        #region HandlingKeys

        public void SetBusinessAck(bool value) => handlingSpecification.BusAck = value;
        public void SetInfrastructureAck(bool value) => handlingSpecification.InfAck = value;
        public void SetRecipientType(ITKRecipientType value) => handlingSpecification.RecipientType = value;
        public void SetSenderReference(string value) => handlingSpecification.SenderReference = value;
        public void SetMessageDefinition(string value) => handlingSpecification.MessageDefinition = value;
        public void SetLocalExtension(Element value) => handlingSpecification.LocalExtension = value;

        #endregion
        public void SourceEndpoint(String src)
        {
            source = new FhirUri(src);
        }

        public MessageHeader GenerateMessageHeader()
        {
            MessageHeader mh = new MessageHeader
            {
                Id = Guid.NewGuid().ToString(),

                Meta = new Meta()
                {
                    Profile = new string[] { ITKConstants.Profile_MessageHeader }
                }
            };

            if (eventCode != null)
            {
                var codeInfo = eventCode.GetAttribute<EnumInformationAttribute>();

                mh.Event = new Coding()
                {
                    Code = codeInfo.Value,
                    Display = codeInfo.Description,
                    System = ITKConstants.System_Message_Event
                };
            }

            #region    sender
            if (senderOrganization != null)
            {
                mh.Sender = new ResourceReference()
                {
                    Reference = senderOrganization.Id
                };
            }

            if (senderPractioner != null)
            {
                mh.Sender = new ResourceReference()
                {
                    Reference = senderPractioner.Id,
                    Display = senderPractioner.GetResourceDisplay()
                };
            }
            #endregion

            #region    receiver
            if (receiverOrganization != null)
            {
                mh.Receiver = new ResourceReference()
                {
                    Reference = receiverOrganization.Id
                };
            }

            if (receiverPractioner != null)
            {
                mh.Receiver = new ResourceReference()
                {
                    Reference = receiverPractioner.Id,
                    Display = receiverPractioner.GetResourceDisplay()
                };
            }
            #endregion

            if (source != null)
            {
                mh.Source = new MessageHeader.MessageSourceComponent
                {
                    Endpoint = source.Value
                };
            }

            if (focus != null)
            {
                mh.Focus.Add(
                    new ResourceReference()
                    {
                        Reference = focus.Id
                    }
                );
            }

            if (handlingSpecification.ExtensionUsed)
            {
                mh.Extension.Add(handlingSpecification.HandlingSpecificationExtension());
            }
            return mh;
        }
    }
}