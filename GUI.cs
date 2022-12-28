using HarmonyLib;
using Landfall.Network;
using Landfall.TABG.UI.MainMenu;
using Rape.Modules;
using Rape.Modules.Managers;
using Rape.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Rape
{
    internal class GUII
    {
        public static void Index0()
        {
            GUILayout.BeginVertical("AIM", GUI.skin.box);
            GUILayout.Space(20f);
            Config.Config.magicBullet = GUILayout.Toggle(Config.Config.magicBullet, "Magic Bullet");
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Weapon Modifications", GUI.skin.box);
            GUILayout.Space(20f);
            Config.Config.InfiniteAmmo = GUILayout.Toggle(Config.Config.InfiniteAmmo, "Unlimited Ammo");
            Config.Config.RapidFire = GUILayout.Toggle(Config.Config.RapidFire, "Rapid Fire");
            Config.Config.NoRecoil = GUILayout.Toggle(Config.Config.NoRecoil, "NoRecoil");
            Config.Config.NoSpread = GUILayout.Toggle(Config.Config.NoSpread, "NoSpread");
            Config.Config.NoReloadTime = GUILayout.Toggle(Config.Config.NoReloadTime, "No Reload Time");
            Config.Config.InstantFire = GUILayout.Toggle(Config.Config.InstantFire, "Instant Fire (Buggy)");
            Config.Config.FullAuto = GUILayout.Toggle(Config.Config.FullAuto, "AutoFire");
            Config.Config.InstantKill = GUILayout.Toggle(Config.Config.InstantKill, "Insta Kill");
            GUILayout.EndVertical();
        }
        public static void Index1()
        {
            GUILayout.BeginVertical("MELEE", GUI.skin.box);
            GUILayout.Space(20f);
            Config.Config.InstantMelee = GUILayout.Toggle(Config.Config.InstantMelee, "Instant Melee");
            Config.Config.InstantKill_ = GUILayout.Toggle(Config.Config.InstantKill_, "Insta Kill");
            Config.Config.swingTime = GUILayout.Toggle(Config.Config.swingTime, "Fast Swing Time"); 
            GUILayout.EndVertical();

        }
        public static void Index2()
        {
            GUILayout.BeginVertical("Render", GUI.skin.box);
            GUILayout.Space(20f);

            GUILayout.Label($"FOV: {Mathf.Floor(Camera.main.fieldOfView)}");
            Camera.main.fieldOfView = GUILayout.HorizontalSlider(Camera.main.fieldOfView, 0f, 360f);
            Config.Config.RemoveShake = GUILayout.Toggle(Config.Config.RemoveShake, "Remove Shake");

            GUILayout.EndVertical();
            GUILayout.BeginVertical("BOX ESP", GUI.skin.box);
            
            GUILayout.Space(20f);
            Config.Config.playerBox = GUILayout.Toggle(Config.Config.playerBox, "Player Box");
            Config.Config.Vehicle = GUILayout.Toggle(Config.Config.Vehicle, "Vehicle");
            Config.Config.playerName = GUILayout.Toggle(Config.Config.playerName, "Player Name");
            Config.Config.crosshair = GUILayout.Toggle(Config.Config.crosshair, "Crosshair");
            Config.Config.item = GUILayout.Toggle(Config.Config.item, "Item");
            Config.Config.LaunchPed = GUILayout.Toggle(Config.Config.LaunchPed, "LaunchPad");

            GUILayout.EndVertical();
            
        }
        public static void Index3()
        {
            GUILayout.BeginVertical("MISC", GUI.skin.box);
            GUILayout.Space(20f);
            Config.Config.FastHeal = GUILayout.Toggle(Config.Config.FastHeal, "FastHeal");
            if (GUILayout.Button("Launch off")) { Misc.LaunchOff(); }
            if (GUILayout.Button("SkyDive")) { Misc.SkyDive(); }
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Movement", GUI.skin.box);
            GUILayout.Space(20f);
            Config.Config.InfJump = GUILayout.Toggle(Config.Config.InfJump, "Inf Jump");
            if (Player.localPlayer != null) {
                GUILayout.Label($"SpeedHack: {Mathf.Floor(Player.localPlayer.stats.movementSpeedAdd)}");
                Player.localPlayer.stats.movementSpeedAdd = GUILayout.HorizontalSlider(Player.localPlayer.stats.movementSpeedAdd, 0f, 30f);

                GUILayout.Label($"Jump Boost: {Mathf.Floor(Player.localPlayer.stats.jumpMultiplier)}");
                Player.localPlayer.stats.jumpMultiplier = GUILayout.HorizontalSlider(Player.localPlayer.stats.jumpMultiplier, 1f, 30f);
            } else { GUILayout.Label("Waiting For LocalPlayer..."); }
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Vehicles", GUI.skin.box);
            GUILayout.Space(20f);

            GUILayout.Label($"Car BaseForce: {Mathf.Floor(Config.Config.DeceptionBossCarBaseForce)}");
            Config.Config.DeceptionBossCarBaseForce = GUILayout.HorizontalSlider(Config.Config.DeceptionBossCarBaseForce, 1.8f, 30f);

            GUILayout.Label($"Bike BaseForce: {Mathf.Floor(Config.Config.BikeBaseForce)}");
            Config.Config.BikeBaseForce = GUILayout.HorizontalSlider(Config.Config.BikeBaseForce, 10, 30f);

            GUILayout.Label($"Motor BaseForce: {Mathf.Floor(Config.Config.MotorCycleBaseForce)}");
            Config.Config.MotorCycleBaseForce = GUILayout.HorizontalSlider(Config.Config.MotorCycleBaseForce, 4, 30f);

            Config.Config.MakeLowRiderDeceptionBossCar = GUILayout.Toggle(Config.Config.MakeLowRiderDeceptionBossCar, "LowRider Car");
            Config.Config.MakeLowRiderBike = GUILayout.Toggle(Config.Config.MakeLowRiderBike, "LowRider Bike");
            Config.Config.MakeLowRiderMotorCycle = GUILayout.Toggle(Config.Config.MakeLowRiderMotorCycle, "LowRider Motor");

            GUILayout.EndVertical();
        }

        public static void Index4()
        {
            GUILayout.BeginVertical("MISC", GUI.skin.box);
            GUILayout.Space(20f);

            if (GUILayout.Button("Bypass Ban"))
            {
                try
                {
                    PhotonExtensions.balancingClient.UserId = "rape";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(PhotonExtensions.balancingClient.UserId.ToString());
                    Console.WriteLine(ex.Message);
                    throw;
                }
                

                Console.WriteLine(PhotonExtensions.balancingClient.UserId.ToString()); //logs new userId to console
            }
            if (GUILayout.Button("DDOS server"))
            {
                //PhotonExtensions.photonLoadBalancingClient.NickName = "Fuck Niggers";
                //PhotonExtensions.photonLoadBalancingClient.PhotonServerHandler.EndGame(playerBase.GroupIndex);
            }
            if(GUILayout.Button("ACKILLER"))
            {
                AntiCheatClient.Deinitialize();
                AC_remove.FuckAC();
            }

            GUILayout.EndVertical();
        }
    }
}
