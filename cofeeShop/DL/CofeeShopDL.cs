using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.BL;
namespace cofeeShop.DL
{
    class CofeeShopDL
    {
        public static void addMenuItem(MenuItem m)
        {
                CofeeShop.menu.Add(m);
        }
        public static bool addOrder(string order)
        {
            if (CofeeShop.isItemAvailable(order))
            {
                CofeeShop.orders.Add(order);
                return true;
            }
            return false;
        }
        public static string getCheapestOrder()
        {
            // This function is comparing both items of menu prices and return cheapest item
            string cheapest = "";
            int min = CofeeShop.menu[0].price;
            for (int i = 0; i < CofeeShop.menu.Count - 1; i++)
            {
                if (min > CofeeShop.menu[i + 1].price)
                {
                    cheapest = CofeeShop.menu[i+1].name ;
                }
            }
            return cheapest;
        }
        public static bool isOrderListEmpty()
        {
            if (CofeeShop.orders == null)
            {
                return true;
            }
            return false;
        }
        public static List<MenuItem> getItemList(string type)
        {
            List<MenuItem> m = new List<MenuItem>();
            foreach (var stored in CofeeShop.menu)
            {
                if (stored.type == type)
                {
                    m.Add(stored);
                }
            }
            return m;
        }
        public static void removeFirstOrderItem()
        {
            if (!isOrderListEmpty())
            {
                CofeeShop.orders.RemoveAt(0);
            }
        }

    }
}
