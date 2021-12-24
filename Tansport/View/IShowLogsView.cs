using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IShowLogsView : IView
    {
        void SetVehicles(List<string> names);
        List<string> GetExportTypes();
        int GetIndexVehicles();
        void OpenLog(List<string> logs);
    }
}
