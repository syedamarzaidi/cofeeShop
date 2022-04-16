using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cofeeShop.BL
{
    class MenuItem
    {
        public MenuItem(string name, string type, int price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public string name;
        public string type;
        public int price;
    }
}
