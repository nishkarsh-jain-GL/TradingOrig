using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    partial class AdminOperations
    {
        void calBrokerage()
        {
            DataSet report = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TradingReport", con);
            da.Fill(report, "TradingReport");
            double brokerage = 0;
            int count = report.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                brokerage += double.Parse(report.Tables[0].Rows[i][8].ToString().Trim());
            }
            Console.WriteLine("Your Brokerage Balance is " + brokerage);

        }
    }
}
