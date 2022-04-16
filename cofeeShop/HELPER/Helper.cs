using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cofeeShop.BL;

namespace cofeeShop.HELPER
{
    class Helper
    {
        public bool isItemExist(string name)
        {
            foreach (var item in CofeeShop.menu)
            {
                if (name == item.name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
