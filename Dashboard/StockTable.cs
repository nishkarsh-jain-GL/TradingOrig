
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Dashboard
{
    public partial class CommanDashboard:IStockTable
    {
        public void stockTable(DataSet ds)
        {
            Console.Clear();
            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
            int i;
            PrintLine();
            PrintRow("STOCK Report");
            PrintLine();
            PrintRow("SNO.", "Stock_ID", "Stock_Name", "Company_Name", "Buy_Price", "Sell_Price", "Quantity", "Trading_Fee(%)");
            List<StockVariables> stockList = new List<StockVariables>();
            for (i = 0; i < count; i++)
            {

                StockVariables stocks = new StockVariables();
                stocks.stockID = int.Parse(ds.Tables[0].Rows[i][1].ToString().Trim());
                stocks.stockName = ds.Tables[0].Rows[i][2].ToString().Trim();
                stocks.CompanyName = ds.Tables[0].Rows[i][3].ToString().Trim();
                stocks.stockBuyPrice = double.Parse(ds.Tables[0].Rows[i][4].ToString().Trim());
                stocks.stockSellPrice = double.Parse(ds.Tables[0].Rows[i][5].ToString().Trim());
                stocks.stockQuantity = int.Parse(ds.Tables[0].Rows[i][6].ToString().Trim());
                stocks.stockBrokerage = double.Parse(ds.Tables[0].Rows[i][7].ToString().Trim());
                stockList.Add(stocks);

            }
            i = 0;
            foreach (StockVariables stock in stockList)
            {
                i++;
                PrintLine();
                PrintRow(i.ToString(), stock.stockID.ToString(), stock.stockName, stock.CompanyName,
                    stock.stockBuyPrice.ToString(), stock.stockSellPrice.ToString(), stock.stockQuantity.ToString(), stock.stockBrokerage.ToString());
            }
        }
    }
}
