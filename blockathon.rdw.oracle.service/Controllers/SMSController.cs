using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blockathon.smartcontract.interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using blockathon.shared.model;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace blockathon.rdw.oracle.service.Controllers
{
    public class SMSController : ControllerBase
    {
        public SMSController(ILogger<SMSController> logger, ISmartContract smartContract) : base(logger, smartContract)
        {
        }

        [HttpPost]
        public void SendSMS([FromBody] SMSMessage smsMessage)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "AC7bf9f478d6b7431747ac4d54ce414ad3";
            const string authToken = "fe62eff06144d96a1acf608d0181242e";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(smsMessage.phonenumber);
            var message = MessageResource.Create(to, 
                from: new PhoneNumber("+3197004499013"), 
                body: smsMessage.body);
        }
    }
}
