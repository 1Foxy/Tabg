using ExitGames.Client.Photon.LoadBalancing;
using HarmonyLib;
using Landfall.Network;
using Rape.Modules;
using Rape.Modules.Managers;
using Rape.Modules.Patches;
using Rape.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Rape
{
    public class Cheat : MonoBehaviour
    {
        private Rect mainWRect = new Rect(5, 5, 500, 550);
        private bool MenuShown = true;
        public static int selectedTab = 0;
        private float lastCacheTime = Time.time + 5f;
        private float lastItemCache = Time.time + 1f;

        public Cheat()
        {
            Patches();
            AC_remove.FuckAC();
        }

        public void Keyhandler() {
            if (Input.GetKeyDown(KeyCode.Insert)) {
                MenuShown = !MenuShown;
            }
        }

       

        public void Update() {
            Keyhandler();

            if (Time.time >= lastCacheTime)
            {
                lastCacheTime = Time.time + 5f;

                Modules.Managers.PlayerManager.players = FindObjectsOfType<Player>();
                Modules.Managers.CarManager.vehicles = FindObjectsOfType<Car>();

                Render.mainCam = Camera.main;
            }
            if (Time.time >= lastItemCache)
            {
                lastItemCache = Time.time + 1f;

                Modules.Managers.PickupManager.droppedItems = FindObjectsOfType<Pickup>();
            }

            Misc.Update();
            Movement.Update();
            Carstuff.Update();

            if (Input.GetKeyDown(KeyCode.Mouse0) && Config.Config.magicBullet)
            {
                if (PlayerManager.players.Length > 0)
                {
                    foreach (Player player in PlayerManager.players)
                    {
                        if (player != Player.localPlayer && player != null)
                        {
                            foreach (ProjectileHit proj in FindObjectsOfType<ProjectileHit>())
                            {
                                player.m_playerDeath.TakeDamage(proj.transform.position, new Vector3());
                            }
                        }
                    }
                }
            } //detected 

        }

        public void OnGUI() {
            if (MenuShown) {
                mainWRect = GUILayout.Window(0, mainWRect, MainWindow, "GameKit");
            }
            
        }

        private void MainWindow(int id) { 
            GUILayout.BeginArea(new Rect(20, 70, 460, 500));
            switch (selectedTab)
            {
                case 0:
                    GUII.Index0();
                    break;
                case 1:
                    GUII.Index1();
                    break;
                case 2:
                    GUII.Index2();
                    break;
                case 3:
                    GUII.Index3();
                    break;
                case 4:
                    GUII.Index4();
                    break;
                default:
                    break;
            }
            GUILayout.EndArea();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Aimbot"))
            {
                selectedTab = 0;
            }
            if (GUILayout.Button("Melee"))
            {
                selectedTab = 1;
            }
            if (GUILayout.Button("Visuals"))
            {
                selectedTab = 2;
            }
            if (GUILayout.Button("Misc"))
            {
                selectedTab = 3;
            }
            if (GUILayout.Button("Beta"))
            {
                selectedTab = 4;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

        private void Patches()
        {
            var Rawr = new HarmonyLib.Harmony("fudhksbgsuhbj");
            Rawr.PatchAll();


        }
    }    
}
