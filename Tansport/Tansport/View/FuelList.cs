using System;
using System.Collections.Generic;
using System.Windows.Forms;
using View;
using Presenter;

namespace Tansport.View
{
    public partial class FuelList : Form, IFuelView
    {
        private FuelPresenter _presenter;
        public FuelList()
        {
            InitializeComponent();
            _presenter = new FuelPresenter(this);
            _presenter.SetStartFuel();
        }

        public List<string> GetListFuelNames()
        {
            List<string> fuels = new List<string>();
            if (checkBoxGas.Checked)
            {
                fuels.Add(checkBoxGas.Text);
            }

            if (checkBoxDiesel.Checked)
            {
                fuels.Add(checkBoxDiesel.Text);
            }

            if (checkBoxPetrol.Checked)
            {
                fuels.Add(checkBoxPetrol.Text);
            }

            if (checkBoxElectricity.Checked)
            {
                fuels.Add(checkBoxElectricity.Text);
            }

            if (checkBoxPhysicalStrength.Checked)
            {
                fuels.Add(checkBoxPhysicalStrength.Text);
            }

            return fuels;
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            _presenter.Submit();
        }

        public void SetFuels(List<string> fuelNames)
        {
            if (fuelNames.IndexOf("Gas") != -1)
            {
                checkBoxGas.Checked = true;
            }

            if (fuelNames.IndexOf("Diesel") != -1)
            {
                checkBoxDiesel.Checked = true;
            }

            if (fuelNames.IndexOf("Petrol") != -1)
            {
                checkBoxPetrol.Checked = true;
            }

            if (fuelNames.IndexOf("Electricity") != -1)
            {
                checkBoxElectricity.Checked = true;
            }

            if (fuelNames.IndexOf("Physical strenth") != -1)
            {
                checkBoxPhysicalStrength.Checked = true;
            }
        }
    }
}
