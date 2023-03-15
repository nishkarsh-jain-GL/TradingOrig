using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    public class CommanVariables
    {
        public static int input;
        public static int input2;
        public static int n;
        public static SqlCommand sqlCommand;
        public static SqlConnection con = new SqlConnection("server=DEL1-LHP-N70038;database=Trading;integrated security=true");
    }
}
