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
            List<Vector3> passcode2 = _helper.GenerateSequence();


        }
    }
}   
