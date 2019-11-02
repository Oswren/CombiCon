using System;
using System.Collections.Generic;
using System.Numerics;

namespace CombiCon.Helpers
{
    class JoyconHelper
    {
        public Joycon CONTROLLER;

        private JoyconManager _manager;
        private DateTime _oldtime = DateTime.Now;
        private DateTime _newtime;
        private TimeSpan _timeDifference;

        public JoyconHelper()
        {
            _manager = new JoyconManager();
            InitialiseJoycon();
        }

        public void VibrateJoycon(float intensity, int milliseconds)
        {
            PollJoycon();
            CONTROLLER.SetRumble(160, 180, intensity, milliseconds);
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

        public Vector3 PollJoyconForDirection()
        {
            return Vector3.Transform(new Vector3(1, 1, 1), PollJoyconForVector());
         
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
