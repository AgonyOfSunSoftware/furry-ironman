﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace furry_ironman_game
{
    public abstract class Menu : IMenu, IDisposable
    {
        public virtual void Show()
        {
            throw new NotImplementedException();
        }

        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
