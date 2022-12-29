using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rape.Modules.Patches
{
    [HarmonyPatch(typeof(MeleeWeapon))]
    public static class AttackPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Attack")]
        private static void Prefix(MeleeWeapon __instance)
        {
            if (Config.Config.InstantMelee && __instance != null)
            {
                __instance.cd = 0f;
            }
            if (Config.Config.InstantKill_ && __instance != null)
            {
                __instance.damageOnHit = 99999f;
            }
            if (Config.Config.swingTime && __instance != null)
            {
                __instance.swingTime = 0.05f;
            }
            
        }
    }
}
