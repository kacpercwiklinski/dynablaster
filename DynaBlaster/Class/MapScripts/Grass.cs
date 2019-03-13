using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Grass : MapObject {
        public Grass(Vector2 pos) : base(pos) {
            this.label = "Grass";
            this.texture = Game1.textureManager.grass;
            this.walkable = true;
        }

        public override void Update(GameTime gameTime) {
            drawGrassShadows();
            base.Update(gameTime);
        }

        public void drawGrassShadows() {
                Vector2 gridPos = GridManager.GetOnGridPosition(this.pos.X, this.pos.Y);
                if (gridPos.Y != 0) {
                    if (Map.blocks[(int)gridPos.X, (int)gridPos.Y - 1].label.Equals("Dirt") ||
                        Map.blocks[(int)gridPos.X, (int)gridPos.Y - 1].label.Equals("Wall") ||
                        Map.blocks[(int)gridPos.X, (int)gridPos.Y - 1].label.Equals("Block")) {
                        this.texture = Game1.textureManager.grassShadow;
                    } else {
                        this.texture = Game1.textureManager.grass;
                    }
                }
            
        }
    }
}
