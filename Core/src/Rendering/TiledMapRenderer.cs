using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Collections.Generic;

namespace TiledCS.Extensions.MonoGame.Rendering
{
    public class TiledMapRenderer
    {
        public TiledMap Source { get; private set; }
        public TiledLayerRenderer[] Layers { get; set; }

        private Dictionary<int, TiledTileset> _tilesets;

        public TiledMapRenderer(TiledMap source)
        {
            Source = source;
        }

        public void Load(ContentManager content)
        {
            _tilesets = new Dictionary<int, TiledTileset>();

            for (int index = 0; index < Source.Tilesets.Length; ++index)
            {
                TiledMapTileset mapTileset = Source.Tilesets[index];

                string assetName = Path.GetFileNameWithoutExtension(mapTileset.source);
                TiledTileset tileset = content.Load<TiledTileset>(assetName);

                _tilesets.Add(mapTileset.firstgid, tileset);
            }

            Layers = new TiledLayerRenderer[Source.Layers.Length];

            for (int index = 0; index < Source.Layers.Length; ++index)
            {
                TiledLayerRenderer layer = new TiledLayerRenderer(this, Source.Layers[index]);

                layer.Load(content);
                Layers[index] = layer;
            }
        }

        public void Unload()
        {
            for (int index = 0; index < Layers.Length; ++index)
                Layers[index].Unload();

            Layers = null;
            _tilesets.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < Layers.Length; ++index)
                Layers[index].Draw(spriteBatch);
        }

        public TiledTileset GetTilesetFromGid(int gid)
        {
            TiledMapTileset mapTileset = Source.GetTiledMapTileset(gid);

            // TODO: Check if mapTileset is not null

            if (_tilesets.ContainsKey(mapTileset.firstgid))
                return _tilesets[mapTileset.firstgid];

            return default(TiledTileset);
        }

        public TiledTileset GetTilesetFromGid(TiledMapTileset tileset)
        {
            return GetTilesetFromGid(tileset.firstgid);
        }
    }
}
