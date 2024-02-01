using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop1;
using YungDev;

namespace YungDev;

public class Login
{
    public static void Page()
    {
        Console.Clear();
        string[] loginList = File.ReadAllLines("../../../customer.txt");

        Console.WriteLine("**********LOGIN************");
        Console.WriteLine("Leave empty to exit");
        Console.WriteLine();
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("\nPassword: ");
        string? password = Console.ReadLine();

        bool customerCheck = true;
        bool adminCheck = true;
        
        if (customerCheck)
        {
            foreach (string login in loginList)
            {
                List<string> customer = new List<string>(login.Split(","));

                if (customer[0] == username && customer[1] == password)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome " + username);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadKey();
                    File.WriteAllText("../../../LoggedIn.txt", username + "," + password);

                    Customer.LoginMenu();
                    customerCheck = false;
                    break;
                }

                else if (customer[0] != username && customer[1] != password)
                {
                    continue;
                }
            }
        }

    }
}


