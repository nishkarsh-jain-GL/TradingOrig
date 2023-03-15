
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Dashboard;
namespace AdminDashboard
{
    public partial class AdminDashboardScreen
    {
        public StockVariables deleteStockPage()
        {
            Console.Clear();
            StockVariables stock = new StockVariables();
            try
            {
                PrintLine();
                PrintRow("Publish Stock");
                PrintLine();
                Console.WriteLine("Enter Stock ID:");
                stock.stockID = int.Parse(Console.ReadLine().Trim());
            stockname:
                Console.WriteLine("Enter Stock Name:");
                stock.stockName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(stock.stockName))
                {
                    nullError();
                    goto stockname;
                }
            }
            catch (Exception e)
            {
                inputError();
                publishStockPage();
            }
            return stock;
        }

    }
}
