using blockathon.rdw.oracle.service.Controllers;
using blockathon.smartcontract.interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace blockathon.rdw.oracle.service.test
{
    [TestClass]
    public class SMSControllerTests
    {
        [TestMethod]
        [Ignore]
        public void WhenSendingSMSThenSMSIsSent()
        {
            // Arrange
            var logger = Substitute.For<ILogger<SMSController>>();
            var smartContract = Substitute.For<ISmartContract>();
            var cntrl = new SMSController(logger, smartContract);

            // Act
            cntrl.SendSMS(new shared.model.SMSMessage() { body = "Hello, world", phonenumber = "+31612309890" });

            // Assert 
        }
    }
}
