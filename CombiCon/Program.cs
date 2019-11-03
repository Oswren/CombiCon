using CombiCon.Communication;
using CombiCon.Compute;
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
            datasetMaker m = new datasetMaker();
            m.makeCsvFile();
        }

        private static void MakeNewPasscode()
        {
            _savedPass = _helper.GenerateSequence();
            Thread.Sleep(20);
            _passAttempt = _helper.GenerateSequence();
        }

        private static void CheckIfPasswordIsCorrect(List<Vector3> savedPass, List<Vector3> passAttempt)
        {
            if (_helper.PasswordAttemptIsCorrect(savedPass, passAttempt))
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
