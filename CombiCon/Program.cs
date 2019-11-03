using CombiCon.Helpers;
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
            List<Vector3> passcode1 = _helper.GenerateSequence();
            Thread.Sleep(20);
            List<Vector3> passcode2 = _helper.GenerateSequence();

            double total_error = 0;

			for (int i = 0; i < passcode1.Count; i++)
			{
                Vector3 delta = passcode2[i] - passcode1[i];
                total_error += Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) + Math.Pow(delta.Z, 2));
			}

			Console.WriteLine(total_error);
		}
    }
}   
