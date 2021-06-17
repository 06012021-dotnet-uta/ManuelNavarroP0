using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0DbContext;

namespace BusinessLayer
{
    public class Menus
    {
        P0Context context = new P0Context();
        OrderProduct orderProduct = new();
        Order order = new();
        //Menus menus = new();

        /// <summary>
        /// Displays a question for the user and accepts an answer
        /// </summary>
        /// <returns></returns>
        public int firstChoice()
        {
            Console.WriteLine("\n************************************************");
            Console.WriteLine("Would you like to shop or search for a customer");
            Console.WriteLine("************************************************");
            Console.WriteLine("\n-- Enter 1 to shop");
            Console.WriteLine("-- Enter 2 to search for a customer");
            string choice = Console.ReadLine().Trim();
            int choiceInt = Int32.Parse(choice);
            while (choiceInt < 1 || choiceInt > 2)
            {
                Console.WriteLine("Incorrect value entered please try again");
                choice = Console.ReadLine().Trim();
                choiceInt = Int32.Parse(choice);
            }

            return choiceInt;
        }

        /// <summary>
        /// Functionality for customer search
        /// </summary>
        public void custSearch()
        {
            Console.WriteLine("Enter customer first name you would like to search for");
            string fName = Console.ReadLine();
            string value = "";
            context.Customers.Where(c => c.CustFname.Contains(fName)).ToList().ForEach(c =>
            {
                value = $"{c.CustFname} {c.CustLname}";
            });
            if (value == "")
            {
                Console.WriteLine("The customer does not exist");
            }
            else
            {
                Console.WriteLine($"{value} exists in the database!!");
            }
        }

        /*public int locationChoice()
        {
            int storeChoiceInt = 0;
            Console.WriteLine("\n****************************************************************");
            Console.WriteLine("Enter the number of which location you would like to shop from.");
            Console.WriteLine("****************************************************************");
            context.Stores.ToList().ForEach(s =>
            {
                string value = $"-- Enter {s.StoreId} for ({s.StoreName}) Address: {s.StoreAddress}";
                Console.WriteLine(value);
            });

            string storeChoice = Console.ReadLine();
            storeChoiceInt = Int32.Parse(storeChoice);
            var stor = context.Stores.Where(s => s.StoreId == storeChoiceInt).FirstOrDefault();
            Console.WriteLine($"{storeChoiceInt}");

            Console.WriteLine("\n***************************************");
            Console.WriteLine($" {stor.StoreName}'s Information:");
            Console.WriteLine("***************************************");
            Console.WriteLine("-- Enter 1 to View Products\n-- Enter 2 to View Store's Order History");
            string viewChoice = Console.ReadLine();
            int viewChoiceInt = Int32.Parse(viewChoice);
            while(viewChoiceInt < 1 || viewChoiceInt > 2)
            {
                Console.WriteLine("Incorrect value entered please try again");
                viewChoice = Console.ReadLine().Trim();
                viewChoiceInt = Int32.Parse(viewChoice);
            }
            return viewChoiceInt;
        }*/
        
        /// <summary>
        /// Main UI display with some order functionality
        /// </summary>
        public void Display()
        {
            int storeChoiceInt = 0;
            Console.WriteLine("\n****************************************************************");
            Console.WriteLine("Enter the number of which location you would like to shop from.");
            Console.WriteLine("****************************************************************");
            context.Stores.ToList().ForEach(s =>
            {
                string value = $"-- Enter {s.StoreId} for ({s.StoreName}) Address: {s.StoreAddress}";
                Console.WriteLine(value);
            });

            string storeChoice = Console.ReadLine();
            storeChoiceInt = Int32.Parse(storeChoice);
            var stor = context.Stores.Where(s => s.StoreId == storeChoiceInt).FirstOrDefault();
            Console.WriteLine($"{storeChoiceInt}");

            Console.WriteLine("\n***************************************");
            Console.WriteLine($" {stor.StoreName}'s Information:");
            Console.WriteLine("***************************************");
            Console.WriteLine("-- Enter 1 to View Products\n-- Enter 2 to View Store's Order History");
            string viewChoice = Console.ReadLine();
            int viewChoiceInt = Int32.Parse(viewChoice);
            while (viewChoiceInt < 1 || viewChoiceInt > 2)
            {
                Console.WriteLine("Incorrect value entered please try again");
                viewChoice = Console.ReadLine().Trim();
                viewChoiceInt = Int32.Parse(viewChoice);
            }
            if (viewChoiceInt == 1)
            {

            
                int custShopping = 0;
                order.OrderDate = DateTime.Now;
                order.StoreId = storeChoiceInt;
                context.Orders.Add(order);
                context.SaveChanges();
                while (custShopping == 0)
                {
                    Console.WriteLine("\n*****************************************");
                    Console.WriteLine("Shop all products or choose a Department");
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("-- Enter 0 for All Products");
                    context.ProductDepts.ToList().ForEach(d =>
                    {
                        string deprMts = $"-- Enter {d.DeptId} for {d.ProductDept1}";
                        Console.WriteLine(deprMts);
                    });
                    Console.WriteLine("-- Enter 9 to checkout");

                    string depChoice = Console.ReadLine();
                    int depChoiceInt = Int32.Parse(depChoice);
                    if (depChoiceInt == 0)
                    {
                        int x = storeChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 1)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 2)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                            
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 3)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 4)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 5)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 6)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 7)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                        orderProduct.OrderId = order.OrderId;
                        context.OrderProducts.Add(orderProduct);
                        context.SaveChanges();
                    }
                    else if (depChoiceInt == 8)
                    {
                        int x = storeChoiceInt;
                        int y = depChoiceInt;
                        context.StoreInventories.Where(s => s.StoreId == x).ToList().ForEach(s =>
                        {
                            context.Products.Where(p => p.ProductId == s.ProductId && p.DeptId == y).ToList().ForEach(p =>
                            {
                                string storeValue = $" Id:{s.ProductId} |Name: {p.ProductName} |Desc: {p.ProductDesc} |Price: {p.ProductPrice} |In Stock: {s.ProductQuantity}";
                                Console.WriteLine(storeValue);
                            });
                        });
                        Console.WriteLine("Enter the product id you would like to select");
                        string prodId = Console.ReadLine();
                        int prodIdInt = Int32.Parse(prodId);
                        Console.WriteLine("Enter the quantity of the product you would like");
                        string prodQuant = Console.ReadLine();
                        int prodQuantint = Int32.Parse(prodQuant);

                        orderProduct.ProductId = prodIdInt;
                        orderProduct.ProductOrderQuantity = prodQuantint;
                    }
                    else if (depChoiceInt == 9)
                    {
                        
                     

                        custShopping++;
                    }
                }
            }
            else if (viewChoiceInt == 2)
            {

            }
            return;
        }
    }
}
