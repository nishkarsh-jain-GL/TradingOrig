using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public partial class CommanDashboard
    {
        public void userPortal()
        {
            PrintLine();
            PrintRow("USER PORTAL");
            PrintLine();
            Console.WriteLine("Press 1 to Buy Stock");
            Console.WriteLine("Press 2 to Sell Stock");
            Console.WriteLine("Press 3 for View Balance");
            Console.WriteLine("Press 4 To ADD BALANCE");
            Console.WriteLine("Press 5 To Withdraw Money");
            Console.WriteLine("Press 6 To view MY Stocks");
            Console.WriteLine("Press 7 To LogOut");


        }
    }
}
