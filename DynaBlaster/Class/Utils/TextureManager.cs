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
        public List<Texture2D> playerDown = new List<Texture2D>();
        public List<Texture2D> playerLeft = new List<Texture2D>();
        public List<Texture2D> playerRight = new List<Texture2D>();
        public List<Texture2D> playerUp = new List<Texture2D>();
        public List<Texture2D> playerDead = new List<Texture2D>();
        public List<Texture2D> bomb = new List<Texture2D>();
        public List<Texture2D> bonus = new List<Texture2D>();
        public Texture2D block;
        public Texture2D wall;
        public Texture2D wall_left_top_corner;
        public Texture2D wall_right_top_corner;
        public Texture2D wall_top_0;
        public Texture2D wall_top_1;
        public Texture2D grass;
        public Texture2D grassShadow;
        public List<Texture2D> dirt = new List<Texture2D>();

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
            wall_left_top_corner = theContent.Load<Texture2D>("Object/MapObject/block/wall_left_top_corner");
            wall_right_top_corner = theContent.Load<Texture2D>("Object/MapObject/block/wall_right_top_corner");
            wall_top_0 = theContent.Load<Texture2D>("Object/MapObject/block/wall_top_0");
            wall_top_1 = theContent.Load<Texture2D>("Object/MapObject/block/wall_top_1");
            grass = theContent.Load<Texture2D>("Object/MapObject/block/grass");
            grassShadow = theContent.Load<Texture2D>("Object/MapObject/block/grassShadow");

            // Dirt textures
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_0"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_1"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_2"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_3"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_4"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_5"));
            dirt.Add(theContent.Load<Texture2D>("Object/MapObject/block/dirt_6"));

            // Object
            playerDown.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_down_0"));
            playerDown.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_down_1"));
            playerDown.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_down_2"));

            playerUp.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_up_0"));
            playerUp.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_up_1"));
            playerUp.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_up_2"));

            playerLeft.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_left_0"));
            playerLeft.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_left_1"));
            playerLeft.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_left_2"));

            playerRight.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_right_0"));
            playerRight.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_right_1"));
            playerRight.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_right_2"));

            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_0"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_1"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_2"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_3"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_4"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_5"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_6"));
            playerDead.Add(theContent.Load<Texture2D>("Object/MapObject/player/player_dead_7"));

            bonus.Add(theContent.Load<Texture2D>("Object/MapObject/Bonus/bombRangeBonus"));
            bonus.Add(theContent.Load<Texture2D>("Object/MapObject/Bonus/MaxBombsPlacedBonus"));

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
