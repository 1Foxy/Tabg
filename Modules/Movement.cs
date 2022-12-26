using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rape.Modules
{
    internal class Movement
    {
        public static void Update()
        {
            if (Config.Config.InfJump)
            {
                InfJump();
            }

        }
        public static void InfJump()
        {
            if (Player.localPlayer != null)
            {
                Player.localPlayer.stats.extraJumps = 1000;
            }
        }
    }
}
