using CombiCon.Helpers;
using CombiCon.Accounts;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace CombiCon
{
    class Program
    {
        private static Vector3 _position;
        private static PasscodeHelper _helper = new PasscodeHelper();

        static void Main(string[] args)
        {
            Account user = new Account(_helper.GenerateSequence());
            Thread.Sleep(20);
            double similarity = user.GenerateSimilarity(_helper.GenerateSequence());
			Console.WriteLine(similarity);
		}
    }
}   
