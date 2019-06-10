using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Screen
{
    class GameOverScreen : Screen
    {

        Texture2D mGameOverScreen;
        Texture2D mGameOverScreenBackground;

        public GameOverScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            mGameOverScreenBackground = Game1.textureManager.gameOverScreenBackground;
            mGameOverScreen = Game1.textureManager.gameOverScreenBackground;
        }

        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(mGameOverScreenBackground, Vector2.Zero, Color.White);
            theBatch.Draw(mGameOverScreen, Vector2.Zero, Color.White);
            base.Draw(theBatch);
        }
    }
}
