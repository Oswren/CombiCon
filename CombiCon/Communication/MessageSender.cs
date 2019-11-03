using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CombiCon.Communication
{
    class MessageSender
    {
        private const String _accountId = "***REMOVED***";
        private const String _authToken = "***REMOVED***";

        public MessageSender()
        {
            TwilioClient.Init(_accountId, _authToken);   
        }

        public void SendMessageToAll(string messageBody)
        {
            SendTobyTextMessage(messageBody);
            SendConorTextMessage(messageBody);
            SendJoeTextMessage(messageBody);
            //SendNicoleTextMessage(messageBody);
        }

        public void SendTobyTextMessage(string messageBody)
        {
            SendTextMessage("***REMOVED***", messageBody);
        }
        
        public void SendJoeTextMessage(string messageBody)
        {
            SendTextMessage("***REMOVED***", messageBody);
        }

        //public void SendNicoleTextMessage(string messageBody)
        //{
        //    SendTextMessage("***REMOVED***", messageBody);
        //}

        public void SendConorTextMessage(string messageBody)
        {
            SendTextMessage("***REMOVED***", messageBody);
        }

        private string SendTextMessage(string targetNumber, string messageBody)
        {
            var message = MessageResource.Create(
                body: "- \n \n" + messageBody,
                from: new Twilio.Types.PhoneNumber("***REMOVED***"),
                to: new Twilio.Types.PhoneNumber(targetNumber));

            Console.WriteLine(message.Sid);
            return "Message sent successfully!";
        }
    }
}
