using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    public class POSCalculator
    {
        public double DiscountRate { get; set; }
        public double DiscountAmount { get; private set; }
        public double DiscountedAmount { get; private set; }

        public POSCalculator()
        {
            DiscountRate = 0.0;
        }

        public void ComputeDiscount(double price, int qty)
        {
            double subtotal = price * qty;
            DiscountAmount = subtotal * DiscountRate;
            DiscountedAmount = subtotal - DiscountAmount;
        }

        public double ComputeChange(double cash, double total)
        {
            return cash - total;
        }
    }
}
internal class POS1Calculator
{
}
