using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    public class POSCalculator
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double DiscountRate { get; set; }

        // subtotal
        public double GetSubtotal()
        {
            return Price * Quantity;
        }

        // discount amount
        public double GetDiscount()
        {
            return GetSubtotal() * DiscountRate;
        }

        // discounted total
        public double GetDiscountedTotal()
        {
            return GetSubtotal() - GetDiscount();
        }

        // change
        public double GetChange(double amountPaid)
        {
            return amountPaid - GetDiscountedTotal();
        }
    }
internal class POS1Calculator
    {
    }
}
