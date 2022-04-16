using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.DL;
using cofeeShop.UI;
namespace cofeeShop.BL
{
    class CofeeShop
    {
        public CofeeShop(string name, List<MenuItem> menu, List<string> orders)
        {
            this.name = name;
            CofeeShop.menu = menu;
            CofeeShop.orders = orders;
        }
        public string name;
        public static List<MenuItem> menu = new List<MenuItem>();
        public static List<string> orders = new List<string>();
        public static void showCheapestItem()
        {
            string cheapestOrder = CofeeShopDL.getCheapestOrder();
            CofeeShopUI.printCheapestItem(cheapestOrder);
        }
        public static bool addOrder()
        {
            string order = CofeeShopUI.takeInputForOrder();
            if (CofeeShopDL.addOrder(order))
            {
                return true;
            }
            return false;
        }
        public static void fullFillOrder()
        {
            if (!CofeeShopDL.isOrderListEmpty())
            {
                CofeeShopUI.showItemReadyStatus(true, orders[0]);
                CofeeShopDL.removeFirstOrderItem();
            }
            else
            {
                CofeeShopUI.showItemReadyStatus(false, "");
            }
        }
        public static bool isItemAvailable(string itemName)
        {
            foreach (var it in CofeeShop.menu)
            {
                if (itemName == it.name)
                {
                    return true;
                }
            }
            return false;
        }
        public static int calculatePayableAmount()
        {
            int amount = 0;
            if (!CofeeShopDL.isOrderListEmpty())
            {
                foreach (var s in CofeeShop.orders)
                {
                    foreach(var m in menu)
                    {
                        if(s == m.name)
                        {
                            amount = amount + m.price;
                        }
                    }
                }
            }
            return amount;
        }
    }
}
