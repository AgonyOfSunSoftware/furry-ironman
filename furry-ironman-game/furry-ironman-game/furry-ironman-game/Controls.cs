using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace furry_ironman_game
{

    internal class Controls
    {
        public event KeysPressedEvent KeyPressed;

        private void OnKeysPressed(KeysPressedEventArgs args)
        {
            KeysPressedEvent handler = KeyPressed;
            if (handler != null) handler(args);
        }

        public void NotifyKeyPressed()
        {
            var kd = KeysDown();
            if (kd.Length > 0)
                OnKeysPressed(new KeysPressedEventArgs(kd));
        }

        public bool ReceiveInput { get; set; }

        public Controls()
        {
            ReceiveInput = false;
        }

        public Keys[] KeysDown()
        {
            Keys[] keysPressed = {};
            if (ReceiveInput)
                keysPressed = Keyboard.GetState(PlayerIndex.One).GetPressedKeys();
            return keysPressed;
        }

    }

    public delegate void KeysPressedEvent(KeysPressedEventArgs args);

    public class KeysPressedEventArgs
    {
        public KeysPressedEventArgs(Keys[] keys)
        {
            KeyboardDown = keys;
        }

        public Keys[] KeyboardDown { private set; get; }
    }
}