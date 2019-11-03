using CombiCon.Accounts;
﻿using CombiCon.Communication;
using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace CombiCon
{
    class Program
    {
        private static PasscodeHelper _helper = new PasscodeHelper();
        private static List<Vector3> _savedPass;
        private static List<Vector3> _passAttempt;
        private static MessageSender _messageSender;

        static void Main(string[] args)
        {

            Account user = new Account(_helper.GenerateSequence());
            Thread.Sleep(20);
            List<Vector3> passAttempt = _helper.GenerateSequence();
            CheckIfPasswordIsCorrect(user, passAttempt);
        }

        private static void CheckIfPasswordIsCorrect(Account user, List<Vector3> passAttempt)
        {
            if (user.GenerateSimilarity(passAttempt)<= 0.6)
            {
                Console.WriteLine("Success! \n You have unlocked your imaginary safe.");
            }
            else
            {
                _messageSender = new MessageSender();
                _messageSender.SendFailedLoginAttemptMessageToAll();
            }
        }
    }
}   
