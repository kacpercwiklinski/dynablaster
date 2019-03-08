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
        public Texture2D mapBackground;


        //Object
        public List<Texture2D> player = new List<Texture2D>();
        public List<Texture2D> bomb = new List<Texture2D>();
        public List<Texture2D> bonus = new List<Texture2D>();
        public Texture2D block;
        public Texture2D wall;
        public Texture2D grass;
        public Texture2D dirt;

        public List<Texture2D> explosionCenter = new List<Texture2D>();
        public List<Texture2D> explosionHorizontalCenter = new List<Texture2D>();
        public List<Texture2D> explosionVerticalCenter = new List<Texture2D>();
        public List<Texture2D> explosionRightEnd = new List<Texture2D>();
        public List<Texture2D> explosionLeftEnd = new List<Texture2D>();
        public List<Texture2D> explosionTopEnd = new List<Texture2D>();
        public List<Texture2D> explosionBottomEnd = new List<Texture2D>();

        // Debug
        public Texture2D debugPoint;

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {

            //Object
            block = theContent.Load<Texture2D>("Object/MapObject/block/block");
            wall = theContent.Load<Texture2D>("Object/MapObject/block/wall");
            grass = theContent.Load<Texture2D>("Object/MapObject/block/grass");
            dirt = theContent.Load<Texture2D>("Object/MapObject/block/dirt");

            // Object
            player.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_0"));

            bonus.Add(theContent.Load<Texture2D>("Object/MapObject/Bonus/bombRangeBonus"));

            bomb.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/bomb_0"));
            bomb.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/bomb_1"));
            bomb.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/bomb_2"));


            explosionCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionCenter_4"));
            explosionCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionCenter_2"));
            explosionCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionCenter_1"));
            explosionCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionCenter_0"));

            explosionHorizontalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionHorizontalCenter_3"));
            explosionHorizontalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionHorizontalCenter_2"));
            explosionHorizontalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionHorizontalCenter_1"));
            explosionHorizontalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionHorizontalCenter_0"));

            explosionVerticalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionVerticalCenter_3"));
            explosionVerticalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionVerticalCenter_2"));
            explosionVerticalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionVerticalCenter_1"));
            explosionVerticalCenter.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionVerticalCenter_0"));

            explosionRightEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionRightEnd_3"));
            explosionRightEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionRightEnd_2"));
            explosionRightEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionRightEnd_1"));
            explosionRightEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionRightEnd_0"));

            explosionLeftEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionLeftEnd_3"));
            explosionLeftEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionLeftEnd_2"));
            explosionLeftEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionLeftEnd_1"));
            explosionLeftEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/ExplosionLeftEnd_0"));

            explosionTopEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionTopEnd_3"));
            explosionTopEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionTopEnd_2"));
            explosionTopEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionTopEnd_1"));
            explosionTopEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionTopEnd_0"));

            explosionBottomEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionBottomEnd_3"));
            explosionBottomEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionBottomEnd_2"));
            explosionBottomEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionBottomEnd_1"));
            explosionBottomEnd.Add(theContent.Load<Texture2D>("Object/MapObject/bomb/Explosion/explosionBottomEnd_0"));
            
            // Debug
            debugPoint = theContent.Load<Texture2D>("debugTextures/debugPoint");
        }
    }
}
