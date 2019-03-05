using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Bomb : MapObject {

        float timer = 3f;
        float upCounter = 0f;
        public bool exploded = false;
        private Vector2 positionSpacing;
        //private int bombRange = 2;

        public Bomb(Vector2 pos) : base(pos) {
            positionSpacing = new Vector2((Map.blockSize - Game1.textureManager.bomb.First().Width) / 2, (Map.blockSize - Game1.textureManager.bomb.First().Height) / 2);
            this.pos = new Vector2(pos.X + positionSpacing.X, pos.Y + positionSpacing.Y);
            this.texture = Game1.textureManager.bomb.First();
        }

        public override void Update(GameTime gameTime) {
            upCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Animator.animate(gameTime, ref this.texture, Game1.textureManager.bomb, 1f, ref upCounter, true);

            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timer <= 0f) {
                explode();
                exploded = true;
            }

            base.Update(gameTime);
        }

        private void explode() {
            Debug.WriteLine("Explode");
        }
    }
}
