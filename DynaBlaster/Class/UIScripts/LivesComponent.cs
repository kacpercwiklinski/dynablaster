using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaBlaster.Class.UiScripts {
    internal class LivesComponent : UiObject {

        public static int lives = 3;

        public LivesComponent() {
            this.position = new Vector2(UI.barPos.X + 538, UI.barPos.Y + 32);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if(lives >= 0 && lives <= 9) spriteBatch.Draw(Game1.textureManager.numbers_font[lives], this.position, Color.White);
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }
    }
}