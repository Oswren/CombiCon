using CombiCon.Accounts;
using CombiCon.Communication;
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
            while (true)
            {
                Console.WriteLine("Welcome to CombiCon login");
                Console.WriteLine();
                MenuLoop();
            }


            Account user = new Account(_helper.GenerateSequence());
            Thread.Sleep(20);
            List<Vector3> passAttempt = _helper.GenerateSequence();
            CheckIfPasswordIsCorrect(user, passAttempt);



        }

        private static void MenuLoop()
        {
            Console.WriteLine("Pick an option:");
            Console.WriteLine("1 - Login with combination");
            Console.WriteLine("2 - Login with shake");
            Console.WriteLine("3 - Create an account");
            Console.WriteLine("4 - Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ComboLoginMenu();
                    break;
                case "2":
                    ShakeLoginMenu();
                    break;
                case "3":
                    CreateAccountLoginMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    MenuLoop();
                    break;
            }
        }

        private static void ComboLoginMenu()
        {
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();
            //get user
            //get passAttempt
            //checkCombiPassword
        }

        private static void ShakeLoginMenu()
        {
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();
            //get user
            //get passAttempt
            //checkShakePassword
        }

        private static void CreateAccountLoginMenu()
        {
            Console.WriteLine("Enter a username");
            var username = Console.ReadLine();


            MakeNewPasscode();
        }




        private static void MakeNewPasscode()
        {
            _savedPass = _helper.GenerateSequence();
            Thread.Sleep(20);
            _passAttempt = _helper.GenerateSequence();
        }

        private static void CheckIfPasswordIsCorrect(Account user, List<Vector3> passAttempt)
        {
            if (user.GenerateSimilarity(passAttempt) <= 0.6)
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
