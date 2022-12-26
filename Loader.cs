using BepInEx;
using Rape.Modules;
using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Rape
{
    [BepInPlugin("Rape", "Rape", "69.420")]
    public class Plugin : BaseUnityPlugin
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole(int pid);

        public void Awake()
        {
            #region AllocConsole        
            AllocConsole(-1);
            var stdout = Console.OpenStandardOutput();
            var sw = new System.IO.StreamWriter(stdout, Encoding.Default);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.SetError(sw);
            #endregion

            Console.WriteLine("started required assemblies\n");
            try
            {
                gameObject.AddComponent<Cheat>();
                gameObject.AddComponent<Render>();

                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed Loading: assemblies" + "\n" + e);
            }

            Rape.Settings.Logger.Init();
        }
    }
}
