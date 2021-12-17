using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class FactoryVehicles
    {
        public static Vehicle CreateVehicle(string type, Fuel fuel, double fuelConsumption,
                   int fuelTankCapacity, double maxSpeed, double startSpeed)
        {
            if (type == "Car")
            {
                return new Car(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Scooter")
            {
                return new Scooter(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Truck")
            {
                return new Truck(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Loader")
            {
                return new Loader(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Bus")
            {
                return new Bus(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Trolleybus")
            {
                return new Trolleybus(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Tram")
            {
                return new Tram(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Motorcycle")
            {
                return new Motorcycle(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "HorseDrawnCarriage")
            {
                return new HorseDrawnCarriage(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Bicycle")
            {
                return new Bicycle(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }

            if (type == "Tank")
            {
                return new Tank(fuel, fuelConsumption, fuelTankCapacity, maxSpeed, startSpeed);
            }
            return null;
        }
    }
}
