using ExitGames.Client.Photon.LoadBalancing;
using Landfall.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Rape.Modules.Managers
{
    public static class PlayerManager
    {
        public static Player[] players;
        
        public static Player LocalPlayer { get { return Player.localPlayer; } }

        public static float DistanceTo(Transform transform)
        {
            return Vector3.Distance(LocalPlayer.GetPosition(), transform.position);
        }

        public static Vector3 GetPosition(this Player player)
        {
            var pHip = LocalPlayer.GetComponentInChildren<Hip>();
            if (pHip)
                return pHip.transform.position;

            var pTorso = LocalPlayer.GetComponentInChildren<Torso>();
            if (pTorso)
                return pTorso.transform.position;

            return Vector3.zero;
        }

        public static float DistanceTo(Player player)
        {
            Hip pHip = player.GetComponentInChildren<Hip>();
            if (!pHip)
                return Vector3.Distance(LocalPlayer.GetPosition(), player.transform.position);
            return Vector3.Distance(LocalPlayer.GetPosition(), player.GetComponentInChildren<Hip>().transform.position);
        }

    }
}
