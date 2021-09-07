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

            tileset.Image = input.ReadString();
            tileset.ImageWidth = input.ReadInt32();
            tileset.ImageHeight = input.ReadInt32();

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
    }
}
