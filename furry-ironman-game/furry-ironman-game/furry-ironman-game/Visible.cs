using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace furry_ironman_game
{
    public abstract class Drawable : IDrawable
    {
        protected Drawable()
        {
            
        }

        public void SetTexture(Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime)
        {

        }

        public SpriteBatch Sprite { get; set; }
        public bool Visible { get; private set; }
        public int DrawOrder { get; private set; }
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
    }
}
