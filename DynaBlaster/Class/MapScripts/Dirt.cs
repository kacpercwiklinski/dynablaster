using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Dirt : MapObject {
        public Dirt(Vector2 pos) : base(pos) {
            this.label = "Dirt";
            this.texture = Game1.textureManager.dirt;
            this.walkable = false;
        }

        public void Destroy() {
            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if (Map.blocks[x, y].Equals(this)) Map.blocks[x, y] = null;
                }
            }
        }
    }
}
