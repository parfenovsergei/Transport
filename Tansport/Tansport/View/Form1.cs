using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using Presenter;
using Transport.View;

namespace Tansport.View
{
    public partial class Form1 : Form, IShowLogsView
    {
        private List<RadioButton> radioButtons;
        private ShowLogsPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            radioButtons = new List<RadioButton>();
            radioButtons.Add(radioButton1);
            radioButtons.Add(radioButton2);
            radioButtons.Add(radioButton3);
            radioButtons.Add(radioButton4);
            radioButtons.Add(radioButton5);

            radioButtons.ForEach(rb => rb.Visible = false);
            _presenter = new ShowLogsPresenter(this);
        }
        public void SetVehicles(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                radioButtons[i].Visible = true;
                radioButtons[i].Text = names[i];
            }
        }

        public List<string> GetExportTypes()
        {
            List<string> exportTypes = new List<string>();


            if (wordCheckBox.Checked == true)
            {
                exportTypes.Add("word");
            }

            if (excelCheckBox.Checked == true)
            {
                exportTypes.Add("excel");
            }

            if (windowsCheckBox.Checked == true)
            {
                exportTypes.Add("window");
            }

            return exportTypes;
        }

        public int GetIndexVehicles()
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Checked == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public void OpenLog(List<string> logs)
        {
            Logs logsForm = new Logs(logs);
            logsForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.Submit();
        }
    }
}
