using System;
using System.Collections.Generic;
using System.Numerics;
using JoyCon;

namespace CombiCon.Readers
{
    class JoyConReader
    {
        private JoyconManager _manager;
        private Joycon _controller;
        private DateTime _oldtime = DateTime.Now;
        private DateTime _newtime;
        private TimeSpan _timeDifference;

        public JoyConReader() 
        {
            _manager = new JoyconManager();
            _controller = _manager.JoyCons[0];
        }

        public Vector3 PollJoyConForPosition()
        {
            while (true)
            {
                PollJoycon();
                return _controller.GetAccel();
            }
        }

        public Quaternion PollJoyConForVector()
        {
            while (true)
            {
                PollJoycon();
                return _controller.GetVector();
            }
        }

        private void PollJoycon()
        {
            _newtime = DateTime.Now;
            _timeDifference = _newtime - _oldtime;
            _controller.Update(_timeDifference);

            _oldtime = _newtime;
        }
    }
}
