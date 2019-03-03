using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Dirt : MapObject {
        public Dirt(Vector2 pos) : base(pos) {
            this.texture = Game1.textureManager.dirt;
        }
    }
}
