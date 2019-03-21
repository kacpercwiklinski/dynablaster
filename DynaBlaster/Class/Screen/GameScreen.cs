using DynaBlaster.Class.MapScripts;
using DynaBlaster.Class.PlayerScripts;
using DynaBlaster.Class.UiScripts;
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
        UI ui;
        Player player;

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent){
            this.StartGame();
        }

        public override void Update(GameTime gameTime){
            map.UpdateMap(gameTime);
            ui.Update(gameTime);
            player.Update(gameTime);
            
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch){
            map.DrawMap(spriteBatch);
            ui.Draw(spriteBatch);
            player.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
        
        public void StartGame(){
            ui = new UI();
            Map.mapObjects = new List<MapObject>();
            Map.explosions = new List<Explosion>();
            map = new Map();
            player = new Player(Map.blocks[(int)map.spawnPoints[0].X, (int)map.spawnPoints[0].Y].pos, this);
            Player.bombCounter = 0;
        }

        public void invokeScreenEvent() {
            ScreenEvent.Invoke(this, new EventArgs());
        }

    }
}
