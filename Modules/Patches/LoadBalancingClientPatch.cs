using ExitGames.Client.Photon.LoadBalancing;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rape.Modules.Patches
{
    [HarmonyPatch(typeof(LoadBalancingClient))]
    internal class LoadBalancingClientPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("")]
        private static void Prefix()
        {

        }
    }
}
