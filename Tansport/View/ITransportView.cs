using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public interface ITransportView : IView
    {
        void Start();
        void Stop();
        void CreateVehicle();
        void CreateFuels();
        void ShowAllVehicles();
        List<PictureBox> GetPictureBoxWithVehicle();
    }
}
