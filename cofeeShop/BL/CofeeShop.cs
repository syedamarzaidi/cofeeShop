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
            CofeeShopDL.setMenu(menu);
            CofeeShopDL.setOrders(orders);
        }
        private string name;
        public static void showCheapestItem()
        {
            string cheapestOrder = CofeeShopDL.getCheapestOrder();
            if (cheapestOrder != null)
            {
                CofeeShopUI.printCheapestItem(cheapestOrder);
            }
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
                CofeeShopUI.showItemReadyStatus(true, CofeeShopDL.getOrders()[0]);
                //CofeeShopDL.removeFirstOrderItem();
            }
            else
            {
                CofeeShopUI.showItemReadyStatus(false, "");
            }
        }
        public static bool isItemAvailable(string itemName)
        {
            foreach (var it in CofeeShopDL.getMenu())
            {
                if (itemName == it.getItemName())
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
                foreach (var s in CofeeShopDL.getOrders())
                {
                    foreach(var m in CofeeShopDL.getMenu())
                    {
                        if(s == m.getItemName())
                        {
                            amount = amount + m.getItemPrice();
                        }
                    }
                }
            }
            return amount;
        }
    }
}
