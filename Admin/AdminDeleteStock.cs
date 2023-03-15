using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Admin
{
    partial class AdminOperations
    {
        public void deleteStock()
        {
            DataSet stockData = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Stocks", con);
            da.Fill(stockData, "Stock Table");
            stockTable(stockData);
            Console.WriteLine("Enter the stockID to delete:");
            int ID = int.Parse(Console.ReadLine());
            sqlCommand = new SqlCommand("delete from Stocks where Stock_ID=" + ID, con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Stock Deleted Successfully");
            Console.ReadKey();

        }
    }
}
