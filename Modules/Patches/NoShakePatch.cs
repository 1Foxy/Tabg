﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rape.Modules.Patches
{
    [HarmonyPatch(typeof(WobbleShake), "DoShake", null)]
    public static class NoShake
    {
        private static bool Prefix()
        {
            return !Config.Config.ScreenShake;
        }
    }
}
