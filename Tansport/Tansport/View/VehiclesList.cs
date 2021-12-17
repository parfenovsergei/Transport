using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;
using Presenter;

namespace Tansport.View
{
    public partial class VehiclesList : Form, IVehicleView
    {
        private VehiclePresenter _presenter;
        public VehiclesList()
        {
            InitializeComponent();
            _presenter = new VehiclePresenter(this);
            _presenter.DisplayWindow();
        }

        public string GetTypeVehicle()
        {
            return comboBoxType.Text;
        }

        public string GetFuelNameVehicle()
        {
            return comboBoxFuelType.Text;
        }
        public int GetFuelTankCapacityVehicle()
        {
            return (int)numericUpDownFuelTankCapacity.Value;
        }

        public double GetFuelConsumptionVehicle()
        {
            return (double)numericUpDownFuelConsumption.Value;
        }

        public int GetStartSpeedVehicle()
        {
            return (int)numericUpDownStartSpeed.Value;
        }

        public int GetMaxSpeedVehicle()
        {
            return (int)numericUpDownMaxSpeed.Value;
        }
        public void NextPage(int index)
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(_presenter.GetTypeByIndex(index));
            numericUpDownFuelConsumption.Value = 0;
            numericUpDownFuelTankCapacity.Value = 0;
            numericUpDownMaxSpeed.Value = 0;
            numericUpDownStartSpeed.Value = 0;

            titleLabel.Text = $"You entered data about {index} out of 5 vehicles";
        }

        public void SetFuel(List<string> fuels)
        {
            comboBoxFuelType.Items.AddRange(fuels.ToArray());
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                _presenter.Submit();
            }
        }

        private void numericUpDownStartSpeed_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDownMaxSpeed.Value < numericUpDownStartSpeed.Value)
            {
                e.Cancel = true;
                numericUpDownStartSpeed.Focus();
                errorProvider.SetError(numericUpDownStartSpeed, "Maximum speed less starting speed");
            }
            else
            {
                e.Cancel = false;
                errorProvider.Clear();
            }
        }

        private void comboBoxFuelType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxFuelType.Text))
            {
                e.Cancel = true;
                comboBoxFuelType.Focus();
                errorProvider.SetError(comboBoxFuelType, "Select the fuel type");
            }
            else
            {
                e.Cancel = false;
                errorProvider.Clear();
            }
        }
    }
}
