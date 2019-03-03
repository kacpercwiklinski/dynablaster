using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.MapScripts {

    class Map {
        
        const int DIRT_SPAWN_CHANCE = 50;

        private Vector2 mapPosition = new Vector2(Game1.WIDTH/4,0);
        private Vector2[] spawnPoints = new Vector2[4];

        int blockSize = 42;
        int cols, rows;
        Random random;

        MapObject[,] blocks;

        public Map() {
            random = new Random();

            cols = Game1.WIDTH /2 / blockSize;
            rows = Game1.HEIGHT / blockSize;

            blocks = new MapObject[cols, rows];

            Debug.WriteLine(cols);
            Debug.WriteLine(rows);

            spawnPoints[0] = new Vector2(1, 1);
            spawnPoints[1] = new Vector2(cols-2, 1);
            spawnPoints[2] = new Vector2(1, rows-2);
            spawnPoints[3] = new Vector2(cols-2, rows-2);

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
                        Vector2 tempVector = new Vector2(x, y);
                        if(random.Next(0,100) > DIRT_SPAWN_CHANCE && !(tempVector.Equals(spawnPoints[0]) || tempVector.Equals(spawnPoints[1]) || tempVector.Equals(spawnPoints[2]) || tempVector.Equals(spawnPoints[3]))) {
                            Boolean onSpawnPoint = false;
                            for (int i = 0; i < spawnPoints.Length; i++) {
                                if (tempVector.Equals(spawnPoints[i])) onSpawnPoint = true;
                                if (tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y - 1))) onSpawnPoint = true;
                                if (tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y + 1))) onSpawnPoint = true;
                                if (tempVector.Equals(new Vector2(spawnPoints[i].X - 1, spawnPoints[i].Y))) onSpawnPoint = true;
                                if (tempVector.Equals(new Vector2(spawnPoints[i].X + 1, spawnPoints[i].Y))) onSpawnPoint = true;
                            }
                            if(!onSpawnPoint) blocks[x, y] = new Dirt(new Vector2(this.mapPosition.X + x * blockSize, this.mapPosition.Y + y * blockSize));
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
