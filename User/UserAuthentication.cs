using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace User

{
    public class UserAuthentication
    {
        public static bool authenticate(UserVariables obj)
        {
            DataSet userDS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Traders where user_id=" + obj.ID + " and user_pwd='" + obj.password + "'", CommanVariables.con);
            da.Fill(userDS, "Login_Details");
            int count = Convert.ToInt32(userDS.Tables[0].Rows.Count);
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
