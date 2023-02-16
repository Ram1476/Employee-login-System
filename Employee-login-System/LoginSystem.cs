using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee_login_System
{
    internal class LoginSystem
    {
        public  string input;
        public string name;

        public DateTime entry;
        
        
        static FileStream Fstream;
        static StreamWriter Swriter;
        DateTime entry_Time = Convert.ToDateTime("10:00");
        public void loginEntry()
        {
            if (DateTime.TryParse(input, out entry))
            {
                if (Convert.ToDateTime(entry) <= entry_Time)
                {
                    Fstream = new FileStream("D:\\C#\\Login-Entry.txt", FileMode.Append, FileAccess.Write);
                    string path = @"D:\\C#\\Login-Entry.txt";
                    Swriter = new StreamWriter(Fstream);
                    var info = new FileInfo(path);
                    if (info.Length == 0)
                    {
                        string firstLine = "Employee-Name" + " " + "Login-Time" + " " + " Time-Delayed" + " " + "Reason for Delay";
                        string s = "\n"+name + " " + entry.ToString() + "00:00" + " " + "Nil";
                        Swriter.WriteLine(firstLine);
                        Swriter.WriteLine(s);
                        Swriter.Flush();
                        Swriter.Close();
                        Fstream.Close();
                    }
                    else
                    {
                        string s = "\n"+name +" "+entry.ToString()+"00:00"+" "+ "Nil";
                        Swriter.WriteLine(s);
                        Swriter.Flush();
                        Swriter.Close();
                        Fstream.Close();
                    }
                }
                else
                {
                    TimeSpan delayed_Time = entry.Subtract(entry_Time);
                    Console.WriteLine($"\nYou Logged in {delayed_Time} this Delayed\n Kindly Provide us the Reason for ur delay:");
                    string delay_Reason = Console.ReadLine();
                    Fstream = new FileStream("D:\\C#\\Login-Entry.txt", FileMode.Append, FileAccess.Write);
                    Swriter = new StreamWriter(Fstream);
                    string s = "\n" + name + " " + entry.ToString()+ " " +Convert.ToString(delayed_Time)+" "+delay_Reason;
                    Swriter.WriteLine(s);

                    Swriter.Flush();
                    Swriter.Close();
                    Fstream.Close();

                }
            }
            else 
            {
                Console.WriteLine("Enter a Valid time ");
            }

        }
    }
}
