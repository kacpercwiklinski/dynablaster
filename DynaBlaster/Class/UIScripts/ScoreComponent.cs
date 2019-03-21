using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynaBlaster.Class.UiScripts {
    internal class ScoreComponent : UiObject {

        public static int score = 0;
        public Vector2[] positions = new Vector2[12];

        private bool positionSetup = false;

        public ScoreComponent() {
            setupPositions();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (positionSetup) {
                int positionIndex = 0;
                for (int i = score.ToString().Length - 1; i >= 0; i--) {
                    spriteBatch.Draw(Game1.textureManager.numbers_font[Game1.textureManager.charToFontNumberIndex(score.ToString()[i])], positions[positionIndex], Color.White);
                    positionIndex++;
                }
            }
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        private void setupPositions() {
            for (int i = 0; i < 12; i++) {
                if (i == 0) {
                    positions[i] = new Vector2(UI.barPos.X + 284, UI.barPos.Y + 32);
                } else {
                    positions[i] = new Vector2(positions[i - 1].X - 21, positions[i - 1].Y);
                }
            }

            this.positionSetup = true;
        }
    }
}