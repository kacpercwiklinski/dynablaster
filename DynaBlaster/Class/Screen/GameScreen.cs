using DynaBlaster.Class.MapScripts;
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

        Map map;
        

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent){
            map = new Map();
        }

        public override void Update(GameTime gameTime){


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch){

            map.DrawMap(spriteBatch);

            base.Draw(spriteBatch);
        }
        
        public void StartGame(){

        }

    }
}
