using Microsoft.Xna.Framework.Content;

namespace TiledCS.Extensions.MonoGame.Content
{
    public class TiledMapReader : ContentTypeReader<TiledMap>
    {
        protected override TiledMap Read(ContentReader input, TiledMap existingInstance)
        {
            TiledMap map = new TiledMap();
            map.TiledVersion = input.ReadString();

            return map;
        }
    }
}
