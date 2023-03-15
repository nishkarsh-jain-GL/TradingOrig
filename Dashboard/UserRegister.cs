using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Dashboard;
namespace Dashboard
{
    public partial class CommanDashboard
    {
        public UserVariables userForm()
        {

            Console.Clear();
            loginDetails = new UserVariables();
            PrintLine();
            PrintRow("Create Account");
            PrintLine();
            Console.WriteLine("Enter User ID:");
            loginDetails.ID = Convert.ToInt32(Console.ReadLine().Trim());

        nameinput:
            Console.WriteLine("Enter Name:");
            loginDetails.name = Console.ReadLine().Trim();
            if (String.IsNullOrWhiteSpace(loginDetails.name))
            {
                nullError();
                goto nameinput;
            }
        passwordinput:
            Console.WriteLine("Enter Password:");
            loginDetails.password = Console.ReadLine().Trim();
            if (String.IsNullOrWhiteSpace(loginDetails.password))
            {
                nullError();
                goto passwordinput;
            }
            loginDetails.userBalance = 0;

            return loginDetails;

        }
    }
}
