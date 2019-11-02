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
            Joycon j = jcMan.JoyCons[0];
            Console.WriteLine(jcMan.JoyCons.Count);
            DateTime oldtime = DateTime.Now;
            DateTime newtime = DateTime.Now;
            while (true)
            {
                newtime = DateTime.Now;
                TimeSpan difference = newtime - oldtime;
                j.Update(difference);
                if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
                {
                    Console.WriteLine("Shoulder pressed");
                }
                if (j.GetButtonDown(Joycon.Button.DPAD_LEFT))
                {
                    Console.WriteLine("DPAD Left pressed");
                }
                Console.WriteLine(string.Format("Gyro x: {0:N} Gyro y: {1:N} Gyro z: {2:N}", j.GetGyro().X, j.GetGyro().Y, j.GetGyro().Z));
                oldtime = newtime;
            }
        }
    }
    
}
