using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0DbContext;

namespace BusinessLayer
{
    public class Login
    {
        P0Context context = new P0Context();
        Order order = new();

        /// <summary>
        /// Welcome message
        /// </summary>
        /// <returns></returns>
        public int Welcome()
        {
            Console.WriteLine("\n*******************************************");
            Console.WriteLine("Welcome shopper to the H-E-B shopping mart!");
            Console.WriteLine("*******************************************");

            Console.WriteLine("Have you shopped here before?\n\n-- Enter 1 to Login\n-- Enter 2 to Create an Account\n");
            string choice = Console.ReadLine().Trim();
            int choiceInt = Int32.Parse(choice);
            while(choiceInt < 1 || choiceInt > 2)
            {
                Console.WriteLine("Incorrect value entered please try again");
                choice = Console.ReadLine().Trim();
                choiceInt = Int32.Parse(choice);
            }

            return choiceInt;
        }

        /// <summary>
        /// Login screen and verifies customers username and password
        /// </summary>
        /// <returns></returns>
        public int custLogin()
        {
            Console.WriteLine("\n***************************");
            Console.WriteLine("Please Enter your Username!");
            Console.WriteLine("***************************");
            string usernameLogin = Console.ReadLine();
            var usernames = context.Customers.Where(c => c.CustUsername.Contains(usernameLogin)).ToList();
            int tries = 0;
            int tries1 = 0;
            int exit = 0;
            while (tries < 10 && tries1 < 10 && exit == 0)
            {
                //bool entry = usernames.Any();
                //Console.WriteLine($"{entry}");
                while (!usernames.Any() && tries <= 10)
                {
                    Console.WriteLine("Incorrect username please try again");
                    usernameLogin = Console.ReadLine();
                    usernames = context.Customers.Where(c => c.CustUsername.Contains(usernameLogin)).ToList();
                    //entry = usernames.Any();
                    tries++;
                }


                Console.WriteLine("\n***************************");
                Console.WriteLine("Please Enter your password!");
                Console.WriteLine("***************************");
                string passwordLogin = Console.ReadLine();
                var passwords = context.Customers.Where(c => c.CustPassword.Contains(passwordLogin)).ToList();
                //bool entry1 = passwords.Any();
                while (!passwords.Any() && tries1 <= 10)
                {
                    Console.WriteLine("Incorrect username please try again");
                    passwordLogin = Console.ReadLine();
                    passwords = context.Customers.Where(c => c.CustUsername.Contains(passwordLogin)).ToList();
                    //entry1 = passwords.Any();
                    tries1++;
                }
                int user = 0;
                context.Customers.Where(c => c.CustUsername == usernameLogin).ToList().ForEach(c =>
                {
                    user = c.CustId;
                });
                order.CustId = user;
                context.Orders.Add(order);
                exit++;
            }

            if (tries == 10 || tries1 == 10)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("Please create an account");
                Console.WriteLine("*************************");
                int login = 2;
                return login;
            }
            else
            {
                int login = 3;
                return login;
            }
        }

        /// <summary>
        /// Accepts all users correct inputs and creats their account
        /// </summary>
        /// <returns></returns>
        public int CreateAccount()
        {
            Console.WriteLine("\n******************************");
            Console.WriteLine("Please Enter your first name!");
            Console.WriteLine("******************************");
            string fName = Console.ReadLine().Trim();
            while(fName.Length > 30)
            {
                Console.WriteLine("First name is too long please re-enter");
                fName = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n*****************************");
            Console.WriteLine("Please Enter your last name!");
            Console.WriteLine("*****************************");
            string lName = Console.ReadLine().Trim();
            while (lName.Length > 50)
            {
                Console.WriteLine("Last name is too long please re-enter");
                lName = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n**************************************************************");
            Console.WriteLine("Please Enter your phone number in this format (XXX-XXX-XXXX)!");
            Console.WriteLine("**************************************************************");
            string phoneNum = Console.ReadLine().Trim();
            while (phoneNum.Length > 12)
            {
                Console.WriteLine("Phone number is out of format please re-enter");
                phoneNum = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n*************************");
            Console.WriteLine("Please Enter your email!");
            Console.WriteLine("*************************");
            string email = Console.ReadLine().Trim();
            while (email.Length > 100)
            {
                Console.WriteLine("Email is too long please re-enter");
                email = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n**********************************");
            Console.WriteLine("Please Enter your address street!");
            Console.WriteLine("**********************************");
            string street = Console.ReadLine().Trim();
            while (street.Length > 255)
            {
                Console.WriteLine("Address Street is out of bounds please re-enter");
                street = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n*************************");
            Console.WriteLine("Enter your address city!");
            Console.WriteLine("*************************");
            string city = Console.ReadLine().Trim();
            while (city.Length > 40)
            {
                Console.WriteLine("Address City is too long please re-enter");
                city = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n**************************");
            Console.WriteLine("Enter your address state!");
            Console.WriteLine("**************************");
            string state = Console.ReadLine().Trim();
            while (state.Length > 40)
            {
                Console.WriteLine("Address State is too long please re-enter");
                state = Console.ReadLine().Trim();
            }

            Console.WriteLine("\n*****************************************");
            Console.WriteLine("Thank you for entering your information!\nPlease Create a username for your Account!");
            Console.WriteLine("*****************************************");
            string userName = Console.ReadLine().Trim();

            Console.WriteLine("\n******************************************");
            Console.WriteLine("Please Create a password for your Account!");
            Console.WriteLine("******************************************");
            string passWord = Console.ReadLine().Trim();

            Console.WriteLine("\n**********************************");
            Console.WriteLine("Your Account has been Created!!");
            Console.WriteLine("**********************************");
            Customer customer = new Customer();
            customer.CustFname = fName;
            customer.CustLname = lName;
            customer.CustPhoneNum = phoneNum;
            customer.CustEmail = email;
            customer.CustUsername = userName;
            customer.CustPassword = passWord;

            context.Customers.Add(customer);
            context.SaveChanges();

            CustomersAddress customersAddress = new CustomersAddress();
            customersAddress.AddressStreet = street;
            customersAddress.AddressCity = city;
            customersAddress.AddressState = state;

            context.CustomersAddresses.Add(customersAddress);
            context.SaveChanges();

            Console.WriteLine("\n*************");
            Console.WriteLine("Please Login");
            Console.WriteLine("*************");

            int login = 1;

            return login;
        }
    }
}
