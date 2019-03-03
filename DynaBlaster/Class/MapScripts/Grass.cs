using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Grass : MapObject {
        public Grass(Vector2 pos) : base(pos) {
            this.texture = Game1.textureManager.grass;
            this.walkable = true;
        }
    }
}
