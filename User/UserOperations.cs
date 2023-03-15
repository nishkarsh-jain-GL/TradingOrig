using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
using Dashboard;
namespace User
{
    public partial class UserOperations:CommanDashboard
    {
        DataSet userDS;
        DataSet stockDS;
        int userCount=0;
        int stockCount=0;
        int quantity=0;
        double userBalance = 0;
        UserVariables userDetails= new UserVariables();
        StockVariables stock = new StockVariables();
        public void insertUser(UserVariables userloginDetails)
        {
            sqlCommand = new SqlCommand("insert into Traders values("
                + userloginDetails.ID + ",'" 
                + userloginDetails.name + "','" 
                + userloginDetails.password + "'," 
                + userloginDetails.userBalance 
                + ")", con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Record Insert Successfully");
            Console.ReadKey();
            
            

        }
        public void userLogin()
        {
            double balance = 0;
            if (UserAuthentication.authenticate(UserVariables.userObj))
            {
                userDS = getUserDS();
                stockDS = getStockDS();
                getUserDetails();
                try
                {
                    while (true)
                    {
                        //stockReport();
                        userPortal();
                        input = int.Parse(Console.ReadLine().Trim());
                        switch (input)
                        {
                            case 1:
                                buyStock();
                                break;
                            case 2:
                                sellStock();
                                break;
                            case 3:
                                viewBalance();
                                break;
                            case 4:
                                addBalance();
                                break;
                            case 5:
                                withdrawBalance();
                                break;
                            case 6:
                                viewMyStock();
                                break;
                            case 7:

                                break;
                            default:
                                inputError();
                                break;

                        }
                        if (input == 7) break;
                    }
                }
                catch (Exception e)
                {
                    valueError();
                    userLogin();
                }
            }
            else
            {
                userLogin();
            }
        }
        void buyStock()
        {

            Console.WriteLine("Enter the Stock ID From Above list:");
            stock.stockID = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Enter the quantity to buy:");
            quantity = int.Parse(Console.ReadLine().Trim());

           

            if (getStockDetails())
            {
                userBalance = getBalance();



                double brokerage = ((stock.stockBuyPrice * quantity * stock.stockBrokerage) / 100);
                userBalance -= brokerage;

                userBalance -= (stock.stockBuyPrice * quantity);
                if (quantity > stock.stockQuantity)
                {
                    Console.WriteLine("Don't have this much Quantity ");

                }
                else if (userBalance < stock.stockBuyPrice)
                {
                    Console.WriteLine("Insufficient Balance");


                }
                else
                {
                    userDetails.userBalance = userBalance;
                    stock.stockQuantity -= quantity;
                    sqlCommand = new SqlCommand("insert into TradingReport values("
                        + userDetails.ID + ",'"
                        + userDetails.name + "',"
                        + stock.stockID + ",'"
                        + stock.stockName + "',"

                        + "'BUY',"
                        + stock.stockBuyPrice + ","
                        + quantity + ","
                        + brokerage + ")", con);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    setBalance();
                    setStockQuantity();
                    Console.WriteLine("Stock Buyed Successfully");

                }

            }
        }
      

        void sellStock() {

            Console.WriteLine("Enter Stock ID to sell:");
            stock.stockID = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Enter Stock Quantity to sell:");
            quantity= int.Parse(Console.ReadLine().Trim());
            DataSet userStocks = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TradingReport", con);
            da.Fill(userStocks, "TradingReport");
            int buysell = 0;
            int count = userStocks.Tables[0].Rows.Count;
            
            for (int i = 0; i < count; i++)
            {
                if (int.Parse(userStocks.Tables[0].Rows[i][3].ToString().Trim()) == stock.stockID &&
                    int.Parse(userStocks.Tables[0].Rows[i][1].ToString().Trim()) == userDetails.ID)
                {
                    if (userStocks.Tables[0].Rows[i][5].ToString().Trim() == "BUY")
                        buysell += int.Parse(userStocks.Tables[0].Rows[i][7].ToString().Trim());
                    else if (userStocks.Tables[0].Rows[i][5].ToString().Trim() == "SELL")
                        buysell -= int.Parse(userStocks.Tables[0].Rows[i][7].ToString().Trim());

                }
            }
            if (quantity > 0 &&  buysell >= quantity && getStockDetails())
            {
                userBalance = getBalance();
                stock.stockQuantity += buysell;
                double brokerage = (quantity * stock.stockSellPrice * stock.stockBrokerage) / 100;
                userBalance += (buysell * stock.stockSellPrice) - brokerage;

                userDetails.userBalance = userBalance;
                sqlCommand = new SqlCommand("insert into TradingReport values("
                    + userDetails.ID + ",'"
                    + userDetails.name + "',"
                    + stock.stockID + ",'"
                    + stock.stockName + "',"

                    + "'SELL',"
                    + stock.stockSellPrice + ","
                    + buysell + ","
                    + brokerage + ")", con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                setBalance();
                setStockQuantity();
                Console.WriteLine("Stock Sell Successfully");

                

            }
            else
            {
                Console.WriteLine("You don't have that much quantity to sell");
                }
            
        }
        void withdrawBalance() 
        {
            Console.WriteLine("Enter The Amount to withdraw:");
            double balance = double.Parse(Console.ReadLine().Trim());
            if (balance <= getBalance())
            {
                userDetails.userBalance=getBalance()-balance;
                setBalance();
                Console.WriteLine("Balance Updated Successfully");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        void viewMyStock() { }

        void stockReport()
        {
            stockDS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stocks", con);
            da.Fill(stockDS, "StockRreport");
            //stockTable(stockDS);

        }
        double getBalance()
        {
            int count = userDS.Tables[0].Rows.Count;

            for(int i=0; i< count;i++ )
            {
                if(int.Parse(userDS.Tables[0].Rows[i][1].ToString().Trim()) == userDetails.ID)

                {
                    return userDetails.userBalance;
                }
            }
            return 0;
        }
        
        void viewBalance() {
            Console.WriteLine("Your balance is "+getBalance());
        }
        void addBalance() {

            Console.WriteLine("Enter The Amount:");
            double balance = double.Parse(Console.ReadLine().Trim());
            balance += getBalance();
            userDetails.userBalance = balance;
            setBalance();
            Console.WriteLine("Balance Updated Successfully");
        }

        void setBalance()
        {   
            sqlCommand = new SqlCommand("update Traders set balance =" + userDetails.userBalance + " where user_id=" + userDetails.ID, con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
        void setStockQuantity()
        {
            sqlCommand = new SqlCommand("update Stocks set Quantity =" + stock.stockQuantity + " where Stock_ID=" + stock.stockID, con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
        
        void getUserDetails()

        {
            for (int i = 0; i < userCount; i++)
            {
                if (int.Parse(userDS.Tables[0].Rows[i][1].ToString().Trim()) == loginDetails.ID)

                {
                    userDetails.ID = loginDetails.ID;
                    userDetails.name = userDS.Tables[0].Rows[i][2].ToString().Trim();
                    userDetails.userBalance=double.Parse(userDS.Tables[0].Rows[i][4].ToString().Trim());
                    break;
                }
            }
            
        }
        bool getStockDetails()
        {
            for (int i = 0; i < stockCount; i++)
            {

                if (int.Parse(stockDS.Tables[0].Rows[i][1].ToString().Trim()) == stock.stockID)

                {

                    stock.stockName = stockDS.Tables[0].Rows[i][2].ToString().Trim();
                    stock.CompanyName = stockDS.Tables[0].Rows[i][3].ToString().Trim();
                    stock.stockBuyPrice = double.Parse(stockDS.Tables[0].Rows[i][4].ToString().Trim());
                    stock.stockSellPrice = double.Parse(stockDS.Tables[0].Rows[i][5].ToString().Trim());
                    stock.stockQuantity = int.Parse(stockDS.Tables[0].Rows[i][6].ToString().Trim());
                    stock.stockBrokerage = double.Parse(stockDS.Tables[0].Rows[i][7].ToString().Trim());
                    return true;
                }
                
            }
            Console.WriteLine("Stock not found");
            return false;
        }
        /*bool userStockDetails()
        {
            DataSet userStocks = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TradingReport",con);
            da.Fill(userStocks, "TradingReport");

            int count = userStocks.Tables[0].Rows.Count;
            quantity = 0;
            for(int i = 0; i < count; i++)
            {
                if (int.Parse(userStocks.Tables[0].Rows[i][3].ToString().Trim()) == stock.stockID &&
                    int.Parse(userStocks.Tables[0].Rows[i][1].ToString().Trim()) == userDetails.ID) 
                {
                    if(userStocks.Tables[0].Rows[i][5].ToString().Trim() == "BUY")
                        quantity += int.Parse(userStocks.Tables[0].Rows[i][7].ToString().Trim());
                    else if(userStocks.Tables[0].Rows[i][5].ToString().Trim() == "SELL")
                        quantity -= int.Parse(userStocks.Tables[0].Rows[i][7].ToString().Trim());

                }
            }
            if (quantity > 0)
            {
                userBalance = getBalance();
                stock.stockQuantity += quantity;
                double brokerage = (quantity * stock.stockSellPrice * stock.stockBrokerage) / 100;
                userBalance -= (quantity * stock.stockSellPrice) - brokerage;

                userDetails.userBalance = userBalance;
                sqlCommand = new SqlCommand("insert into TradingReport values("
                    + userDetails.ID + ",'"
                    + userDetails.name + "',"
                    + stock.stockID + ",'"
                    + stock.stockName + "',"

                    + "'SELL',"
                    + stock.stockSellPrice + ","
                    + quantity + ","
                    + brokerage + ")", con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                setBalance();
                setStockQuantity();
                Console.WriteLine("Stock Sell Successfully");
                
                return true;

            }
            else
            {
                Console.WriteLine("You don't have that much quantity to sell");
            }
            return false;
        }*/
         DataSet getUserDS()
         { 
            
            DataSet userDS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Traders", con);
            da.Fill(userDS, "Traders");
            userCount = userDS.Tables[0].Rows.Count;
            return userDS;
        }
        DataSet getStockDS()
        {
            DataSet stockDS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stocks", con);
            da.Fill(stockDS, "Stockss");
            stockCount = stockDS.Tables[0].Rows.Count;
            return stockDS;
        }
    }
}
