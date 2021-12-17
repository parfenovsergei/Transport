using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IVehicleView : IView
    {
        string GetTypeVehicle();
        string GetFuelNameVehicle();
        double GetFuelConsumptionVehicle();
        int GetFuelTankCapacityVehicle();
        int GetMaxSpeedVehicle();
        int GetStartSpeedVehicle();
        void SetFuel(List<string> fuels);
        void NextPage(int index);
    }
}
