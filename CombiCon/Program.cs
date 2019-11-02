using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

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
            DateTime newtime;
            int tick = 20;
            int newTick;

            int[] sequence = new int[] { 2, -4, 0 };
            var sequencePosition = 0;

            while (true)
            {

                newtime = DateTime.Now;
                TimeSpan difference = newtime - oldtime;
                j.Update(difference);

                _position = j.GetAccel();

                newTick = (int)Math.Floor(_position.X * 4);

                if (newTick % 2 == 0 && tick != newTick)
                {
                    tick = newTick;
                    if (newTick == sequence[sequencePosition])
                    {
                        sequencePosition++;
                        j.SetRumble(160, 180, 1.0f, 100);
                        if (sequencePosition == sequence.Length)
                        {
                            Console.WriteLine("Open!");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Hit!");
                    }
                    else
                    {
                        j.SetRumble(160, 180, 0.1f, 1);
                        Console.WriteLine(newTick);
                    }
                }

                oldtime = newtime;
                Thread.Sleep(100);
            }
        }
    }
}
