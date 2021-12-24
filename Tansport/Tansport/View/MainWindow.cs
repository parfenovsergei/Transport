using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Presenter;
using View;

namespace Tansport.View
{
    public partial class MainWindow : Form, ITransportView
    {
        //private DateTime timeSinceStart, timeOfMoveAllVehicles, timeOfStopVehicles;
        private Stopwatch timeSinceStart = new Stopwatch();
        private bool motionFlag;
        private int vehicleCount = 0;
        private TransportPresenter _presenter;
        public MainWindow()
        {
            InitializeComponent();
            _presenter = new TransportPresenter(this);
        }
        private void showLogsButton_Click(object sender, EventArgs e)
        {
            /* ShowLogs showLogs = new ShowLogs();
             showLogs.ShowDialog();*/
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
        private void createListOfFuelButton_Click(object sender, EventArgs e)
        {
            FuelList fuelList = new FuelList();
            fuelList.ShowDialog();
        }

        private void createVehiclesButton_Click(object sender, EventArgs e)
        {
            VehiclesList vehicleList = new VehiclesList();
            vehicleList.FormClosed += _presenter.ShowVehicles;
            vehicleList.ShowDialog();
            //подсчет кол-ва тс в данный момент
            for (int i = 0; i < Model.ApplicationContext.VehicleInForms.Count; i++)
            {
                if(Model.ApplicationContext.VehicleInForms[i].PictureBox.Visible)
                {
                    ++vehicleCount;
                    labelVehicleCount.Text = vehicleCount.ToString();
                }
            }
            vehicleCount = 0;
        }

        public List<PictureBox> GetPictureBoxWithVehicle()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);
            pictureBoxes.Add(pictureBox10);

            return pictureBoxes;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            motionFlag = true;
            if (!timeSinceStart.IsRunning)
                timeSinceStart.Start();
            _presenter.Start();
            /*while (true)
            {
                labelTimeSinceStart.Text = timeSinceStart.Elapsed.ToString();
                await Task.Delay(1);
            }*/
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            motionFlag = false;
            _presenter.Stop();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void CreateVehicle()
        {
            throw new NotImplementedException();
        }

        public void CreateFuels()
        {

        }

        public void ShowAllVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
