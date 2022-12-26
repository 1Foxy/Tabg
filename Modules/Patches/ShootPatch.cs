using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Rape.Modules.Patches
{
    
    [HarmonyPatch(typeof(Gun), "Shoot", null)]
    public static class ShootPatch
    {
        public static ProjectileHit hit;
        private static void Prefix(Gun __instance)
        {
            if (Config.Config.InfiniteAmmo)
            {
                int GetCurrentMaxAmmo = __instance.bulletsInMag;
                int BulletsLeft = __instance.bullets;
                            
                if(BulletsLeft < GetCurrentMaxAmmo)          
                {
                    __instance.bullets = GetCurrentMaxAmmo;
                
                }
            }
            if (Config.Config.RapidFire)
            {
                __instance.rateOfFire = 0.025f;
                __instance.currentFireMode = 2; // Full auto.
            }
            if (Config.Config.NoRecoil)
            {
                __instance.projectileRecoilMultiplier = 0f;
                UnityEngine.Object.Destroy(__instance.GetComponent<Recoil>());               
            }
            if (Config.Config.NoSpread)
            {
                __instance.extraSpread = 0f;
                __instance.hipSpreadValue = 0f;
            }
            if (Config.Config.NoReloadTime)
            {
                __instance.reloadTime = 0f;
                __instance.ReloadEventDelayNumber = 0f;
               
            }
            if (Config.Config.FullAuto)
            {
               bool checkSingleFire = __instance.hasSingleFire;
               bool checkBurstFire = __instance.hasBurst;

                bool wasSingleFire = false;
                bool wasBurstFire = false;

                if (checkSingleFire == true)
                {
                    wasSingleFire = true;
                    checkSingleFire = false;
                }

                if (checkBurstFire == true)
                {
                    wasBurstFire = true;
                    checkBurstFire = false;
                }
                __instance.hasFullAuto = true;
                __instance.currentFireMode = 2;
            }    
            if (Config.Config.InstantFire)
            {
                __instance.rateOfFire = 0.001f; //200 cause of the lag spikes its causing
            }
            if (Config.Config.InstantKill)
            {
                foreach (ProjectileHit proj in UnityEngine.Object.FindObjectsOfType<ProjectileHit>())
                {
                    proj.damage = float.MaxValue;
                    proj.goThroughAll = true;
                }
            }
        }
    }
}
