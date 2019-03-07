using DynaBlaster.Class.MapScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Utils {
    public class GridManager {

        public static Vector2 absolutePosition(int gridX, int gridY) {
            float tempX = Map.mapPosition.X + gridX * Map.blockSize;// + Map.blockSize / 2;
            float tempY = Map.mapPosition.Y + gridY * Map.blockSize;// + Map.blockSize / 2;
            
            return new Vector2(tempX,tempY);
        }

        public static Vector2 GetOnGridPosition(float pixelX, float pixelY) {
            for (int x = 0; x < Map.blocks.GetLength(0); x++) {
                for (int y = 0; y < Map.blocks.GetLength(1); y++) {
                    if (pixelX > Map.blocks[x, y].pos.X &&
                       pixelX < Map.blocks[x, y].pos.X + Map.blockSize &&
                       pixelY > Map.blocks[x, y].pos.Y &&
                       pixelY < Map.blocks[x, y].pos.Y + Map.blockSize) return new Vector2(x, y);
                }
            }
            return new Vector2();
        }

        public static Vector2 getTextureSpacing(Texture2D texture) {
            return new Vector2((Map.blockSize - texture.Width) / 2, (Map.blockSize - texture.Height) / 2);
        }

        public static Boolean checkIfBlockExist(Vector2 absolutePosition, String labelString) {
            Vector2 onGridPosition = GridManager.GetOnGridPosition(absolutePosition.X, absolutePosition.Y);
            List<String> labels = labelString.Split(' ').ToList();
            Boolean temp = false;
            labels.ForEach(l => {
                temp |= Map.blocks[(int)onGridPosition.X, (int)onGridPosition.Y].label.Equals(l);
            });

            return temp;
        }
    }
}
