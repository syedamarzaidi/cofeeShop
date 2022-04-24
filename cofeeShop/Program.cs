using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.BL;
using cofeeShop.UI;
using cofeeShop.DL;

namespace cofeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\kali\\Documents\\Visual Studio 2015\\Projects\\cofeeShop\\cofeeShop\\files\\menu.txt";
            CofeeShopDL.LoadMenu(path);
            string option = ""; //option variable to store menu item option
            while (option != "9")
            {
                option = CofeeShopUI.Menu();
                if (option == "1")
                {
                    MenuItem m = CofeeShopUI.takeInputForMenu();
                    CofeeShopDL.addMenuItem(m);
                    CofeeShopDL.saveMenu(path, true);
                }
                else if (option == "2")
                {
                    CofeeShop.showCheapestItem();
                }
                else if (option == "3")
                {
                    CofeeShopUI.showListMenu("DRINK");
                }
                else if(option == "4")
                {
                    CofeeShopUI.showListMenu("FOOD");
                }
                else if(option == "5")
                {
                    if (CofeeShop.addOrder())
                    {
                        Console.WriteLine("Order Added");
                    }
                    else
                    {
                        Console.WriteLine("This item is currently unavailable");
                    }
                }
                else if(option == "6")
                {
                    CofeeShop.fullFillOrder();
                }
                else if(option == "7")
                {
                    CofeeShopUI.showOrdersList();
                }
                else if(option == "8")
                {
                    int amount = CofeeShop.calculatePayableAmount();
                    CofeeShopUI.showPayableAmount(amount);
                    CofeeShopDL.clearAllOrders();
                }
            }
        }
    }
}
