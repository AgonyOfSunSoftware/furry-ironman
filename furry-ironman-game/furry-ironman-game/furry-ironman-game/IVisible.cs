using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace furry_ironman_game
{
    interface IVisible
    {
        void SetTexture(Texture2D texture);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
