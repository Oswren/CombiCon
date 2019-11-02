using System;
using System.Collections.Generic;
using System.Numerics;
using JoyCon;

namespace CombiCon
{
    class Program
    {
        private static List<Joycon> joycons;

        // Values made available via Unity
        public float[] stick;
        public static Vector3 gyro;
        public static Vector3 accel;
        public static int jc_ind = 0;
        public static Quaternion orientation;

        static void Main(string[] args)

        {
            JoyconManager jcMan = new JoyconManager();
            jcMan.RefreshJoyConList();
            Console.WriteLine(jcMan.JoyCons.ToString());

        }
    }
    
}
