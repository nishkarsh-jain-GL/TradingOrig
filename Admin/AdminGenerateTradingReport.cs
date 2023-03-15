using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard;
namespace Admin
{
    partial class AdminOperations
    {
        void getTradingReport()
        {

            Console.Clear();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from TradingReport", con);
            da.Fill(ds, "TradingReport");
            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
            int i;

            PrintLine();
            PrintRow("Trading Report");
            PrintLine();
            PrintRow("SNO.", "User_id", "User Name", "Stock_ID", "Stock_Name", "Operation", "Price", "Quantity", "Brokerage(in RS.)");
            List<TradingReport> tradeList = new List<TradingReport>();
            for (i = 0; i < count; i++)
            {

                TradingReport tradingReport = new TradingReport();
                tradingReport.sno = i + 1;
                tradingReport.user_ID = int.Parse(ds.Tables[0].Rows[i][1].ToString().Trim());
                tradingReport.userName = ds.Tables[0].Rows[i][2].ToString().Trim();
                tradingReport.stock_ID = int.Parse(ds.Tables[0].Rows[i][3].ToString().Trim());
                tradingReport.stockName = ds.Tables[0].Rows[i][4].ToString().Trim();
                tradingReport.operation = ds.Tables[0].Rows[i][5].ToString().Trim();
                tradingReport.price = double.Parse(ds.Tables[0].Rows[i][6].ToString().Trim());
                tradingReport.quantity = int.Parse(ds.Tables[0].Rows[i][7].ToString().Trim());
                tradingReport.brokerage = double.Parse(ds.Tables[0].Rows[i][8].ToString().Trim());
                tradeList.Add(tradingReport);

            }
            i = 0;
            foreach (TradingReport trades in tradeList)
            {

                PrintLine();
                PrintRow(trades.sno.ToString(),
                    trades.user_ID.ToString(),
                    trades.userName,
                    trades.stock_ID.ToString(),
                    trades.stockName,
                    trades.operation,
                    trades.price.ToString(),
                    trades.quantity.ToString(),
                    trades.brokerage.ToString()
                    );
            }
            Console.ReadKey();
        }



    }
}
