using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace TiledCS.Extensions.MonoGame.Content.Pipeline
{
    [ContentTypeWriter]
    public class TiledMapWriter : ContentTypeWriter<TiledMap>
    {
        protected override void Write(ContentWriter output, TiledMap value)
        {
            output.Write(value.TiledVersion);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "TiledCS.Extensions.MonoGame.Content.TiledMapReader, TiledCS.Extensions.MonoGame";
        }
    }
}
