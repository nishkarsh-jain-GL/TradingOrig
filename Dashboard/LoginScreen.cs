using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;

namespace Dashboard
{
    public partial class CommanDashboard
    {
        public static UserVariables loginDetails;
        public UserVariables loginWindow()
        {

            Console.Clear();
            loginDetails = new UserVariables();

            try
            {
                PrintLine();
                PrintRow("LOGIN WINDOW");
                PrintLine();
                Console.WriteLine("Enter User ID");
                loginDetails.ID = int.Parse(Console.ReadLine().Trim());
            password:
                Console.WriteLine("Enter Password");
                loginDetails.password = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(loginDetails.password))
                {
                    nullError();
                    goto password;
                }
            }
            catch (Exception e)
            {
                valueError();
                loginWindow();
            }

            return loginDetails;
        }

    }
}
