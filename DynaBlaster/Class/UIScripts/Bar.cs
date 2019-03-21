using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.UiScripts {
    class Bar : UiObject {

        Watch watch;

        public Bar(Vector2 position) : base(position) {
            this.texture = Game1.textureManager.bar;

            watch = new Watch();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, this.position, Color.White);
            watch.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            watch.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
