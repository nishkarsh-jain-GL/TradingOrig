using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard;
using User;
using Admin;
using System.Data.SqlClient;
using Variables;

namespace Grow
{
    public class LoginWindow:CommanDashboard
    {
        public void login()
        {
            while (true)
            {
                mainScreen();
                
                try
                {
                    int input = int.Parse(Console.ReadLine().Trim());
                    switch (input)
                    {
                        case 1:
                            AdminOperations adminOperation = new AdminOperations();
                            adminOperation.adminLogin(loginWindow());
                            break;
                        case 2:
                            add:
                            try
                            {
                                userLoginPage();
                                input2 = int.Parse(Console.ReadLine().Trim());
                            }
                            catch(Exception e)
                            {
                                inputError();
                                goto add;
                            }
                            UserOperations userOperations = new UserOperations();
                            switch (input2)
                            {

                                case 1:
                                Useradd:
                                    userOperations.insertUser(userForm());
                                    
                                    break;
                                case 2:
                                     UserVariables.userObj = loginWindow();
                                    userOperations.userLogin();
                                    break;
                                default:
                                    break;

                            }
                            break;
                        case 3:                          
                            break;
                        default:
                            inputError();
                            break;
                    }
                    if (input == 3) break;
                                        
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Id already exists");
                    Console.ReadKey();                   
                }
                catch(Exception e)
                {
                    inputError();
                    Console.ReadKey();
                    login();
                }
            }
        }
    }
}
