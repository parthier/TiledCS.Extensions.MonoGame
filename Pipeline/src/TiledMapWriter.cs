using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace TiledCS.Extensions.MonoGame.Content.Pipeline
{
    [ContentTypeWriter]
    public class TiledMapWriter : ContentTypeWriter<TiledMap>
    {
        protected override void Write(ContentWriter output, TiledMap map)
        {
            output.Write(map.TiledVersion);

            if (map.Properties != null)
            {
                int propertyLength = map.Properties.Length;
                output.Write(propertyLength);

                for (int index = 0; index < propertyLength; ++index)
                    WriteProperty(map.Properties[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (map.Tilesets != null)
            {
                int tilesetLength = map.Tilesets.Length;
                output.Write(tilesetLength);

                for (int index = 0; index < tilesetLength; ++index)
                    WriteMapTileset(map.Tilesets[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (map.Layers != null)
            {
                int layerLength = map.Layers.Length;
                output.Write(layerLength);

                for (int index = 0; index < layerLength; ++index)
                    WriteLayer(map.Layers[index], output);
            }
            else
            {
                output.Write(0);
            }

            output.Write(map.Orientation);
            output.Write(map.RenderOrder);

            output.Write(map.Width);
            output.Write(map.Height);

            output.Write(map.TileWidth);
            output.Write(map.TileHeight);
        }

        public static void WriteProperty(TiledProperty property, ContentWriter output)
        {
            output.Write(property.name);
            output.Write(property.type);
            output.Write(property.value);
        }

        public static void WriteMapTileset(TiledMapTileset tileset, ContentWriter output)
        {
            output.Write(tileset.firstgid);
            output.Write(tileset.source);
        }

        public static void WriteLayer(TiledLayer layer, ContentWriter output)
        {
            output.Write(layer.id);
            output.Write(layer.name);

            output.Write(layer.width);
            output.Write(layer.height);

            output.Write(layer.type);
            output.Write(layer.visible);

            if (layer.data != null)
            {
                int dataLength = layer.data.Length;
                output.Write(dataLength);

                for (int index = 0; index < dataLength; ++index)
                    output.Write(layer.data[index]);
            }
            else
            {
                output.Write(0);
            }

            if (layer.dataRotationFlags != null)
            {
                int flagLength = layer.dataRotationFlags.Length;
                output.Write(flagLength);

                for (int index = 0; index < flagLength; ++index)
                    output.Write(layer.dataRotationFlags[index]);
            }
            else
            {
                output.Write(0);
            }

            if (layer.objects != null)
            {
                int objectLength = layer.objects.Length;
                output.Write(objectLength);

                for (int index = 0; index < objectLength; ++index)
                    WriteObject(layer.objects[index], output);
            }
            else
            {
                output.Write(0);
            }
        }

        public static void WriteObject(TiledObject @object, ContentWriter output)
        {
            output.Write(@object.id);
            output.Write(@object.name);

            output.Write(@object.type);

            output.Write(@object.x);
            output.Write(@object.y);

            output.Write(@object.rotation);

            output.Write(@object.width);
            output.Write(@object.height);

            if (@object.properties != null)
            {
                int propertyLength = @object.properties.Length;
                output.Write(propertyLength);

                for (int index = 0; index < propertyLength; ++index)
                    WriteProperty(@object.properties[index], output);
            }
            else
            {
                output.Write(0);
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "TiledCS.Extensions.MonoGame.Content.TiledMapReader, TiledCS.Extensions.MonoGame";
        }
    }
}
