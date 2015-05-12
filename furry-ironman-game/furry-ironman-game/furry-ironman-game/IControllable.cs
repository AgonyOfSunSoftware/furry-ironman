using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace furry_ironman_game
{
    interface IControllable
    {
        void OnKeysDown(KeysPressedEventArgs e);
    }
}
