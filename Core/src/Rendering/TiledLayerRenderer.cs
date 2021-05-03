using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TiledCS.Extensions.MonoGame.Rendering
{
    public class TiledLayerRenderer
    {
        public TiledMapRenderer Map { get; private set; }
        public TiledLayer Source { get; private set; }

        public TiledTileRenderer[,] Tiles { get; set; }

        public TiledLayerRenderer(TiledMapRenderer map, TiledLayer source)
        {
            if (source.type != "tilelayer")
                throw new NotSupportedException("Rendering of non-tile layers is no supported.");

            Map = map;
            Source = source;
        }

        public void Load(ContentManager content)
        {
            Tiles = new TiledTileRenderer[Source.width, Source.height];

            for (int index = 0; index < Source.data.Length; ++index)
            {
                int value = Source.data[index];

                if (value <= 0)
                    continue;

                int x = index % Source.width;
                int y = index / Source.height;

                TiledTileRenderer tile = new TiledTileRenderer(this, value);
                tile.Load(content);

                Tiles[x, y] = tile;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Source.width; ++x)
            {
                for (int y = 0; y < Source.height; ++y)
                {
                    TiledTileRenderer tile = Tiles[x, y];

                    if (tile != null)
                        tile.Draw(spriteBatch, x, y);
                }
            }
        }
    }
}
