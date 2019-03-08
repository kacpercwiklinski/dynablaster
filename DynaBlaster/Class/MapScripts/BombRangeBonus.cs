using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DynaBlaster.Class.MapScripts {
    class BombRangeBonus : Bonus {
        public BombRangeBonus(Vector2 pos) : base(pos) {
            this.bonusType = BonusType.BombRangeBonus;
            this.bonusValue = 1;
        }
    }
}
