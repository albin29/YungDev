using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YungDev;

namespace YungDev;

public class Login
{
    private enum Choice
    {
        Menu,
        Play,
        Stats,
        Exit
    }
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

                    LoginPage.LoginMenu();
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
    public static void LoginMenu()
    {
        Dictionary<string, int> product = new Dictionary<string, int>();
        string[] productList = File.ReadAllLines("../../../product.txt");
        Choice Customer = Choice.Menu;
        bool CustomerCheck = true;
        while (CustomerCheck)
        {
            if (Customer.Equals(Choice.Menu))
            {
                Console.Clear();
                Console.WriteLine("Please choose from below:\n");
                Console.WriteLine("1. Browse products");
                Console.WriteLine("2. Shopping cart");
                Console.WriteLine("3. Transaction history");
                Console.WriteLine("4. Logout");
            }

            int customerChoice = 0;
            string? customerInput = Console.ReadLine();
            Console.Clear();

            switch (customerChoice)
            {
                case 0:
                    switch (customerInput)
                    {
                        case "1":
                            Customer = Choice.Menu; 
                            //add logic for going back to main menu
                            break;
                        case "2":
                            Customer = Choice.Play;
                            //add logic for starting the game
                            break;
                        case "3":
                            Customer = Choice.Stats;
                            //add logic for seeing your characters statistics
                            break;
                        case "4":
                            Customer = Choice.Exit;
                            //add logic for exiting the game
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No valid option, Try again.\n");
                            break;
                    }
                    break;
            }

            if (Customer.Equals(Choice.Exit))
            {
                break;
            }
        }
    }
}


