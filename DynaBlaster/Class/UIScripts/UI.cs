using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.UiScripts {
    public class UI {

        public static Vector2 barPos = new Vector2(Game1.WIDTH / 2 - 448, 0);
            
        Bar bar;

        public UI() {
            this.bar = new Bar(barPos);
        }
        
        public void Update(GameTime gameTime) {
            bar.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            bar.Draw(spriteBatch);
        }
    }
}
