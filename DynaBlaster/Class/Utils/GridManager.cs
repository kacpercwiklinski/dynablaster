﻿using DynaBlaster.Class.MapScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Utils {
    public class GridManager {

        public static Vector2 GetFromGridPosition(int gridX, int gridY) {
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
    }
}
