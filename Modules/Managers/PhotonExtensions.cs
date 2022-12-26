using Landfall.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TABGPhoton;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.LoadBalancing;
using UnityEngine;

namespace Rape.Modules.Managers
{
    internal class PhotonExtensions
    {               
        public static LoadBalancingClient balancingClient;

        public static PhotonLoadBalancingClient photonLoadBalancingClient;
        public static PhotonServerHandler m_photonServerHandler;
        public static PhotonServerConnector m_photonServerConnector;

        public static PhotonServerHandler GetServerHandler()
        {
            if (m_photonServerHandler == null)
                m_photonServerHandler = GameObject.FindObjectOfType<PhotonServerHandler>();
            if (!m_photonServerHandler)
                return null;
            return m_photonServerHandler;
        }
        public static PhotonServerConnector GetServerConnector()
        {
            if (m_photonServerConnector == null)
                m_photonServerConnector = GameObject.FindObjectOfType<PhotonServerConnector>();
            if (!m_photonServerConnector)
                return null;
            return m_photonServerConnector;
        }
    }
}
