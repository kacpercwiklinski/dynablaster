using DynaBlaster.Class.MapScripts;
using DynaBlaster.Class.UiScripts;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.PlayerScripts {
    class Enemy : MapObject {

        float animatorCounter = 0f;
        float animationSpeed = 0.3f;
        float speed = 200f;
        int directionChangeChance = 5;
        Vector2 direction = new Vector2(0, 0);
        Boolean alive = true;
        private Vector2 prevPos = new Vector2();

        public Enemy(Vector2 pos) : base(pos) {
            this.label = "Enemy";
            this.texture = Game1.textureManager.enemy_1.First();
            this.walkable = true;
        }

        private void handleTimers(GameTime gameTime) {
            animatorCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            handleTimers(gameTime);
            prevPos = this.pos;

            if (alive) {
                // Animate enemy
                Animator.animate(gameTime, ref this.texture, Game1.textureManager.enemy_1, animationSpeed, ref animatorCounter, true);
                move(gameTime);
                setupBoundingBox();
            } else {
                animateDeath(gameTime);
            }

            handleCollisions(gameTime);
            base.Update(gameTime);
        }

        private void animateDeath(GameTime gameTime) {
            Animator.animate(gameTime, ref this.texture, Game1.textureManager.enemy_1_death, 0.125f, ref this.animatorCounter, true);
            if (this.texture.Equals(Game1.textureManager.enemy_1_death.Last())) {
                ScoreComponent.score += 100;
                this.destroyed = true;
            }
        }

        public override void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        private void move(GameTime gameTime) {
            if(Randomizer.random.Next(0,100) < directionChangeChance) {
                int randX = Randomizer.random.Next(-1, 2);
                int randY = 0;
                if (randX == 0) {
                    randY = Randomizer.random.Next(0, 2) == 0 ? -1 : 1;
                } else {
                    randY = 0;
                }
                direction = new Vector2(randX, randY);
            }
            
            this.pos += this.direction * 1f;
        }

        private void handleCollisions(GameTime gameTime) {
            List<MapObject> tempObjects = new List<MapObject>();

            // Get closest blocks
            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if (Map.blocks[x, y] != null) {
                        if (Vector2.Distance(Map.blocks[x, y].pos, this.pos) < 80) {
                            tempObjects.Add(Map.blocks[x, y]);
                        }
                    }
                }
            }

            // Check collisons with blocks
            tempObjects.ForEach((obj) => {
                if (this.boundingBox.Intersects(obj.boundingBox) && obj.walkable == false) {
                    //Debug.WriteLine("Kolizja 1");
                    this.pos = prevPos;
                }
            });

            // Check collisons with map objects
            Map.mapObjects.ForEach(mapObj => {
                if (this.boundingBox.Intersects(mapObj.boundingBox) && mapObj.walkable == false) {
                    this.pos = prevPos;
                }
            });

            Map.explosions.ForEach(explosion => {
                explosion.boundingBoxes.ForEach(bb => {
                    if (this.boundingBox.Intersects(bb)) {
                        this.alive = false;
                    }
                });
            });
        }
    }
}
