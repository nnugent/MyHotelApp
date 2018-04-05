using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;

using System.Net.Mail;
using System.Net;

namespace MyHotelApp.Controllers


{
    public class SmsController: TwilioController
    {

       public void SendSms(string messageToSend, string number)
        {
            var accountSID = Keys.twilioSid;
            var authToken = Keys.twilioToken;
            TwilioClient.Init(accountSID, authToken);

            var to = new PhoneNumber(number);
            var from = new PhoneNumber("12622397119");

            var message = MessageResource.Create(
                to: to,
                from: from,
               body: messageToSend);
        }

        public void SendEmail(string message, string address)
        {
            string subject = "Reservation Confirmation";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("hotelappreservations@gmail.com", "Stephanie_1")
            };
          
           var mailMessage = new MailMessage("hotelappreservations@gmail.com", address, subject, message);
            smtp.Send(mailMessage);
              

        }
    }
}