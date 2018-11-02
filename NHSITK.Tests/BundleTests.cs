using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaroTech.NHSITK;
using Xunit;

namespace NHSITK.Tests
{
    public class BundleTests
    {
        [Fact]
        public void Create_NewBundle()
        {
            // Arrange
             var itk = new ITKMessage();

            // Act
            var bundle = itk.GenerateBundle();

            // Assert
            Assert.NotNull(bundle);
            Assert.Equal(bundle.Meta.Profile.ElementAt(0), ITKConstants.Profile_Bundle);

        }

        [Theory]
        [InlineData("aabbcc")]
        [InlineData("0E8EB87E-8CD5-4B9C-B1E1-E1F0F65A5640")]
        public void Create_NewBundleWithId(string testId)
        {
            // Arrange
            var itk = new ITKMessage(testId);

            // Act
            var bundle = itk.GenerateBundle();

            // Assert
            Assert.NotNull(bundle);
            Assert.Equal(bundle.Identifier.Value, testId);

        }
    }
}
