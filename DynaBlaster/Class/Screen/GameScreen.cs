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
    public enum GameMode { Single, Multi }
    class GameScreen : Screen
    {

        Map map;
        List<Player> players = new List<Player>();
        GameMode gameMode = GameMode.Single;

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent){
            map = new Map();
            players.Add(new Player(Map.blocks[(int)map.spawnPoints[0].X, (int)map.spawnPoints[0].Y].pos));
        }

        public override void Update(GameTime gameTime){
            players.ForEach((player) => player.Update(gameTime));

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch){
            map.DrawMap(spriteBatch);


            players.ForEach((player) => player.Draw(spriteBatch));
            base.Draw(spriteBatch);
        }
        
        public void StartGame(GameMode gameMode){
            this.gameMode = gameMode;
            map = new Map();
        }

    }
}
