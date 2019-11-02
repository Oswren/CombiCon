using System;
using System.Collections.Generic;
using System.Numerics;

namespace CombiCon.Readers
{
    class JoyconReader
    {
        public Joycon CONTROLLER;

        private JoyconManager _manager;
        private DateTime _oldtime = DateTime.Now;
        private DateTime _newtime;
        private TimeSpan _timeDifference;

        public JoyconReader()
        {
            _manager = new JoyconManager();
            InitialiseJoycon();
        }

        public Vector3 PollJoyconForTilt()
        { 
             PollJoycon();
             return CONTROLLER.GetAccel();
        }

        public Quaternion PollJoyconForVector()
        {
             PollJoycon();
             return CONTROLLER.GetVector();
        }

        public bool PollJoyconForButton(Joycon.Button buttonPressed)
        {
            return CONTROLLER.GetButtonDown(buttonPressed);
        }

        private void InitialiseJoycon()
        {
            _manager.Awake();
            _manager.Start();
            CONTROLLER = _manager.j[0];
        }

        private void PollJoycon()
        {
            _newtime = DateTime.Now;
            _timeDifference = _newtime - _oldtime;
            CONTROLLER.Update(_timeDifference);

            _oldtime = _newtime;
        }
    }
}
