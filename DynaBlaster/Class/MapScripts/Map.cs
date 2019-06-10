using DynaBlaster.Class.PlayerScripts;
using DynaBlaster.Class.Utils;
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
        const int DIRT_SPAWN_CHANCE = 35;

        public static Vector2 mapPosition = new Vector2(Game1.WIDTH/4,blockSize*2 + 3);
        public Vector2[] spawnPoints = new Vector2[4];

        public const int blockSize = 42;
        public static int cols = Game1.WIDTH  / blockSize / 2;
        public static int rows = (Game1.HEIGHT - (blockSize * 2)) / blockSize;

        public static bool endDoorsSpawned = false;

        Random random;

        public static MapObject[,] blocks;
        public static List<MapObject> mapObjects = new List<MapObject>();
        public static List<Explosion> explosions = new List<Explosion>();

        public Map() {
            random = new Random();

            blocks = new MapObject[cols, rows];

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
                        blocks[x, y] = new Wall(new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize), new Vector2(x,y));
                    }else if(x % 2 == 0 && y % 2 == 0) {
                        blocks[x, y] = new Block(new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize));
                    } else {
                        blocks[x, y] = new Grass(new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize));

                        Vector2 tempVector = new Vector2(x, y);
                        Boolean onSpawnPoint = false;
                        if (random.Next(0,100) > DIRT_SPAWN_CHANCE && !(tempVector.Equals(spawnPoints[0]) || tempVector.Equals(spawnPoints[1]) || tempVector.Equals(spawnPoints[2]) || tempVector.Equals(spawnPoints[3]))) {
                            for (int i = 0; i < spawnPoints.Length; i++) {
                                if (tempVector.Equals(spawnPoints[i]) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y - 1)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y + 1)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X - 1, spawnPoints[i].Y)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X + 1, spawnPoints[i].Y))) onSpawnPoint = true;
                            }
                            if(!onSpawnPoint) blocks[x, y] = new Dirt(new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize));
                        }else {
                            if(random.Next(0,100) < 10) {
                                tempVector = new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize);
                                tempVector = GridManager.GetOnGridPosition(tempVector.X, tempVector.Y);
                                for (int i = 0; i < spawnPoints.Length; i++) {
                                    if (tempVector.Equals(spawnPoints[i]) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y - 1)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X, spawnPoints[i].Y + 1)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X - 1, spawnPoints[i].Y)) ||
                                    tempVector.Equals(new Vector2(spawnPoints[i].X + 1, spawnPoints[i].Y))) onSpawnPoint = true;
                                }
                                if (!onSpawnPoint) Map.mapObjects.Add(new Enemy(new Vector2(Map.mapPosition.X + x * blockSize, Map.mapPosition.Y + y * blockSize)));
                            }
                        }

                        
                    }
                }
            }
        }

        public void DrawMap(SpriteBatch spriteBatch) {
            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    if(blocks[x, y] != null) {
                        blocks[x, y].Draw(spriteBatch);
                    }
                }
            }
            mapObjects.ForEach((mapObject) => mapObject.Draw(spriteBatch));
            explosions.ForEach((explosion) => explosion.Draw(spriteBatch));
        }

        public void UpdateMap(GameTime gameTime) {
            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    if (blocks[x, y] != null) {
                        blocks[x, y].Update(gameTime);
                    }
                }
            }

            for (int i = 0; i < mapObjects.Count(); i++) {
                mapObjects[i].Update(gameTime);
            }
            mapObjects = mapObjects.FindAll((mapObject) => !mapObject.destroyed);
            
            explosions.ForEach((explosion) => explosion.Update(gameTime));
            explosions = explosions.FindAll((explosion) => explosion.livingTime > 0f);
        }
    }
}
