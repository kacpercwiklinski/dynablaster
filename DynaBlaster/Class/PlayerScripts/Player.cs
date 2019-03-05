using DynaBlaster.Class.MapScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.PlayerScripts {
    class Player : MapObject {

        float speed = 200f;
        private Vector2 prevPos = new Vector2();

        public Player(Vector2 pos) : base(pos) {
            this.texture = Game1.textureManager.player.First();
            setupBoundingBox();
        }
        
        public override void Update(GameTime gameTime) {
            
            prevPos = this.pos;
            handleMovement(gameTime);
            handleCollisions(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
           
            base.Draw(spriteBatch);
        }

        private void handleMovement(GameTime gameTime) {
            KeyboardState state = Keyboard.GetState();

            float dx = 0, dy = 0;

            if (state.IsKeyDown(Keys.Up)) {
                dy = -1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Down)) {
                dy = 1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Left)) {
                dx = -1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (state.IsKeyDown(Keys.Right)) {
                dx = 1 * this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            this.pos.X += dx;
            this.pos.Y += dy;

            setupBoundingBox();

        }

        private void handleCollisions(GameTime gameTime) {
            //MapObject[,] tempObjects = Map.blocks;
            List<MapObject> tempObjects = new List<MapObject>();

            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if(Vector2.Distance(Map.blocks[x,y].pos,this.pos) < 80) {
                        tempObjects.Add(Map.blocks[x, y]);
                    }
                }
            }
            
            tempObjects.ForEach((obj) => {
                if (this.boundingBox.Intersects(obj.boundingBox) && obj.walkable == false) {
                    this.pos = prevPos;
                } 
            });
        }
    }
}
