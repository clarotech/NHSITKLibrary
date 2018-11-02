using ClaroTech.NHSITK;
using Hl7.Fhir.Model;
using Xunit;

namespace NHSITK.Tests
{
    public class MessageHeaderTests
    {
        [Fact]
        public void Set_Event()
        {
            // Arrange
            var itk = new ITKMessage();
            itk.Event(ITKMessageEventCode.ITKImmunizationDocument);

            // Act
            var bundle = itk.GenerateBundle();
            var mh = bundle.Entry[0].Resource as MessageHeader;
            // Assert

            Assert.NotNull(bundle);
            Assert.NotNull(mh);
            Assert.Equal("ITK009D", mh.Event.Code);
            Assert.Equal("ITK Digital Medicine Immunization Document", mh.Event.Display);
            Assert.Equal(ITKConstants.System_Message_Event, mh.Event.System);

        }

        //[Theory]
        //[InlineData("aabbcc")]
        //[InlineData("0E8EB87E-8CD5-4B9C-B1E1-E1F0F65A5640")]
        //public void Create_NewBundleWithId(string testId)
        //{
        //    // Arrange
        //    var itk = new ITKMessage(testId);

        //    // Act
        //    var bundle = itk.GenerateBundle();

        //    // Assert
        //    Assert.NotNull(bundle);
        //    Assert.Equal(bundle.Identifier.Value, testId);

        //}
    }
}
