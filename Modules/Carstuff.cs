using Rape.Modules.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static VehicleSpawn;

namespace Rape.Modules
{
    internal class Carstuff
    {
        public static void Update()
        {
            GameObject obj = GameObject.Find("DeceptionBossCar");
            Car Script = obj.GetComponent<Car>();

            GameObject obj1 = GameObject.Find("Bike");
            Car Script1 = obj1.GetComponent<Car>();

            GameObject obj2 = GameObject.Find("MotorCycle");
            Car Script2 = obj2.GetComponent<Car>();

            if (Script.driverSeat.occupant = PlayerManager.LocalPlayer.transform) //DeceptionBossCar
            {
                Script.baseForce = (float)Config.Config.DeceptionBossCarBaseForce;
            }

            if (Script1.driverSeat.occupant = PlayerManager.LocalPlayer.transform) //Bike
            {
                Script1.baseForce = (float)Config.Config.BikeBaseForce;
            }

            if (Script2.driverSeat.occupant = PlayerManager.LocalPlayer.transform) //MotorCycle
            {
                Script2.baseForce = (float)Config.Config.MotorCycleBaseForce;
            }

            if (Config.Config.MakeLowRiderDeceptionBossCar) //DeceptionBossCar
            {
                Script.mainRig.mass = 100000;
            }
            else
            {
                Script.mainRig.mass = 10000;
            }

            if (Config.Config.MakeLowRiderBike) //Bike
            {
                Script1.mainRig.mass = 100000;
            }
            else
            {
                Script1.mainRig.mass = 10000;
            }

            if (Config.Config.MakeLowRiderMotorCycle) //MotorCycle
            {
                Script2.mainRig.mass = 100000;
            }
            else
            {
                Script2.mainRig.mass = 10000;
            }

            //Console.WriteLine(Script.recievedPosition.ToString());
            //Console.WriteLine(Script.recievedRotation.ToString());

        }
    }
}
