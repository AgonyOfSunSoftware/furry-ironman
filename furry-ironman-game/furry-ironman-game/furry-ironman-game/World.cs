using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace furry_ironman_game
{
    public class World : Drawable, IUpdatable, IDisposable
    {
        private Player _player;
        private Controls _controls;
        private ContentManager _content;
        private List<object> _gameObjects = new List<object>();

        public World(ContentManager content)
        {
            _content = content;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            _player = new Player(new Vector2(300, 300), 10);
            _player.SetTexture(_content.Load<Texture2D>("lalka"));
            _controls = new Controls { ReceiveInput = true };
            _controls.KeyPressed += _player.OnKeysDown;
            AddGameObject(_player);
        }

        private void AddGameObject(object obj)
        {
            if(!_gameObjects.Contains(obj))
                _gameObjects.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in _gameObjects)
            {
                if(obj is IUpdatable)
                    ((IUpdatable)obj).Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var obj in _gameObjects)
            {
                if (obj is IDrawable)
                    ((IDrawable)obj).Draw(gameTime);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
