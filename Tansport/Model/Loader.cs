using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Loader : Vehicle
    {
        public Loader(Fuel fuel, double fuelConsumption,
            int fuelTankCapacity, double maxSpeed, double startSpeed)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            FuelTankCapacity = fuelTankCapacity;
            MaxSpeed = maxSpeed;
            StartSpeed = startSpeed;
            MaxPassedWay = fuelTankCapacity * 100 / fuelConsumption;

            CurrentFuelLevel = fuelTankCapacity;
            Type = "Loader";
        }
    }
}
