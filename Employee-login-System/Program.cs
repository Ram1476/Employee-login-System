using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_login_System
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            LoginSystem user1 = new LoginSystem();
            Console.WriteLine("*********** WELCOME TO EMPLOYEE LOGIN SYSTEM ***********");
            Console.Write("\nEnter Employee name: ");
            user1.name = Console.ReadLine();
            Console.Write("\nEmployee Login Status (Entered/Not Entered): ");
            string entryStatus = Console.ReadLine();
            if (entryStatus.ToUpper() == "ENTERED")
            {
                Console.Write("\nEnter Your Login Time (HH:MM): ");

                user1.input = Console.ReadLine();
               
                user1.loginEntry();
            }
            else if (entryStatus.ToUpper()!="ENTERED" && entryStatus.ToUpper() != "NOT ENTERED") 
            {
                Console.WriteLine("\nPlease Provide a Valid Input From the Example Shown");
            }
            else 
            {
                Console.WriteLine("\nYour Login Time is within \'10:00\', Try Logging in Avoid Delays\n\n Thank You ");
            }

            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\n******* Thank You for using the Employee-Login-System ********");
            Console.WriteLine("\n******* HAVE A NICE DAY *******");
            Console.WriteLine("\n------------------------------------------------------------");
            user1.read();
            Console.ReadLine();
        }
    }
}
