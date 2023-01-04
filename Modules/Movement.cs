using Rape.Modules.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Rape.Modules
{
    internal class Movement
    {
        public static void Update()
        {              
            InfJump();
            Fly();
        }
        public static void InfJump()
        {
            if(Config.Config.InfJump)
            {
                if (Player.localPlayer != null)
                {
                    Player.localPlayer.stats.extraJumps = 1000;
                }
            }
        }
        public static void Fly()
        {
            if (Input.GetKey(KeyCode.Z) && Config.Config.Fly)
            {
                Rigidbody[] allRigs = Player.localPlayer.GetComponent<RigidbodyHolder>().bodyRigs;
                for (int j = 0; j < allRigs.Length; j++)
                {
                    allRigs[j].AddForce(Player.localPlayer.m_playerCamera.transform.forward * 5f, ForceMode.VelocityChange);
                }
            }
        }
    }
}
