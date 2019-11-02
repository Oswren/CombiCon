using System;
using System.Collections.Generic;
using System.Numerics;

namespace CombiCon
{
    class Program
    {
        public static Vector3 _position;
        public static int jc_ind = 0;

        static void Main(string[] args)
        {
            JoyconManager jcm = new JoyconManager();
            jcm.Awake();
            jcm.Start();
            List<Joycon> js = jcm.j;
            Console.WriteLine(js.Count);
            Joycon j = js[0];
            DateTime oldtime = DateTime.Now;
            DateTime newtime = DateTime.Now;

            double tick = 0;
            
            while (true)
            {

                newtime = DateTime.Now;
                TimeSpan difference = newtime - oldtime;
                j.Update(difference);

                ////poll for the position along the x-axis
                //_position = j.GetAccel();

                //Quaternion test = j.GetVector();

                Console.WriteLine(j.GetAccel());

                ////write the current position between -1.0 and 1.0 along the x-axis
                //if (j.GetButton(Joycon.Button.SHOULDER_2))
                //{
                //    if (Math.Floor(_position.X * 5) < tick-1 || Math.Floor(_position.X * 5) > tick+1)
                //    {
                //        j.SetRumble(160, 320, 0.2f, 5);
                //        tick = Math.Floor(_position.X * 5);
                //        Console.WriteLine("Current position:  " + tick);
                //    }

                //}

                oldtime = newtime;
            }
        }
    }
}
