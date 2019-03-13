using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.MapScripts {
    class MapObject {
        public String label = "MapObject";
        public Vector2 pos;
        public Texture2D texture;
        public Boolean walkable;
        public Rectangle boundingBox;
        public Boolean destroyed = false;

        public MapObject(Vector2 pos) {
            this.pos = pos;
            this.texture = Game1.textureManager.block;
            this.walkable = false;
            setupBoundingBox();
        }

        public MapObject(String label, Vector2 pos) {
            this.label = label;
            this.pos = pos;
            this.texture = Game1.textureManager.block;
            this.walkable = false;
            setupBoundingBox();
        }

        public virtual void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, this.pos, Color.White);

            if (Game1.debugMode) LineBatch.drawBoundingBox(this.boundingBox, spriteBatch);
        }

        public virtual void Update(GameTime gameTime) {
        }
        
    }
}
