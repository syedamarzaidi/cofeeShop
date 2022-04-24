using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using cofeeShop.BL;
namespace cofeeShop.DL
{
    class CofeeShopDL
    {
        private static List<MenuItem> menu = new List<MenuItem>();
        private static List<string> orders = new List<string>();
        public static void saveMenu(string path,bool isAppend)
        {
            StreamWriter file = new StreamWriter(path, isAppend);
            foreach (MenuItem item in menu)
            {
                file.WriteLine("{0},{1},{2}", item.getItemName(), item.getItemType(), item.getItemPrice());
            }
            file.Flush();
            file.Close();
        }
        public static void LoadMenu(string path)
        {
            if (File.Exists(path))
            {
                string line;
                string name, type;
                int price;
                StreamReader file = new StreamReader(path);
                while((line = file.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    name = fields[0];
                    type = fields[1];
                    price = int.Parse(fields[2]);
                    MenuItem m = new MenuItem(name, type, price);
                    menu.Add(m);
                }
                file.Close();
            }
        }
        public static void addMenuItem(MenuItem m)
        {
                menu.Add(m);
        }
        public static List<MenuItem> getMenu()
        {
            return menu;
        }
        public static List<string> getOrders()
        {
            return orders;
        } 
        public static void setMenu(List<MenuItem> m)
        {
            menu = m;
        }
        public static void setOrders(List<string> o)
        {
            orders = o;
        }
        public static bool addOrder(string order)
        {
            if (CofeeShop.isItemAvailable(order))
            {
                orders.Add(order);
                return true;
            }
            return false;
        }
        public static string getCheapestOrder()
        {
            // This function is comparing both items of menu prices and return cheapest item
            if (menu != null)
            {
                int min = menu[0].getItemPrice();
                string cheapest = menu[0].getItemName();
                for (int i = 0; i < menu.Count - 1; i++)
                {
                    if (min > menu[i + 1].getItemPrice())
                    {
                        cheapest = menu[i + 1].getItemName();
                    }
                }
                return cheapest;
            }
            return null;
        }
        public static bool isOrderListEmpty()
        {
            if (orders == null)
            {
                return true;
            }
            return false;
        }
        public static List<MenuItem> getItemList(string type)
        {
            List<MenuItem> m = new List<MenuItem>();
            foreach (var stored in menu)
            {
                if (stored.getItemType() == type)
                {
                    m.Add(stored);
                }
            }
            return m;
        }
        public void removeFirstOrderItem()
        {
            if (!isOrderListEmpty())
            {
                orders.RemoveAt(0);
            }
        }
        public static void clearAllOrders()
        {
            while (orders.Count != 0)
            {
                orders.RemoveAt(0);
            }
        }

    }
}
