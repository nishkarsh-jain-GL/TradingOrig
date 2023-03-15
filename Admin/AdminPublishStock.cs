using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using AdminDashboard;
namespace Admin
{
    partial class AdminOperations:AdminDashboardScreen
    {
        void publishStock()
        {
            StockVariables stock = publishStockPage();
            sqlCommand = new SqlCommand("insert into Stocks values("
                + stock.stockID + ",'"
                + stock.stockName + "','"
                + stock.CompanyName + "',"
                + stock.stockBuyPrice + ","
                + stock.stockSellPrice + ","
                + stock.stockQuantity + ","
                + stock.stockBrokerage
                + ")", con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Record Insert Successfully");
            Console.ReadKey();
        }
    }
}
