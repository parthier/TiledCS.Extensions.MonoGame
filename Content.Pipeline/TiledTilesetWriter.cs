using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace TiledCS.Extensions.MonoGame.Content.Pipeline
{
    [ContentTypeWriter]
    public class TiledTilesetWriter : ContentTypeWriter<TiledTileset>
    {
        protected override void Write(ContentWriter output, TiledTileset tileset)
        {
            output.Write(tileset.TiledVersion);
            output.Write(tileset.Name);

            output.Write(tileset.TileWidth);
            output.Write(tileset.TileHeight);

            output.Write(tileset.TileCount);
            output.Write(tileset.Columns);

            if (tileset.Image != null)
            {
                output.Write(1);
                output.Write(tileset.Image.source);
                output.Write(tileset.Image.width);
                output.Write(tileset.Image.height);
            }
            else
            {
                output.Write(0);
            }

                output.Write(tileset.Spacing);
                output.Write(tileset.Margin);
            

            if (tileset.Tiles != null)
            {
                int tileLength = tileset.Tiles.Length;
                output.Write(tileLength);

                for (int index = 0; index < tileset.Tiles.Length; ++index)
                    WriteTile(tileset.Tiles[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (tileset.Terrains != null)
            {
                int terrainLength = tileset.Terrains.Length;
                output.Write(terrainLength);

                for (int index = 0; index < terrainLength; ++index)
                    WriteTerrain(tileset.Terrains[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (tileset.Properties != null)
            {
                int propertyLength = tileset.Properties.Length;
                output.Write(propertyLength);

                for (int index = 0; index < propertyLength; ++index)
                    WriteProperty(tileset.Properties[index], output);
            }
            else
            {
                output.Write(0);
            }
        }

        public void WriteTile(TiledTile tile, ContentWriter output)
        {
            output.Write(tile.id);

            if (tile.image != null)
            {
                output.Write(1);
                output.Write(tile.image.source);
                output.Write(tile.image.width);
                output.Write(tile.image.height);
            }
            else
            {
                output.Write(0);
            }

            if (tile.objects != null)
            {
                int objectLength = tile.objects.Length;
                output.Write(objectLength);

                for (int index = 0; index < objectLength; ++index)
                    WriteObject(tile.objects[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (tile.terrain != null)
            {
                int terrainLength = tile.terrain.Length;
                output.Write(terrainLength);

                for (int index = 0; index < terrainLength; ++index)
                    output.Write(tile.terrain[index]);
            }
            else
            {
                output.Write(0);
            }

            if (tile.properties != null)
            {
                int propertyLength = tile.properties.Length;
                output.Write(propertyLength);

                for (int index = 0; index < propertyLength; ++index)
                    WriteProperty(tile.properties[index], output);
            }
            else
            {
                output.Write(0);
            }

            if (tile.animation != null)
            {
                int animationLength = tile.animation.Length;
                output.Write(animationLength);

                for (int index = 0; index < animationLength; ++index)
                    WriteTileAnimation(tile.animation[index], output);
            }
            else
            {
                output.Write(0);
            }
        }

        public void WriteTerrain(TiledTerrain terrain, ContentWriter output)
        {
            output.Write(terrain.name);
            output.Write(terrain.tile);
        }

        public void WriteProperty(TiledProperty property, ContentWriter output)
        {
            output.Write(property.name);
            output.Write(property.type);
            output.Write(property.value);
        }

        public void WriteTileAnimation(TiledTileAnimation animation, ContentWriter output)
        {
            output.Write(animation.tileid);
            output.Write(animation.duration);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "TiledCS.Extensions.MonoGame.Content.TiledTilesetReader, TiledCS.Extensions.MonoGame";
        }

        public void WriteObject(TiledObject @object, ContentWriter output)
        {
            output.Write(@object.id);

            if (@object.name != null)
                output.Write(@object.name);
            else output.Write("");

            if (@object.type != null)
                output.Write(@object.type);
            else output.Write("");

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

            if (@object.polygon != null)
            {
                int polygonLength = @object.polygon.points.Length;
                output.Write(polygonLength);

                for (int index = 0; index < polygonLength; ++index)
                    output.Write(@object.polygon.points[index]);
            }
            else
            {
                output.Write(0);
            }
        }
    }
}
