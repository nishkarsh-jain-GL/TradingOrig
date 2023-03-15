using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Dashboard
{
    public partial class CommanDashboard:CommanVariables
    {
        public void userLoginPage()
        {
            Console.Clear();
            PrintLine();
            PrintRow("USER");
            PrintLine();
            Console.WriteLine(" Press 1 To create new Account");
            Console.WriteLine(" Press 2 To login INTO EXISTING Account");
            Console.WriteLine(" Press 3 to GoBack:");
        }
    }
}
