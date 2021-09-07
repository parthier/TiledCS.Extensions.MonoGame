using Microsoft.Xna.Framework.Content.Pipeline;

namespace TiledCS.Extensions.MonoGame.Content.Pipeline
{
    [ContentImporter(".tmx", DisplayName = "Tiled Map Importer - TiledCS", DefaultProcessor = "PassThroughProcessor")]
    public class TiledMapImporter : ContentImporter<TiledMap>
    {
        public override TiledMap Import(string filename, ContentImporterContext context)
        {
            return new TiledMap(filename);
        }
    }
}
