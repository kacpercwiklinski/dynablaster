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
    class SplashScreen : Screen
    {

        Texture2D mSplashScreenBackground;

        public SplashScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            mSplashScreenBackground = Game1.textureManager.splashScreenBackground;
        }

        public override void Update(GameTime theTime)
        {

            for (int aPlayer = 0; aPlayer < 4; aPlayer++)
            {
                if (GamePad.GetState((PlayerIndex)aPlayer).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A) == true || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    PlayerOne = (PlayerIndex)aPlayer;
                    ScreenEvent.Invoke(this, new EventArgs());
                    return;
                }
            }

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //theBatch.Draw(mSplashScreenBackground, Vector2.Zero, Color.White);
            base.Draw(theBatch);
        }

    }
}
