using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Utils {
    public class TextureManager {

        //Background
        public Texture2D splashScreenBackground;
        public Texture2D gameOverScreenBackground;
        public Texture2D mainMenuScreenBackground;
        public Texture2D background;

        //Object
        public Texture2D player;

        // Debug
        public Texture2D centerLine;
        public Texture2D point;
        public Texture2D curvePoint;

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {


        }
        
    }
}
