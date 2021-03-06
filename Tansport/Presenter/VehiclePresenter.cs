using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Model;

namespace Presenter
{
    public class VehiclePresenter
    {
        private IVehicleView _view;
        public VehiclePresenter(IVehicleView view)
        {
            _view = view;
            List<string> fuels = new List<string>();
            foreach (var fuel in ApplicationContext.Fuels)
            {
                fuels.Add(fuel.Name);
            }

            _view.SetFuel(fuels);
        }

        public void DisplayWindow()
        {
            _view.NextPage(ApplicationContext.Vehicles.Count);
        }

        public void Submit()
        {
            ApplicationContext.Vehicles.Add(FactoryVehicles.CreateVehicle(
                _view.GetTypeVehicle(),
                ApplicationContext.Fuels.Where(f => f.Name == _view.GetFuelNameVehicle()).FirstOrDefault(),
                _view.GetFuelConsumptionVehicle(),
                _view.GetFuelTankCapacityVehicle(),
                _view.GetMaxSpeedVehicle() / 3.6,
                _view.GetStartSpeedVehicle() / 3.6
            ));

            if (ApplicationContext.Vehicles.Count == 5)
            {
                _view.Close();
                return;
            }

            _view.NextPage(ApplicationContext.Vehicles.Count);
        }

        public string[] GetTypeByIndex(int index)
        {
            List<string> result = new List<string>();
            result.AddRange(new string[] { "Car", "Scooter", "Truck", "Loader", "Bus", "Trolleybus", "Tram", "Motorcycle", "HorseDrawnCarriage", "Bicycle", "Tank" });
            switch (index)
            {
                case 0:
                    result.Remove("Tram");
                    result.Remove("Trolleybus");
                    break;

                case 1:
                    result.Remove("Bicycle");
                    result.Remove("Tank");
                    result.Remove("HorseDrawnCarriage");
                    result.Remove("Scooter");
                    result.Remove("Tram");
                    break;

                case 3:
                    result = new List<string>(new string[] { "Tram" });
                    break;

                case 4:
                    result.Remove("Tram");
                    result.Remove("Trolleybus");
                    break;

                default:
                    result.Remove("Bicycle");
                    result.Remove("Tank");
                    result.Remove("Trolleybus");
                    result.Remove("HorseDrawnCarriage");
                    result.Remove("Tram");
                    result.Remove("Scooter");
                    break;
            }

            return result.ToArray();
        }
    }
}
