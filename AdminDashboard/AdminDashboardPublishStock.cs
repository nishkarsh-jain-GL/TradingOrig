
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace AdminDashboard
{
    public partial class AdminDashboardScreen
    {
        public StockVariables publishStockPage()
        {
            Console.Clear();
            StockVariables stock = new StockVariables();
            try
            {
                PrintLine();
                PrintRow("Publish Stock");
                PrintLine();
                Console.WriteLine("Enter Stock ID:");
                stock.stockID = int.Parse(Console.ReadLine());

            stocknameinput:
                Console.WriteLine("Enter Stock Name:");
                stock.stockName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(stock.stockName))
                {
                    nullError();
                    goto stocknameinput;
                }
            companynameinput:
                Console.WriteLine("Enter Company Name:");
                stock.CompanyName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(stock.CompanyName))
                {
                    nullError();
                    goto companynameinput;
                }
                Console.WriteLine("Enter Stock Quantity:");
                stock.stockQuantity = Convert.ToInt32(Console.ReadLine().Trim());

                Console.WriteLine("Enter Stock Buy price:");
                stock.stockBuyPrice = Convert.ToDouble(Console.ReadLine().Trim());
                Console.WriteLine("Enter Stock Sell price:");
                stock.stockSellPrice = Convert.ToDouble(Console.ReadLine().Trim());
                Console.WriteLine("Enter Stock brokerage:");
                stock.stockBrokerage = Convert.ToDouble(Console.ReadLine().Trim());
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
