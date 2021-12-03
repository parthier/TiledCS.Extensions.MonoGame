using Microsoft.Xna.Framework.Content;

namespace TiledCS.Extensions.MonoGame.Content
{
    public class TiledTilesetReader : ContentTypeReader<TiledTileset>
    {
        protected override TiledTileset Read(ContentReader input, TiledTileset existingInstance)
        {
            TiledTileset tileset = new TiledTileset();

            tileset.TiledVersion = input.ReadString();
            tileset.Name = input.ReadString();

            tileset.TileWidth = input.ReadInt32();
            tileset.TileHeight = input.ReadInt32();

            tileset.TileCount = input.ReadInt32();
            tileset.Columns = input.ReadInt32();

            int image = input.ReadInt32();
            if (image != 0)
            {
                tileset.Image = new TiledImage();
                tileset.Image.source = input.ReadString();
                tileset.Image.width = input.ReadInt32();
                tileset.Image.height = input.ReadInt32();
            }

            tileset.Spacing = input.ReadInt32();
            tileset.Margin = input.ReadInt32();

            int tileLength = input.ReadInt32();

            if (tileLength > 0)
            {
                tileset.Tiles = new TiledTile[tileLength];

                for (int index = 0; index < tileLength; ++index)
                    tileset.Tiles[index] = ReadTile(input);
            }

            int terrainLength = input.ReadInt32();

            if (terrainLength > 0)
            {
                tileset.Terrains = new TiledTerrain[terrainLength];

                for (int index = 0; index < terrainLength; ++index)
                    tileset.Terrains[index] = ReadTerrain(input);
            }

            int propertyLength = input.ReadInt32();

            if (propertyLength > 0)
            {
                tileset.Properties = new TiledProperty[propertyLength];

                for (int index = 0; index < propertyLength; ++index)
                    tileset.Properties[index] = ReadProperty(input);
            }

            return tileset;
        }

        private TiledTile ReadTile(ContentReader input)
        {
            TiledTile tile = new TiledTile();
            tile.id = input.ReadInt32();

            int image = input.ReadInt32();
            if (image != 0)
            {
                tile.image = new TiledImage();
                tile.image.source = input.ReadString();
                tile.image.width = input.ReadInt32();
                tile.image.height = input.ReadInt32();
            }

            int objectLength = input.ReadInt32();
            if (objectLength > 0)
            {
                tile.objects = new TiledObject[objectLength];

                for (int index = 0; index < objectLength; ++index)
                    tile.objects[index] = ReadObject(input);
            }

            int terrainLength = input.ReadInt32();

            if (terrainLength > 0)
            {
                tile.terrain = new int[terrainLength];

                for (int index = 0; index < terrainLength; ++index)
                    tile.terrain[index] = input.ReadInt32();
            }

            int propertyLength = input.ReadInt32();

            if (propertyLength > 0)
            {
                tile.properties = new TiledProperty[propertyLength];

                for (int index = 0; index < propertyLength; ++index)
                    tile.properties[index] = ReadProperty(input);
            }

            int animationLength = input.ReadInt32();

            if (animationLength > 0)
            {
                tile.animation = new TiledTileAnimation[animationLength];

                for (int index = 0; index < animationLength; ++index)
                    tile.animation[index] = ReadTileAnimation(input);
            }

            return tile;
        }

        private TiledTerrain ReadTerrain(ContentReader input)
        {
            TiledTerrain terrain = new TiledTerrain();

            terrain.name = input.ReadString();
            terrain.tile = input.ReadInt32();

            return terrain;
        }

        private TiledProperty ReadProperty(ContentReader input)
        {
            TiledProperty property = new TiledProperty();

            property.name = input.ReadString();
            property.type = input.ReadString();
            property.value = input.ReadString();

            return property;
        }

        private TiledTileAnimation ReadTileAnimation(ContentReader input)
        {
            TiledTileAnimation animation = new TiledTileAnimation();

            animation.tileid = input.ReadInt32();
            animation.duration = input.ReadInt32();

            return animation;
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
