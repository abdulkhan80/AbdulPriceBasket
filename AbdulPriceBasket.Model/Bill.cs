using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdulPriceBasket.Model
{
    public class Bill
    {
        public decimal? SubTotal { get; set; }
        public string Offer { get; set; }
        public decimal Discount { get; set; }
        public decimal? Total { get; set; }
    }
}
