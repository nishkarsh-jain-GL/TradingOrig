using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public partial class CommanDashboard:IErrorException
    {
        public void valueError()
        {
            Console.WriteLine("Please enter an integer");
            Console.WriteLine("Please any Key to Continue");
            Console.ReadKey();
        }
        public void inputError()
        {
            Console.WriteLine("Input Error");
            Console.WriteLine("Please any Key to Continue");
            Console.ReadKey();
        }
        public void nullError()
        {
            Console.WriteLine("Input can't be null");
        }
    }
}
