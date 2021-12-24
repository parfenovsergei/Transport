using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;



namespace Model
{
    public class VehicleInForm
    {
        public Vehicle Vehicle { get; set; }
        public PictureBox PictureBox { get; set; }
        public VehicleInForm(Vehicle vehicle, PictureBox pictureBox)
        {
            Vehicle = vehicle;
            PictureBox = pictureBox;

            pictureBox.Image = GetImage();
            pictureBox.Visible = true;
        }

        public void Launch()
        {
            LaunchTask();
        }

        public void Stop()
        {
            Vehicle.Stop();
        }

        async private void LaunchTask()
        {
            Vehicle.Launch();
            while (Vehicle.CurrentFuelLevel > 0 && PictureBox.Left < 935)
            {
                PictureBox.Invoke((MethodInvoker)delegate
                {
                    Vehicle.Shift(300.0);
                    PictureBox.Left = 0 + (int)((Vehicle.PassedWay / 500.0) * 975.0);
                    
                });
                await Task.Delay(100);
            }
        }

        private Image GetImage()
        {
            if (Vehicle.Type == "Car")
            {
                return (Image)Properties.Resources.car;
            }
            else if (Vehicle.Type == "Scooter")
            {
                return (Image)Properties.Resources.Scooter;
            }
            else if (Vehicle.Type == "Truck")
            {
                return (Image)Properties.Resources.Truck;
            }
            else if (Vehicle.Type == "Loader")
            {
                return (Image)Properties.Resources.Loader;
            }
            else if (Vehicle.Type == "Bus")
            {
                return (Image)Properties.Resources.Bus;
            }
            else if (Vehicle.Type == "Trolleybus")
            {
                return (Image)Properties.Resources.Trolleybus;
            }
            else if (Vehicle.Type == "Tram")
            {
                return (Image)Properties.Resources.Tram;
            }
            else if (Vehicle.Type == "Motorcycle")
            {
                return (Image)Properties.Resources.Motorcycle;
            }
            else if (Vehicle.Type == "HorseDrawnCarriage")
            {
                return (Image)Properties.Resources.HorseDrawnCarriage;
            }
            else if (Vehicle.Type == "Bicycle")
            {
                return (Image)Properties.Resources.Bicycle;
            }
            else if (Vehicle.Type == "Tank")
            {
                return (Image)Properties.Resources.Tank;
            }
            return null;
        }
    }
}
