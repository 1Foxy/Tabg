using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rape.Settings
{
    internal class AC_remove
    {
        public static void FuckAC()
        {
            CodeStage.AntiCheat.Detectors.InjectionDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();
           
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.ActDetectorBase>());
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.InjectionDetector>());
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector>());
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.SpeedHackDetector>());
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>());
            GameObject.Destroy(Object.FindObjectOfType<CodeStage.AntiCheat.Detectors.WallHackDetector>());

        }
    }
}
