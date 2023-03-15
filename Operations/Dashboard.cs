using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Operations
{
    public class Dashboard:CommanClass
    {
        public void mainScreen()
        {
            Console.Clear();
            Console.WriteLine(" ===============================================");
            Console.WriteLine(" Press 1 To Admin Login");
            Console.WriteLine(" Press 2 To  User Login");
            Console.WriteLine(" Press 3 To  Exit");
        }
        public void userLoginPage()
        {
            Console.Clear();
            PrintLine();
            PrintRow("USER");
            PrintLine();
            Console.WriteLine(" Press 1 To create new Account");
            Console.WriteLine(" Press 2 To login INTO EXISTING Account");
            Console.WriteLine(" Press 3 to GoBack:");
        }

        public CommanClass loginWindow()
        {
            
            Console.Clear();
            loginDetails = new CommanClass();
           
            try
            {
                PrintLine();
                PrintRow("LOGIN WINDOW");
                PrintLine();
                Console.WriteLine("Enter User ID");
                loginDetails.ID = int.Parse(Console.ReadLine().Trim());
                password:
                Console.WriteLine("Enter Password");
                loginDetails.password = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(loginDetails.password))
                {
                    nullError();
                    goto password;
                }
            }
            catch (Exception e) 
            {
                
                valueError();
                loginWindow();
               
            }
            
            return loginDetails;
            
        }

        public void adminPortal()
        {
            Console.Clear();
            PrintLine();
            PrintRow("ADMIN PORTAL");
            PrintLine();
            Console.WriteLine("Press 1 for Publish Stock");
            Console.WriteLine("Press 2 to Delete Stock");
            Console.WriteLine("Press 3 to Generate Stock report");
            Console.WriteLine("Press 4 to Calculate Transaction Fee");
            Console.WriteLine("Press 5 to Generate Trading Report");
            Console.WriteLine("Press 6 to LogOut");
        }
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
            catch(Exception e)
            {
                inputError();
                publishStockPage();
            }
            return stock;
        }

        public void userPortal()
        {
            PrintLine();
            PrintRow("USER PORTAL");
            PrintLine();
            Console.WriteLine("Press 1 to Buy Stock");
            Console.WriteLine("Press 2 to Sell Stock");
            Console.WriteLine("Press 3 for View Balance");
            Console.WriteLine("Press 4 To ADD BALANCE");
            Console.WriteLine("Press 5 To Withdraw Money");
            Console.WriteLine("Press 6 To view MY Stocks");
            Console.WriteLine("Press 7 To LogOut");


        }
        public CommanClass userForm()
        {
            
                Console.Clear();
                loginDetails = new CommanClass();
                PrintLine();
                PrintRow("Create Account");
                PrintLine();
                Console.WriteLine("Enter User ID:");
                loginDetails.ID = Convert.ToInt32(Console.ReadLine().Trim());
                
                nameinput:
                Console.WriteLine("Enter Name:");
                loginDetails.name = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(loginDetails.name))
                {
                    nullError();
                    goto nameinput;
                }
                passwordinput:
                Console.WriteLine("Enter Password:");
                loginDetails.password = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(loginDetails.password))
                {
                    nullError();
                    goto passwordinput;
                }
                loginDetails.userBalance = 0;
                       
            return loginDetails;

        }
        public void inputError()
        {
            Console.WriteLine("Input Error");
            Console.WriteLine("Please any Key to Continue");
            Console.ReadKey();
        }
        public void valueError()
        {
            Console.WriteLine("Please enter an integer");
            Console.WriteLine("Please any Key to Continue");
            Console.ReadKey();
        }
        public void nullError()
        {
            Console.WriteLine("Input can't be null");
        }
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
        

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            int i = 1;
            foreach (string column in columns)
            {
                /*if (i++ ==4)
                    width = 30;*/
                if (columns.Length > 8)
                {
                    if (i == 9) width += 6;

                }
               else if (columns.Length > 2)
                {
                    if (i == 1) width = 8;
                    else if (i == 2) width = 16;
                    else if (i == 4) width += 22;
                    else if (i == 5) width = 16;
                    
                }
                i++;
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        
    }
}
