using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    public enum BonusType { BombRangeBonus, MaxBombsPlacedBonus}

    class Bonus : MapObject {
        public BonusType bonusType;
        public int bonusValue = 0;
        private Vector2 positionSpacing;

        public Bonus(Vector2 pos) : base(pos) {
            this.label = "Bonus";
            this.walkable = true;
            positionSpacing = GridManager.getTextureSpacing(Game1.textureManager.bonus.First());
            this.pos = new Vector2(pos.X + positionSpacing.X, pos.Y + positionSpacing.Y);
            switch (Randomizer.random.Next(0, 2)) {
                case 0:
                    this.bonusType = BonusType.BombRangeBonus;
                    this.texture = Game1.textureManager.bonus[0];
                    this.bonusValue = 1;
                    break;
                case 1:
                    this.bonusType = BonusType.MaxBombsPlacedBonus;
                    this.texture = Game1.textureManager.bonus[1];
                    this.bonusValue = 1;
                    break;
            }    
            setupBoundingBox();
        }
    }
}
