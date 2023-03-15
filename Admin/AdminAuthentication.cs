using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Admin
{
    class AdminAuthentication
    {
        public static bool authenticate(UserVariables obj)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Admin where adminID=" + obj.ID+ " and adminPwd='" + obj.password + "'", CommanVariables.con);
            da.Fill(ds, "Login_Details");
            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
            if (count == 1)
            {
                Console.WriteLine("Authentication Successfully");
                Console.ReadKey();
                return true;

            }
            else
            {
                Console.WriteLine("Authentication Failed");
                Console.ReadKey();
                return false;
            }

        }
    }
}
