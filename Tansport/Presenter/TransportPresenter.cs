using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Model;

namespace Presenter
{
    public class TransportPresenter
    {
        private ITransportView _view;

        public TransportPresenter(ITransportView view)
        {
            _view = view;
        }

        public void ShowVehicles(object sender, EventArgs e)
        {
            List<VehicleInForm> vehicleInForms = new List<VehicleInForm>();
            var vehicles = ApplicationContext.Vehicles;
            var pictureBoxes = _view.GetPictureBoxWithVehicle();
            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicleInForms.Add(new VehicleInForm(vehicles[i], pictureBoxes[i]));
            }

            ApplicationContext.VehicleInForms = vehicleInForms;
        }

        public void Start()
        {
            ApplicationContext.VehicleInForms.ForEach(v => v.Launch());
        }

        public void Stop()
        {
            ApplicationContext.VehicleInForms.ForEach(v => v.Stop());
        }
    }
}
