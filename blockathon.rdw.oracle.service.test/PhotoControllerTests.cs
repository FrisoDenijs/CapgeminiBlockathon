using blockathon.rdw.oracle.service.Controllers;
using blockathon.smartcontract.interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blockathon.rdw.oracle.service.test
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void WhenReadingImageThenKentekenIsReturned()
        {
            async Task payload()
            {
                // Arrange
                var logger = Substitute.For<ILogger<PhotoController>>();
                var smartContract = Substitute.For<ISmartContract>();
                var ctrl = new PhotoController(logger, smartContract);
                var url = "https://blockathon.blob.core.windows.net/kentekens/kenteken.jpg";

                // Act
                await ctrl.DoAnalyzePhoto(url);

                // Assert
                smartContract.Received().Callout(Arg.Is<string>(c => c == "XK50HF"));
            }
            payload().Wait();
        }
    }
}
