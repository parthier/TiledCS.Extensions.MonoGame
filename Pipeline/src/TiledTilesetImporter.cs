using Microsoft.Xna.Framework.Content.Pipeline;

namespace TiledCS.Extensions.MonoGame.Content.Pipeline
{
    [ContentImporter(".tsx", DisplayName = "Tiled Tileset Importer - TiledCS", DefaultProcessor = "PassThroughProcessor")]
    public class TiledTilesetImporter : ContentImporter<TiledTileset>
    {
        public override TiledTileset Import(string filename, ContentImporterContext context)
        {
            return new TiledTileset(filename);
        }
    }
}
