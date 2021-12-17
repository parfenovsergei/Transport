using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vehicle
    {
        public string Type { get; set; }
        public Fuel Fuel { get; set; }
        public int Payload { get; set; } = 500;
        public double MaxSpeed { get; set; } = 0;
        public double StartSpeed { get; set; } = 0;
        public double CurrentSpeed { get; set; } = 0;
        public int FuelTankCapacity { get; set; } = 0;
        public double CurrentFuelLevel { get; set; } = 0;
        public double FuelConsumption { get; set; } = 0;
        public bool InMotion { get; set; } = false;
        public double PassedWay { get; set; } = 0;
        public DateTime Time { get; set; }

        public void Launch()
        {
            if (!InMotion)
            {
                if (CurrentFuelLevel > 0)
                {
                    //ShowMessage("The movement started.");
                    CurrentSpeed = StartSpeed;
                    InMotion = true;
                }
                else
                {
                    //ShowMessage("No fuel, the movement unpossible.");
                    InMotion = false;
                }
            }
            else
            {
                //ShowMessage("The vehicle is already moving.");
            }
        }

        public void Stop()
        {
            if (InMotion)
            {
                //ShowMessage("The vehicle is stopped");
                CurrentSpeed = 0;
                InMotion = false;
            }
            else
            {
                //ShowMessage("The vehicle has already been stopped.");
            }
        }

        public void Shift(double time)
        {
            if (PassedWay / 500 == 0.5)
                CurrentSpeed = MaxSpeed;

            double deltaWay = (int)(CurrentSpeed * time) / 1000.0;

            PassedWay += deltaWay;
            CurrentFuelLevel -= FuelConsumption / 100.0 * deltaWay;

            if (CurrentFuelLevel < 0)
            {
                CurrentFuelLevel = 0;
            }
        }

    }
}
