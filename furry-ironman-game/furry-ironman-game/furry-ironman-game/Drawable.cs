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
        protected Drawable(SpriteBatch sprite,Texture2D texture = null,float X=0, float Y=0)
        {
            SpriteBatch = sprite;
            Texture = texture;
            Coords = new Vector2(X,Y);
        }

        public virtual void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Texture,new Rectangle((int)Coords.X,(int)Coords.Y,Texture.Width,Texture.Height),Color.White);
        }

        protected Vector2 Coords { get; set; }
        protected Texture2D Texture { get; set; }
        private SpriteBatch SpriteBatch { get; set; }
        public bool Visible { get; private set; }
        public int DrawOrder { get; private set; }
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
    }
}
