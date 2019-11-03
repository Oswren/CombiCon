using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CombiCon.Communication
{
    class MessageSender
    {
        private const String _accountId = "AC323ed541380f3877afc4ff2b44b78725";
        private const String _authToken = "f1872db9cbb37bb9c0458a9756924055";

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
            SendTextMessage("+447546814775", messageBody);
        }
        
        public void SendJoeTextMessage(string messageBody)
        {
            SendTextMessage("+447500300880", messageBody);
        }

        //public void SendNicoleTextMessage(string messageBody)
        //{
        //    SendTextMessage("+447768642244", messageBody);
        //}

        public void SendConorTextMessage(string messageBody)
        {
            SendTextMessage("+447894061396", messageBody);
        }

        private string SendTextMessage(string targetNumber, string messageBody)
        {
            var message = MessageResource.Create(
                body: "- \n \n" + messageBody,
                from: new Twilio.Types.PhoneNumber("+441253530838"),
                to: new Twilio.Types.PhoneNumber(targetNumber));

            Console.WriteLine(message.Sid);
            return "Message sent successfully!";
        }
    }
}
