using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace furry_ironman_game
{
    public static class PPS
    {
        public static float FromPPS(this GameTime gameTime, float speed)
        {
            var TPS = (float)gameTime.ElapsedGameTime.Ticks/1000000;//gameTime.ElapsedGameTime;
            return (float)speed*TPS;
        }
    }
}
