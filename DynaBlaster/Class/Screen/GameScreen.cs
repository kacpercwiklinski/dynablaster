using DynaBlaster.Class.MapScripts;
using DynaBlaster.Class.PlayerScripts;
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
        Player player;

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent){
            this.StartGame();
        }

        public override void Update(GameTime gameTime){
            map.UpdateMap(gameTime);

            player.Update(gameTime);
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch){
            map.DrawMap(spriteBatch);
            player.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
        
        public void StartGame(){
            Map.mapObjects = new List<MapObject>();
            Map.explosions = new List<Explosion>();
            map = new Map();
            player = new Player(Map.blocks[(int)map.spawnPoints[0].X, (int)map.spawnPoints[0].Y].pos, this);
        }

    }
}
