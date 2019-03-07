using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Block : MapObject {
        public Block(Vector2 pos) : base(pos) {
            this.label = "Block";
            this.walkable = false;
            this.texture = Game1.textureManager.block;
        }
    }
}
