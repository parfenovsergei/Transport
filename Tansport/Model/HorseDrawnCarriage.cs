﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HorseDrawnCarriage
        : Vehicle
    {
        public HorseDrawnCarriage(Fuel fuel, double fuelConsumption,
            int fuelTankCapacity, double maxSpeed, double startSpeed)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            FuelTankCapacity = fuelTankCapacity;
            MaxSpeed = maxSpeed;
            StartSpeed = startSpeed;

            CurrentFuelLevel = fuelTankCapacity;
            Type = "HorseDrawnCarriage";
        }
    }
}
