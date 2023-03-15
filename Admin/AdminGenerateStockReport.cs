using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Dashboard;
namespace Admin
{
    partial class AdminOperations
    {
        void stockReport()
        {
            Console.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stocks", con);
            da.Fill(ds, "StockRreport");
            stockTable(ds);
            Console.ReadKey();

        }
    }
}
