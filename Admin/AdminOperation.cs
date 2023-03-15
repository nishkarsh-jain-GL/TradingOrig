using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDashboard;
using Variables;
using Dashboard;
namespace Admin
{
    public partial class AdminOperations
    {
        public void adminLogin(UserVariables obj) 
        {
            if (AdminAuthentication.authenticate(obj))
            {
            add1:
                while (true)
                {
                    try {
                         adminPortal();
                        
                        input = int.Parse(Console.ReadLine().Trim());
                        switch (input)
                        {
                            case 1:
                                publishStock();
                                break;
                            case 2:
                                deleteStock();
                                break;
                            case 3:
                                stockReport();
                                break;
                            case 4:
                                calBrokerage();
                                Console.ReadKey();
                                break;
                            case 5:
                                getTradingReport();
                                break;
                            case 6:
                                break;
                            default:
                                inputError();
                                break;
                        }
                        if (input == 6) break;
                    }
                    catch(Exception e)
                    {
                        valueError();
                        goto add1;
                    }
                }
            }

        }
       

        
             

        
        
    }
}
