using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaBlaster.Class.Utils {
    public class AudioManager {

        public SoundEffect shoot;
        public SoundEffect boom;


        public AudioManager(ContentManager theContent) {
            loadAudio(theContent);
        }

        private void loadAudio(ContentManager theContent) {
        

        }
    }
}
