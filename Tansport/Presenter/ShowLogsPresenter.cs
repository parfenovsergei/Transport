using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using View;
using ApplicationContext = Model.ApplicationContext;

namespace Presenter
{
    public class ShowLogsPresenter
    {
        private IShowLogsView _view;
        public ShowLogsPresenter(IShowLogsView view)
        {
            _view = view;
            List<string> names = new List<string>();
            foreach (var vehicle in ApplicationContext.Vehicles)
            {
                names.Add($"{vehicle.Type}");
            }

            _view.SetVehicles(names);
        }

        public void Submit()
        {
            var index = _view.GetIndexVehicles();
            if (index == -1)
            {
                return;
            }

            var vehicle = ApplicationContext.Vehicles[index];
            string path = ".";

            if (_view.GetExportTypes().Contains("word") || _view.GetExportTypes().Contains("excel"))
            {
                FolderBrowserDialog DirDialog = new FolderBrowserDialog();
                DirDialog.Description = "Selecting a directory";
                DirDialog.SelectedPath = @"C:\";

                if (DirDialog.ShowDialog() == DialogResult.OK)
                {
                    path = DirDialog.SelectedPath;
                    Console.WriteLine(path);
                }
            }

            if (_view.GetExportTypes().Contains("word"))
            {
                System.IO.File.WriteAllLines($@"{path}\Log_{index}Vehicle.doc",
                    vehicle.LogString.ToArray());
            }

            if (_view.GetExportTypes().Contains("window"))
            {
                _view.OpenLog(vehicle.LogString);
            }

            if (_view.GetExportTypes().Contains("excel"))
            {
                var newXLFile = WorkBook.Create(ExcelFileFormat.XLSX);
                newXLFile.Metadata.Title = "Log_Vehicle";
                var newWorkSheet = newXLFile.CreateWorkSheet($"{index}Vehicle");
                for (int i = 1; i <= vehicle.LogString.Count; i++)
                {
                    //write the Dynamic value in one row
                    List<string> row = vehicle.LogString[i - 1].Split('#').ToList();
                    newWorkSheet["A" + i].Value = row[0];
                    //write the Dynamic value in another row
                    newWorkSheet["B" + i].Value = row[1];
                }

                newXLFile.SaveAs($@"{path}\Log_{index}Vehicle.xlsx");
            }
        }


    }
}
