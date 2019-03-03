using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.MapScripts {
    class Map {

        private Vector2 mapPosition = new Vector2(Game1.WIDTH/4,0);

        int blockSize = 42;
        int cols, rows;
        Random random;

        MapObject[,] blocks;

        public Map() {
            random = new Random();

            cols = Game1.WIDTH /2 / blockSize;
            rows = Game1.HEIGHT / blockSize;

            blocks = new MapObject[cols, rows];

            generateMap();
        }
        
        private void generateMap() {
            for(int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    if(x == 0 || x == cols-1 || y == 0 || y == rows - 1) {
                        blocks[x, y] = new Wall(new Vector2(this.mapPosition.X + x * blockSize, this.mapPosition.Y + y * blockSize));
                    }else if(x % 2 == 0 && y % 2 == 0) {
                        blocks[x, y] = new MapObject(new Vector2(this.mapPosition.X + x * blockSize, this.mapPosition.Y + y * blockSize));
                    } else {
                        blocks[x, y] = new Grass(new Vector2(this.mapPosition.X + x * blockSize, this.mapPosition.Y + y * blockSize));
                        if(random.Next(0,100) > 50) {
                            blocks[x, y] = new Dirt(new Vector2(this.mapPosition.X + x * blockSize, this.mapPosition.Y + y * blockSize));
                        }
                    }

                    
                }
            }
        }

        public void DrawMap(SpriteBatch spriteBatch) {
            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    if(blocks[x, y] != null) {
                        blocks[x, y].DrawBlock(spriteBatch);
                    }
                }
            }
        }

        public void UpdateMap(GameTime gameTime) {

        }
    }
}
