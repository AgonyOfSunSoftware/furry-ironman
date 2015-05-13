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
    class Player : Drawable, IControllable, IUpdatable
    {
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

        public Vector2 Speed { get; private set; }

        public Player(SpriteBatch sprite, Texture2D texture = null, float X = 0, float Y = 0, float maxSpeed = 1) : base(sprite, texture, X, Y)
        {
            _maxSpeed = maxSpeed;
            _keys = new Keys[0];
        }

        public void OnKeysDown(KeysPressedEventArgs e)
        {
            _keys = e.KeyboardDown;
        }

        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update(GameTime gameTime)
        {
           Move();
        }

        private void Move()
        {
            if (CanMove)
            {
                DirectionalMove();
                if (CanJump)
                {
                    var keys = Keyboard.GetState(PlayerIndex.One).GetPressedKeys();
                    if(keys.Contains((Keys)Actions.Jump))

                }
            }

        }

        public bool CanJump { get; set; }

        public bool CanMove { get; set; }

        private void DirectionalMove()
        {
            var keys = Keyboard.GetState(PlayerIndex.One).GetPressedKeys();
            var diff = new Vector2(0, 0);
            var tickSpeed = _maxSpeed;
            if (keys.Contains((Keys)Actions.Right))
                diff.X += tickSpeed;
            else if (keys.Contains((Keys)Actions.Left))
                diff.X -= tickSpeed;
            if (keys.Contains((Keys)Actions.Down))
                diff.Y += tickSpeed;
            else if (keys.Contains((Keys)Actions.Up))
                diff.Y -= tickSpeed;
            //if (Math.Abs(0.0 - diff.X) >= 1.0 && Math.Abs(0.0 - diff.Y) >= 1.0)
            //{
            //    var tmp = Math.Abs(diff.X / diff.Y) * diff.X;
            //    diff.Y = Math.Abs(diff.Y / diff.X) * diff.Y;
            //    diff.X = tmp;
            //}
            if (diff.Length() > 0)
            {
                diff.Normalize();
                diff = diff*tickSpeed;
                Coords += diff;
            }
        }
    }
}
