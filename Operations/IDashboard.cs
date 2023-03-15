using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variables;
namespace Operations
{
    public interface IDashboard
    {
        void mainScreen();
        CommanClass loginWindow();
        void userLoginPage();
        void userPortal();
        CommanClass userForm();
        void adminPortal();
        StockVariables publishStockPage();
        StockVariables deleteStockPage();
        
        void inputError();
        void nullError();
        void valueError();
        
        void stockTable(DataSet ds);
    }
}
