using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class CommanClass
    {
        public SqlConnection con = new SqlConnection("server=DEL1-LHP-N70038;database=Trading;integrated security=true");
        public static CommanClass loginDetails;
        public static CommanClass userObj;

        public static SqlCommand sqlCommand;
        public int ID;
        public string name;
        public string password;
        public string username;
        public double userBalance;
        public static int input;
        public static int input2;
        public static int n;
        public static int tableWidth = 150;

    }
}
