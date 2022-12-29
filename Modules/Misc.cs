using Landfall.Network;
using Rape.Modules.Managers;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Dreamteck.Splines.IO.SVG;

namespace Rape.Modules
{
    internal class Misc
    {
        


        public static void Update()
        {
            if (Config.Config.FastHeal)
            {
                FastHeal();
            }

            //if (Config.Config.godmode)
            //{
            //    if (Player.localPlayer != null)
            //    {

            //        Player.localPlayer.stats.healthAdd = float.MaxValue;
            //        Player.localPlayer.stats.healingMultipier = float.MaxValue;
            //        Player.localPlayer.stats.healthMultiplier = float.MaxValue;

            //    }
            //}

         
        }

        public static void FastHeal()
        {
            Player.localPlayer.stats.healingSpeedMultipier = float.MaxValue;
        }
        public static void SkyDive()
        {
            Skydive(Player.localPlayer.m_playerCamera.transform.forward);
        }
        private static void Skydive(Vector3 direction)
        {
            Skydiving dive = Player.localPlayer.gameObject.GetComponent<Skydiving>();
            if (dive == null)
                dive = Player.localPlayer.gameObject.AddComponent<Skydiving>();
            dive.Launch(direction * 10f);
        }
        public static void LaunchOff()
        {
            Skydiving dive = Player.localPlayer.gameObject.GetComponent<Skydiving>();
            if (dive == null)
            {
                Player.localPlayer.gameObject.AddComponent<Skydiving>();
            }

            dive.Launch(Vector3.up); 
        }



        public static void test()
        {
            string[] str;
            str = new string[3] { "Fuck", "The", "BLM" };



            NetworkManager.Networkplayer.ShowChatMessage("black");
        }

    }
}
