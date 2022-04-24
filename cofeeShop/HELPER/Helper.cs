using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.DL;

namespace cofeeShop.HELPER
{
    class Helper
    {
        public bool isItemExist(string name)
        {
            foreach (var item in CofeeShopDL.getMenu())
            {
                if (name == item.getItemName())
                {
                    return true;
                }
            }
            return false;
        }
        public static void tempStop()
        {
            Console.WriteLine("Press any key to continue............");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
