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
        private static MessageSender _messageSender;
        private static Dictionary<String, Account> _accounts = new Dictionary<String, Account>();

        static void Main(string[] args)
        {
            CreateUser();
            Account user = null;
            do
            {
                Console.WriteLine("Please enter your username ");
                String username = Console.ReadLine();
                user = GetUser(username);
                if (user == null)
                {
                    Console.WriteLine("Incorrect username!");
                }
            } while (user == null);
            Thread.Sleep(20);
            List<Vector3> passAttempt = _helper.GenerateSequence();
            CheckIfPasswordIsCorrect(user, passAttempt);
        }

        static void CreateUser()
        {
            Console.WriteLine("Please enter a username ");
            String username = Console.ReadLine();
            Account user = new Account(username, _helper.GenerateSequence());
            _accounts.Add(username, user);
            Console.WriteLine("User Created!");
        }

        static Account GetUser(String username)
        {
            try
            {
                return _accounts[username];
            } catch (KeyNotFoundException e)
            {
                return null;
            }
            
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
