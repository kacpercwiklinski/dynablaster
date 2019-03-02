using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Screen
{
    class GameScreen : Screen
    {

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
   
        }

        public override void Update(GameTime theTime)
        {


            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            

            base.Draw(theBatch);
        }
        
        public void StartGame()
        {

        }

    }
}
