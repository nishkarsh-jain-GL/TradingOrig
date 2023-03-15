using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ConnectionString
    {
        public SqlConnection con = new SqlConnection("server=DEL1-LHP-N70038;database=Trading;integrated security=true");
    }
}
