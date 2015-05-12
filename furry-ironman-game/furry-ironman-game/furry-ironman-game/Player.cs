using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace furry_ironman_game
{
    class Player : IControllable, IVisible, IUpdatable
    {
        private Texture2D _texture;
        private float _maxSpeed;
        private Keys[] _keys;

        public enum Actions
        {
            Left = Keys.A,
            Right = Keys.D,
            Up = Keys.W,
            Down = Keys.S,
            Jump = Keys.Space
        }

        public Dictionary<Keys, Actions> Bindings { get; private set; }

        public Vector2 Coords { get; private set; }

        public Vector2 Speed { get; private set; }

        public Player(Vector2 spawnPos, float maxSpeed)
        {
            Coords = spawnPos;
            Speed = new Vector2(0,0);
            _maxSpeed = maxSpeed;
            _keys = new Keys[0];
        }

        public void OnKeysDown(KeysPressedEventArgs e)
        {
            _keys = e.KeyboardDown;
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(   (int)(Coords.X),
                                                        (int)(Coords.Y),
                                                        (int)_texture.Width,
                                                        (int)_texture.Height),Color.White);
        }

        public void Update(GameTime gameTime)
        {
            var keys = Keyboard.GetState(PlayerIndex.One).GetPressedKeys();
            var diff = new Vector2(0, 0);
            var tickSpeed = gameTime.FromPPS(_maxSpeed);
            if (keys.Contains((Keys)Actions.Right))
                diff.X += tickSpeed;
            else if(keys.Contains((Keys)Actions.Left))
                diff.X -= tickSpeed;
            if (keys.Contains((Keys)Actions.Down))
                diff.Y += tickSpeed;
            else if(keys.Contains((Keys)Actions.Up))
                diff.Y -= tickSpeed;
            if (Math.Abs(0.0 - diff.X) >= 1.0 && Math.Abs(0.0 - diff.Y) >= 1.0)
            {
                var tmp = Math.Abs(diff.X / diff.Y) * diff.X;
                diff.Y = Math.Abs(diff.Y / diff.X) * diff.Y;
                diff.X = tmp;
            }
            Move(diff);
        }

        private void Move(Vector2 diff)
        {
            Coords += diff;
        }
    }
}
