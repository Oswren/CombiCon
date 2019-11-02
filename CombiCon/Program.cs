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
            Vector3 newTick;

            int[] sequence = { 2, -4, 0 };
            var sequencePosition = 0;

            List<Vector3> newSeq = new List<Vector3>();

            while (true)
            {

                newtime = DateTime.Now;
                TimeSpan difference = newtime - oldtime;
                j.Update(difference);

                Console.WriteLine(Vector3.Transform(new Vector3(1, 1, 1), j.GetVector()).Z);

                _position = Vector3.Transform(new Vector3(1, 1, 1), j.GetVector());

                newTick = new Vector3( (int)Math.Floor(_position.X * 4), (int)Math.Floor(_position.Y * 4), (int)Math.Floor(_position.Z * 4));

                foreach (var item in newSeq)
                {
                    if (item.Equals(newTick))
                    {
                        j.SetRumble(160, 180, 1.0f, 100);
                    }
                }

                if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
                {
                    Console.WriteLine(newTick.ToString());
                    newSeq.Add(newTick);
                }

              

                //if (newTick % 2 == 0 && tick != newTick)
                //{
                //    tick = newTick;
                //    if (newTick == sequence[sequencePosition])
                //    {
                //        sequencePosition++;
                //        j.SetRumble(160, 180, 1.0f, 100);
                //        if (sequencePosition == sequence.Length)
                //        {
                //            Console.WriteLine("Open!");
                //            Console.ReadKey();
                //            break;
                //        }
                //        Console.WriteLine("Hit!");
                //    }
                //    else
                //    {
                //        j.SetRumble(160, 180, 0.1f, 1);
                //        Console.WriteLine(newTick);
                //    }
                //}

                oldtime = newtime;
                Thread.Sleep(10);
            }
        }
    }
}
