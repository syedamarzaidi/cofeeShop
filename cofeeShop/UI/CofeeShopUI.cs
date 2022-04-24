using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.BL;
using cofeeShop.DL;
using cofeeShop.HELPER;

namespace cofeeShop.UI
{
    class CofeeShopUI
    {
        public static string Menu()
        {
            string option = "";
            Console.WriteLine("1_Add a Menu Item");
            Console.WriteLine("2_View the Cheapest Item in the Menu");
            Console.WriteLine("3_View the drink menu");
            Console.WriteLine("4_View the Food Menu");
            Console.WriteLine("5_Add Order");
            Console.WriteLine("6_Fullfill the order");
            Console.WriteLine("7_View the Orders List");
            Console.WriteLine("8_Total Payable Amount");
            Console.WriteLine("9_Exit");
            option = Console.ReadLine();
            return option;
        }
        public static MenuItem takeInputForMenu()
        {
            string name, type;
            int price;
            Console.WriteLine("Enter Name of Item");
            name = Console.ReadLine();
            Console.WriteLine("Enter Item Type Food or drink");
            type = Console.ReadLine();
            Console.WriteLine("Enter price of Item");
            price = int.Parse(Console.ReadLine());
            MenuItem m = new MenuItem(name, type, price);
            return m;
        }
        public static string takeInputForOrder()
        {
            string order = "";
            Console.WriteLine("Enter Item Name");
            order = Console.ReadLine();
            return order;
        }
        public static void printCheapestItem(string cheapestItem)
        {
            Console.WriteLine("Cheapest Item is = {0}", cheapestItem);
            Console.ReadKey();
            Console.Clear();
        }
        public static void showItemReadyStatus(bool status, string itemName)
        {
            if (status == true)
            {
                Console.WriteLine("The {0} is Available", itemName);
            }
            else
            {
                Console.WriteLine("All orders are Fullfilled");
            }
        }
        public static void showListMenu(string type)
        {
            List<MenuItem> m = CofeeShopDL.getItemList(type);
            Console.WriteLine("Name\t\tPrice");
            foreach (var s in m)
            {
                Console.WriteLine("{0}\t\t{1}", s.getItemName(), s.getItemPrice());
            }
        }
        public static void showOrdersList()
        {
            if (!CofeeShopDL.isOrderListEmpty())
            {
                Console.WriteLine("name\t\tprice");
                foreach (string ord in CofeeShopDL.getOrders())
                {
                    Console.WriteLine("{0}", ord);
                }
            }
            else
            {
                Console.WriteLine("No Orders Yet");
            }
        }
        public static void showPayableAmount(int amount)
        {
            Console.WriteLine("Total Payable Amount = {0}", amount);
            Console.ReadKey();
            Console.Clear();
        }
      
    }
}
