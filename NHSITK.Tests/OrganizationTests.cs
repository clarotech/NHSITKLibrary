using ClaroTech.NHSITK;
using Hl7.Fhir.Model;
using Xunit;

namespace NHSITK.Tests
{
    public class OrganizationTests
    {
        [Fact]
        public void BaseTest()
        {
            // Arrange
            var org = new ITKOrganization();


            // Act
            var res = org.GetResource();

            // Assert
            Assert.NotNull(res);
            Assert.Null(res.Id);
        }

        [Fact]
        public void BaseTestWithId()
        {
            // Arrange
            var org = new ITKOrganization();


            // Act
            var res = org.GetResource("abc123");

            // Assert
            Assert.NotNull(res);
            Assert.NotNull(res.Id);
            Assert.Equal("abc123", res.Id);
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
