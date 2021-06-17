using System;
using System.Linq;
using BusinessLayer;
using P0DbContext;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new();
            Menus menus = new();

            int correctLogin = login.Welcome();
            while (correctLogin == 1 || correctLogin == 2) 
            {
                if (correctLogin == 1)
                {
                    correctLogin = login.custLogin();
                }
                else if (correctLogin == 2)
                {
                    correctLogin = login.CreateAccount();
                }
            }
            int choice = menus.firstChoice();
            if (choice == 1)
            {
                menus.Display();
            }
            else if (choice == 2)
            {
                menus.custSearch();
            }
            
        }
    }
}
