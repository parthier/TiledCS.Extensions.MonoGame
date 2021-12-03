using Microsoft.Xna.Framework.Content;

namespace TiledCS.Extensions.MonoGame.Content
{
    public class TiledMapReader : ContentTypeReader<TiledMap>
    {
        protected override TiledMap Read(ContentReader input, TiledMap existingInstance)
        {
            TiledMap map = new TiledMap();
            map.TiledVersion = input.ReadString();

            int propertyLength = input.ReadInt32();

            if (propertyLength > 0)
            {
                map.Properties = new TiledProperty[propertyLength];

                for (int index = 0; index < propertyLength; ++index)
                    map.Properties[index] = ReadProperty(input);
            }

            int tilesetLength = input.ReadInt32();

            if (tilesetLength > 0)
            {
                map.Tilesets = new TiledMapTileset[tilesetLength];

                for (int index = 0; index < tilesetLength; ++index)
                    map.Tilesets[index] = ReadMapTileset(input);
            }

            int layerLength = input.ReadInt32();

            if (layerLength > 0)
            {
                map.Layers = new TiledLayer[layerLength];

                for (int index = 0; index < layerLength; ++index)
                {
                    map.Layers[index] = ReadLayer(input);
                }
            }

            map.Orientation = input.ReadString();
            map.RenderOrder = input.ReadString();

            map.Width = input.ReadInt32();
            map.Height = input.ReadInt32();

            map.TileWidth = input.ReadInt32();
            map.TileHeight = input.ReadInt32();

            return map;
        }

        private TiledProperty ReadProperty(ContentReader input)
        {
            TiledProperty property = new TiledProperty();

            property.name = input.ReadString();
            property.type = input.ReadString();
            property.value = input.ReadString();

            return property;
        }

        private TiledMapTileset ReadMapTileset(ContentReader input)
        {
            TiledMapTileset tileset = new TiledMapTileset();

            tileset.firstgid = input.ReadInt32();
            tileset.source = input.ReadString();

            return tileset;
        }

        private TiledLayer ReadLayer(ContentReader input)
        {
            TiledLayer layer = new TiledLayer();

            layer.id = input.ReadInt32();
            layer.name = input.ReadString();

            layer.width = input.ReadInt32();
            layer.height = input.ReadInt32();

            layer.type = input.ReadString();
            layer.visible = input.ReadBoolean();

            int dataLength = input.ReadInt32();

            if (dataLength > 0)
            {
                layer.data = new int[dataLength];

                for (int index = 0; index < dataLength; ++index)
                    layer.data[index] = input.ReadInt32();
            }

            int flagLength = input.ReadInt32();

            if (flagLength > 0)
            {
                layer.dataRotationFlags = new byte[flagLength];

                for (int index = 0; index < flagLength; ++index)
                    layer.dataRotationFlags[index] = input.ReadByte();
            }

            int objectLength = input.ReadInt32();

            if (objectLength > 0)
            {
                layer.objects = new TiledObject[objectLength];

                for (int index = 0; index < objectLength; ++index)
                    layer.objects[index] = ReadObject(input);
            }

            int propertiesLength = input.ReadInt32();

            if (propertiesLength > 0)
            {
                layer.properties = new TiledProperty[propertiesLength];

                for (int index = 0; index < propertiesLength; ++index)
                {
                    layer.properties[index] = ReadProperty(input);
                }
            }

            return layer;
        }

        private TiledObject ReadObject(ContentReader input)
        {
            TiledObject @object = new TiledObject();

            @object.id = input.ReadInt32();
            @object.name = input.ReadString();

            @object.type = input.ReadString();

            @object.x = input.ReadSingle();
            @object.y = input.ReadSingle();

            @object.rotation = input.ReadInt32();

            @object.width = input.ReadSingle();
            @object.height = input.ReadSingle();

            int propertyLength = input.ReadInt32();

            if (propertyLength > 0)
            {
                @object.properties = new TiledProperty[propertyLength];

                for (int index = 0; index < propertyLength; ++index)
                    @object.properties[index] = ReadProperty(input);
            }

            int polygonLength = input.ReadInt32();

            if (polygonLength > 0)
            {
                @object.polygon = new TiledPolygon();
                @object.polygon.points = new float[polygonLength];

                for (int index = 0; index < polygonLength; ++index)
                    @object.polygon.points[index] = input.ReadSingle();
            }

            return @object;
        }
    }
}
