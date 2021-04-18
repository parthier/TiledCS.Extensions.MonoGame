using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TiledCS.Extensions.MonoGame.Example
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TiledMap _map;
        private TiledTileset _tileset;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set the width and height of the viewport
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _map = Content.Load<TiledMap>("Map");
            _tileset = Content.Load<TiledTileset>("Tileset");

            System.Console.WriteLine("Map.TiledVersion: {0}", _map.TiledVersion);
            System.Console.WriteLine("Dimensions: {0}, {1}", _map.Width, _map.Height);

            System.Console.WriteLine("Tileset.TiledVersion: {0}", _tileset.TiledVersion);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
