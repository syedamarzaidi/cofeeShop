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
            setType(type);
            setPrice(price);
        }
        private string name;
        private string type;
        private int price;
        public string getItemName()
        {
            return name;
        }
        public string getItemType()
        {
            return type;
        }
        public int getItemPrice()
        {
            return price;
        }
        public void setPrice(int price)
        {
            if(price > 0)
            {
                this.price = price;
            }
        }
        public void setType(string type)
        {
            if (type == "FOOD" || type == "DRINK")
            {
                this.type = type;
            }
            else
            {
                this.type = "FOOD";
            }
        }
    }
}
