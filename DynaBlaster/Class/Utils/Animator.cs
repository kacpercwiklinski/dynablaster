using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynaBlaster.Class.Utils {
    public static class Animator {

        public static void animate(GameTime theTime, ref Texture2D texture, List<Texture2D> textures, float timeOffset, ref float currentTime, Boolean loop) {
            if (currentTime >= timeOffset) {
                int nextIdx = textures.IndexOf(texture) + 1;
                if (!loop) {
                    if (nextIdx > textures.Count() - 1) {
                        nextIdx = textures.Count() - 1;
                    }
                    if (textures.ElementAt(nextIdx) == textures.Last() || textures.ElementAt(nextIdx) != null) {
                        texture = textures.Last();
                    } else {
                        texture = textures.ElementAt(nextIdx);
                    }
                } else {
                    if (nextIdx > textures.Count() - 1) {
                        nextIdx = 0;
                    }
                    texture = textures.ElementAt(nextIdx);
                }
                currentTime = 0f;
            }
        }
    }
}
