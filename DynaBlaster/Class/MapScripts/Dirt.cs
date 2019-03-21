using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.UiScripts;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaBlaster.Class.MapScripts {
    class Dirt : MapObject {

        private const float BONUS_DROP_CHANCE = 10f;
        private const float DESTROY_ANIMATION_SPEED = 0.055f; // Less - faster

        private float counter;
        public Boolean startDestroyAnimation;

        public Dirt(Vector2 pos) : base(pos) {
            this.label = "Dirt";
            this.texture = Game1.textureManager.dirt.First();
            this.walkable = false;
            this.startDestroyAnimation = false;
            this.counter = 0f;
        }

        public void AnimateDestroy(GameTime gameTime) {
            if (startDestroyAnimation) {
                Animator.animate(gameTime, ref this.texture, Game1.textureManager.dirt, DESTROY_ANIMATION_SPEED, ref counter, true);
            }

            if(this.texture.Equals(Game1.textureManager.dirt.Last())) {
                this.Destroy();
                ScoreComponent.score += 100;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1.textureManager.grass, this.pos, Color.White);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            this.counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            AnimateDestroy(gameTime);
            base.Update(gameTime);
        }

        public void Destroy() {
            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if (Map.blocks[x, y].Equals(this)) {
                        Map.blocks[x, y] = new Grass(GridManager.absolutePosition(x, y));
                        if (Randomizer.random.Next(0, 101) < BONUS_DROP_CHANCE) {
                            // Drop bonus
                            Map.mapObjects.Add(new Bonus(GridManager.absolutePosition(x, y)));
                        }
                        break;
                    }
                }
            }
        }
    }
}
