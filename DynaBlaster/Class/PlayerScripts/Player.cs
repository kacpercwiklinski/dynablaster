using DynaBlaster.Class.MapScripts;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.PlayerScripts {
    class Player : MapObject {

        private const float BOMB_PLACE_RATE = 0.4f;
        private int maxBombsPlaced = 1;

        float speed = 200f;
        private Vector2 prevPos = new Vector2();
        private float bombTimer = 0f;
        private int bombRange = 1;
        public static int bombCounter = 0;

        public Player(Vector2 pos) : base(pos) {
            this.label = "Player";
            this.texture = Game1.textureManager.player.First();
            setupBoundingBox();
        }
        
        public override void Update(GameTime gameTime) {

            handleTimers(gameTime);
            
            prevPos = this.pos;
            handleMovement(gameTime);
            handleCollisions(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
           
            base.Draw(spriteBatch);
        }

        private void handleMovement(GameTime gameTime) {
            KeyboardState state = Keyboard.GetState();

            float dx = 0, dy = 0;

            if (state.IsKeyDown(Keys.Up)) {
                dy = -1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Down)) {
                dy = 1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Left)) {
                dx = -1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Right)) {
                dx = 1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (state.IsKeyDown(Keys.Space) && bombTimer <= 0f) {
                Vector2 bombPos = GridManager.GetOnGridPosition(this.pos.X + this.texture.Width/2 ,this.pos.Y + this.texture.Height/2);
                bombPos = GridManager.absolutePosition((int)bombPos.X, (int)bombPos.Y);

                
                if (!Map.mapObjects.Select(bomb => bomb.pos).Any((bomb) => Vector2.Distance(bomb,bombPos) < 32) && bombCounter < maxBombsPlaced) {
                    Map.mapObjects.Add(new Bomb(bombPos, this.bombRange));
                    bombCounter += 1;
                    bombTimer = BOMB_PLACE_RATE;
                }
            }

            this.pos.X += dx;
            this.pos.Y += dy;

            setupBoundingBox();
        }

        public override void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y + 10, this.texture.Width, this.texture.Height - 20);
        }

        private void handleCollisions(GameTime gameTime) {
            List<MapObject> tempObjects = new List<MapObject>();

            // Get closest blocks
            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if(Map.blocks[x, y] != null) {
                        if (Vector2.Distance(Map.blocks[x, y].pos, this.pos) < 80) {
                            tempObjects.Add(Map.blocks[x, y]);
                        }
                    }
                }
            }
            
            // Check collisons with blocks
            tempObjects.ForEach((obj) => {
                if (this.boundingBox.Intersects(obj.boundingBox) && obj.walkable == false) {
                        this.pos = prevPos;
                }
            });

            // Check collisons with map objects
            Map.mapObjects.ForEach(mapObj => {
                if (this.boundingBox.Intersects(mapObj.boundingBox) && mapObj.walkable == true) {
                    // Check if object is bonus
                    if (mapObj.label.Equals("Bonus")) {
                        Bonus bonus = (Bonus)mapObj;
                        // Check bonus type
                        if (bonus.bonusType == BonusType.BombRangeBonus) {
                            this.bombRange += bonus.bonusValue;
                            mapObj.destroyed = true;
                        }else if (bonus.bonusType == BonusType.MaxBombsPlacedBonus) {
                            this.maxBombsPlaced += bonus.bonusValue;
                            mapObj.destroyed = true;
                        }
                    }
                }
            });
        }
        
        private void handleTimers(GameTime gameTime) {
            this.bombTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
