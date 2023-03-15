using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard;
namespace AdminDashboard
{
    public partial class AdminDashboardScreen : CommanDashboard
    {
        public void adminPortal()
        {
            Console.Clear();
            PrintLine();
            PrintRow("ADMIN PORTAL");
            PrintLine();
            Console.WriteLine("Press 1 for Publish Stock");
            Console.WriteLine("Press 2 to Delete Stock");
            Console.WriteLine("Press 3 to Generate Stock report");
            Console.WriteLine("Press 4 to Calculate Transaction Fee");
            Console.WriteLine("Press 5 to Generate Trading Report");
            Console.WriteLine("Press 6 to LogOut");
        }
    }
}

