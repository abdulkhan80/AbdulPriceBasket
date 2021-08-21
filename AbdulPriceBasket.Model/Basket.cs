using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdulPriceBasket.Model
{
    public class Basket
    {
        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }
        public int ItemQty { get; set; }
    }
}
