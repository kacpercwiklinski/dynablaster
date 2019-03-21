using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.UiScripts {
    class Watch : UiObject {

        Vector2 minutePos = new Vector2(UI.barPos.X + 386,UI.barPos.Y + 32);
        Vector2 secondsPos_0 = new Vector2(UI.barPos.X + 417,UI.barPos.Y + 32);
        Vector2 secondsPos_1 = new Vector2(UI.barPos.X + 439,UI.barPos.Y + 32);

        public static Boolean timeEnds = false;

        public static int minutes = 3;
        public static int seconds = 0;

        float counter = 0f;

        public Watch() {

        }

        public Watch(Vector2 position) : base(position) {

        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1.textureManager.numbers_font[minutes], minutePos, Color.White);
            
            if(seconds.ToString().Count() == 1) {
                int firstIndex = 0;
                int secondIndex = (int)char.GetNumericValue(seconds.ToString()[0]);
                spriteBatch.Draw(Game1.textureManager.numbers_font[firstIndex], secondsPos_0, Color.White);
                spriteBatch.Draw(Game1.textureManager.numbers_font[secondIndex], secondsPos_1, Color.White);
            } else if(seconds.ToString().Count() > 1) {
                int firstIndex = (int)char.GetNumericValue(seconds.ToString()[0]);
                int secondIndex = (int)char.GetNumericValue(seconds.ToString()[1]);
                spriteBatch.Draw(Game1.textureManager.numbers_font[firstIndex], secondsPos_0, Color.White);
                spriteBatch.Draw(Game1.textureManager.numbers_font[secondIndex], secondsPos_1, Color.White);
            }
            
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            updateWatch(gameTime);

            base.Update(gameTime);
        }

        private void updateWatch(GameTime gameTime) {
            this.counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (counter > 1f) {
                Watch.seconds--;
                counter = 0;
            }

            if(Watch.seconds < 0 && Watch.minutes > 0) {
                Watch.minutes--;
                Watch.seconds = 59;
            }else if(Watch.seconds < 0 && Watch.minutes == 0) {
                Watch.minutes = 0;
                Watch.seconds = 0;
                Watch.timeEnds = true;
            }
        }
        
    }
}