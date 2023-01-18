using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.UI;


namespace TrafficModSpawner

{
    public class TrafficModSpawner : Script
    {
        public TrafficModSpawner()
        {
            base.Tick += OnTick;
        }

        HashSet<int> processedVehicles = new HashSet<int>();
        Random random = new Random();

        private void OnTick(object sender, EventArgs e)
        {
            Ped character = Game.Player.Character;
            Vehicle[] nearbyVehicles = World.GetNearbyVehicles(character.Position, 1000f, new Model[]
            {
        VehicleHash.Buffalo2,
        VehicleHash.Blista,
            });

            foreach (Vehicle vehicle in nearbyVehicles)
            {
                if (processedVehicles.Contains(vehicle.Handle))
                    continue;

                int chance = random.Next(1, 3);
                if (vehicle.Model == VehicleHash.Buffalo2)
                {
                    if (chance == 1)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 0, 1, true);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 1, 1, true);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 2, 1, true);
                    }
                    else if (chance == 2)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 2, 3, true);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 3, 2, true);
                        Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 4, 1, true);
                    }
                }
                else if (vehicle.Model == VehicleHash.Blista)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
                    Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 0, 4, true);
                    Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 1, 1, true);
                    Function.Call(Hash.SET_VEHICLE_MOD, vehicle, 2, 1, true);
                }
                processedVehicles.Add(vehicle.Handle);
            }
        }
    }
}