using System;
using System.Collections.Generic;
using System.Numerics;
using JoyCon;

namespace CombiCon
{
    class Program
    {
        public static Vector3 _position;
        public static int jc_ind = 0;

        static void Main(string[] args)
        {
            JoyconManager jcMan = new JoyconManager();
            jcMan.RefreshJoyConList();
            Console.WriteLine(jcMan.JoyCons.ToString());
            Joycon j = jcMan.JoyCons[0];
            Console.WriteLine(jcMan.JoyCons.Count);
            DateTime oldtime = DateTime.Now;
            DateTime newtime = DateTime.Now;
            double tick = 0;
            while (true)
            {
                newtime = DateTime.Now;
                TimeSpan difference = newtime - oldtime;
                j.Update(difference);

                //poll for the position along the x-axis
                _position = j.GetAccel();

                if (j.GetButton(Joycon.Button.SHOULDER_2))
                {
                    Console.WriteLine(string.Format("Gyro x: {0:N} Gyro y: {1:N} Gyro z: {2:N}", j.GetGyro().X, j.GetGyro().Y, j.GetGyro().Z));
                }

                //write the current position between -1.0 and 1.0 along the x-axis
                if (j.GetButton(Joycon.Button.STICK))
                {
                    if (Math.Floor(_position.X * 10) != tick)
                    {
                        j.SetRumble(160, 320, 0.2f, 5);
                        tick = Math.Floor(_position.X * 10);
                        Console.WriteLine("Current position:  " + tick);
                    }
                    
                }

                oldtime = newtime;
            }
        }
    }
}
