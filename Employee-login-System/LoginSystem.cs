﻿using System;
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

            Fstream = new FileStream("D:\\C#\\Login-Entry.csv", FileMode.Append, FileAccess.Write);
            string path = @"D:\\C#\\Login-Entry.csv";
            Swriter = new StreamWriter(Fstream);
            int i = 1;
            while (i > 0)
            {
                if (DateTime.TryParse(input, out entry))
                {
                    if (Convert.ToDateTime(entry) <= entry_Time)
                    {
                        var info = new FileInfo(path);
                        if (info.Length == 0)
                        {
                            string firstLine = "Employee-Name" + " | " + "Login-Time" + " | " + " Time-Delayed" + " | " + "Reason for Delay";
                            string s = "\n" + name + " | " + entry.ToString() + " | " + "00:00" + " | " + "Nil";
                            Swriter.WriteLine(firstLine);
                            writefunc(s);
                        }
                        else
                        {
                            string s = "\n" + name + " | " + entry.ToString() + " | " + "00:00" + " | " + "Nil"; ;
                            writefunc(s);
                        }
                        i = 0;
                    }
                    else
                    {
                        TimeSpan delayed_Time = entry.Subtract(entry_Time);
                        Console.Write($"\nYour are late by {delayed_Time} HH:MM:SS \n\n Kindly Provide us the Reason for ur delay: ");
                        string delay_Reason = Console.ReadLine();
                        string s = "\n" + name + " | " + entry.ToString() + " | " + Convert.ToString(delayed_Time) + " | " + delay_Reason;
                        writefunc(s);
                        i = 0;
                    }
                }
                else
                {
                    Console.WriteLine("\nEnter the input in correct time format (HH:MM:SS)");

                    Console.Write("\nEnter Your Login Time (HH:MM): ");

                    input = Console.ReadLine();

                }
            }

        }
        public void writefunc(string str) 
        {
            Swriter.WriteLine(str);

            Swriter.Flush();
            Swriter.Close();
            Fstream.Close();


        }
    }
}
