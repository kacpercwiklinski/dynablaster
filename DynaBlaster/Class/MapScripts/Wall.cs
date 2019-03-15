using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class Wall : MapObject {

        Vector2 gridPos;
        
        public Wall(Vector2 pos, Vector2 gridPos) : base(pos) {
            this.texture = Game1.textureManager.wall;
            this.walkable = false;
            this.label = "Wall";
            this.gridPos = gridPos;

            // Setup proper wall texture
            if(gridPos.X == 0 && gridPos.Y == 0) {
                this.texture = Game1.textureManager.wall_left_top_corner;
            }else if (gridPos.X == Map.cols-1 && gridPos.Y == 0) {
                this.texture = Game1.textureManager.wall_right_top_corner;
            }else if (gridPos.X % 2 == 0 && gridPos.Y == 0) {
                this.texture = Game1.textureManager.wall_top_0;
            } else if (gridPos.X == 0 && gridPos.Y > 0 && gridPos.Y < Map.rows-1) {
                this.texture = Game1.textureManager.wall_left;
            } else if (gridPos.X == Map.cols-1 && gridPos.Y > 0 && gridPos.Y < Map.rows - 1) {
                this.texture = Game1.textureManager.wall_right;
            } else {
                this.texture = Game1.textureManager.wall_top_1;
            }
        }
    }
}
