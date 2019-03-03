using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.MapScripts {
    class MapObject {
        public Vector2 pos;
        public Texture2D texture;

        public MapObject(Vector2 pos) {
            this.pos = pos;
            this.texture = Game1.textureManager.block;
        }

        public virtual void DrawBlock(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.texture, this.pos, Color.White);
        }

    }
}
