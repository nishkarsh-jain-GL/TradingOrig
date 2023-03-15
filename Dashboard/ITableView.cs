using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    interface ITableView
    {
        void PrintLine();
        void PrintRow(params string[] columns);
    }
}
