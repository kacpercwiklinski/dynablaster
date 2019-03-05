using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Bomb : MapObject {

        float timer = 3f;
        public bool exploded = false;

        public Bomb(Vector2 pos) : base(pos) {
            this.pos = new Vector2(pos.X + Game1.textureManager.bomb.First().Width / 4, pos.Y + Game1.textureManager.bomb.First().Height / 4);
            this.texture = Game1.textureManager.bomb.First();
        }

        public override void Update(GameTime gameTime) {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timer <= 0f) {
                exploded = true;
            }

            base.Update(gameTime);
        }




    }



}
