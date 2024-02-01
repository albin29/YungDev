using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YungDev;

public class LoginPage 
{
    private enum Choice
    {
        Menu,
        Products,
        Cart,
        Transactions,
        Exit
    }

    

    
    //change later
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
                            Customer = Choice.Products;
                            break;
                        case "2":
                            Customer = Choice.Cart;
                            break;
                        case "3":
                            Customer = Choice.Transactions;
                            break;
                        case "4":
                            Customer = Choice.Exit;
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

    
             
            