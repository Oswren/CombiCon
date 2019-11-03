using CombiCon.Accounts;
using CombiCon.Communication;
using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace CombiCon
{
    class Program
    {
        private static PasscodeHelper _helper = new PasscodeHelper();
        private static MessageSender _messageSender;
        private static Dictionary<string, Account> _accounts = new Dictionary<string, Account>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CombiCon login");
            Console.WriteLine();
            MenuLoop();
        }

        private static void MenuLoop()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------MENU----------------------");
            Console.WriteLine("-- Pick an option:                           --");
            Console.WriteLine("-- 1 - Login with combination                --");
            Console.WriteLine("-- 2 - Login with shake -- Not Available Yet --");
            Console.WriteLine("-- 3 - Create an account                     --");
            Console.WriteLine("-- 4 - Exit                                  --");
            Console.WriteLine("---------------------MENU----------------------");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ComboLoginMenu();
                    break;
                case "2":
                    //remove when implemented
                    Console.WriteLine("Not Available Yet");
                    MenuLoop();
                    break;
                    //-------

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
            Console.WriteLine();
            Console.WriteLine("-----Log in with combination-----");
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();
            //get user
            var user = GetUser(username);

            if (user == null)
            {
                Console.WriteLine("Invalid user.");
                Console.WriteLine("Try again? (Y/N)");
                var tryAgain = Console.ReadLine();
                switch (tryAgain)
                {
                    case "y":
                        ComboLoginMenu();
                        break;
                    default:
                        MenuLoop();
                        break;
                }
            }

            //get passAttempt
            List<Vector3> passAttempt = _helper.GenerateSequence();

            //check password
            CheckIfPasswordIsCorrect(user, passAttempt);
        }

        private static void ShakeLoginMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-----Log in with shake-----");
            Console.WriteLine("Enter your username");
            var username = Console.ReadLine();
            //get user
            var user = GetUser(username);

            if (user == null)
            {
                Console.WriteLine("Invalid user.");
                Console.WriteLine("Try again? (Y/N)");
                var tryAgain = Console.ReadLine();
                switch (tryAgain)
                {
                    case "y":
                        ComboLoginMenu();
                        break;
                    default:
                        MenuLoop();
                        break;
                }
            }

            //get passAttempt
            List<Vector3> passAttempt = _helper.GenerateShakeSequence();

            //check password
            CheckIfShakePasswordIsCorrect(user, passAttempt);
        }

        private static void CreateAccountLoginMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-----Create an account-----");
            Console.WriteLine("Enter a username");
            var username = Console.ReadLine();
            if (_accounts.ContainsKey(username))
            {
                Console.WriteLine("Username already taken. Choose a different one.");
                CreateAccountLoginMenu();
            }

            List<Vector3> password = _helper.GenerateSequence();

            AddUser(username, password);

            Console.WriteLine("Account Created.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please sign in.");

            MenuLoop();
        }

        private static Account GetUser(string username)
        {
            if (_accounts.ContainsKey(username))
                return _accounts[username];
            else
                return null;
        }

        private static void AddUser(string username, List<Vector3> password)
        {
            var user = new Account(username, password);
            _accounts.Add(username, user);
        }

        private static void CheckIfPasswordIsCorrect(Account user, List<Vector3> passAttempt)
        {
            if (user.GenerateSimilarity(passAttempt) <= 0.6)
            {
                Console.WriteLine("Success! \n You have unlocked your imaginary safe.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That's not right! Try again.");
                _messageSender = new MessageSender();
                _messageSender.SendFailedLoginAttemptMessageToAll();
                MenuLoop();
            }
        }

        private static void CheckIfShakePasswordIsCorrect(Account user, List<Vector3> passAttempt)
        {
            if (true /*insert check for shake password here*/)
            {
                Console.WriteLine("Success! \n You have unlocked your imaginary safe.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That's not right! Try again.");
                _messageSender = new MessageSender();
                _messageSender.SendFailedLoginAttemptMessageToAll();
                MenuLoop();
            }
        }
    }
}
