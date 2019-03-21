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
        LivesComponent livesComponent;

        public Bar(Vector2 position) : base(position) {
            this.texture = Game1.textureManager.bar;

            watch = new Watch();
            Watch.timeEnds = false;
            Watch.minutes = 3;
            Watch.seconds = 0;

            livesComponent = new LivesComponent();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, this.position, Color.White);
            watch.Draw(spriteBatch);
            livesComponent.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            watch.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
