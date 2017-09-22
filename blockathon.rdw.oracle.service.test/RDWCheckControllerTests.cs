using blockathon.rdw.oracle.service.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NSubstitute;
using blockathon.smartcontract.interfaces;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using Newtonsoft.Json;
using blockathon.shared.model;
using System.Collections.Generic;

namespace blockathon.rdw.oracle.service.test
{
    [TestCategory("ActualData")]
    [TestClass]
    public class RDWCheckControllerTests
    {
        [TestMethod]
        public void WhenCallingRDWToCheckKenteken1ThenResultIsOk()
        {
            async Task payload()
            {
                // Arrange
                var logger = Substitute.For<ILogger<RDWCheckController>>();
                var smartContract = Substitute.For<ISmartContract>();
                var controller = new RDWCheckController(logger, smartContract);

                // Act
                await controller.DoCheckKenteken("83STLX");

                // Assert
                smartContract.Received().Callout(Arg.Is<string>(c =>
                    JsonConvert.DeserializeObject<List<RDWAuto>>(c)[0].kenteken.Equals("83STLX")
                ));
            }
            payload().Wait();
        }

        [TestMethod]
        public void WhenCallingRDWToCheckKenteken2ThenResultIsOk()
        {
            async Task payload()
            {
                // Arrange
                var logger = Substitute.For<ILogger<RDWCheckController>>();
                var smartContract = Substitute.For<ISmartContract>();
                var controller = new RDWCheckController(logger, smartContract);

                // Act
                await controller.DoCheckKenteken("83-ST-LX");

                // Assert
                smartContract.Received().Callout(Arg.Is<string>(c =>
                    JsonConvert.DeserializeObject<List<RDWAuto>>(c)[0].kenteken.Equals("83STLX")
                ));
            }
            payload().Wait();
        }

        [TestMethod]
        public void WhenCallingRDWToCheckInvalidKentekenThenResultIsOk()
        {
            async Task payload()
            {
                // Arrange
                var logger = Substitute.For<ILogger<RDWCheckController>>();
                var smartContract = Substitute.For<ISmartContract>();
                var controller = new RDWCheckController(logger, smartContract);

                // Act
                await controller.DoCheckKenteken("000000000");

                // Assert
                smartContract.DidNotReceive().Callout(Arg.Any<string>());
            }
            payload().Wait();
        }
    }
}
