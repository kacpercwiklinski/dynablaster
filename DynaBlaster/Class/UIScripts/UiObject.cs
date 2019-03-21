using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.UiScripts {
    public abstract class UiObject {

        public Vector2 position;
        public Texture2D texture;

        public UiObject(Vector2 position) {
            this.position = position;
        }

        public UiObject() {
            this.position = Vector2.Zero;
        }

        public virtual void Update(GameTime gameTime) { } 
        public virtual void Draw(SpriteBatch spriteBatch) { } 
    }
}
