using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainsystem
{
    internal class SQLPOS1CClass
    {
        // Properties
        public double discount_amt { get; set; }
        public double discounted_amt { get; set; }
        public double discountRate { get; set; }
        public int qty { get; set; }
        public double price { get; set; }

        // Totals
        public double total_qty { get; set; }
        public double total_discount { get; set; }
        public double total_discounted { get; set; }

        // Methods
        /*public bool ConvertQuantityPrice(TextBox qtyTxtbox, TextBox priceTxtbox)
        {
            if (!int.TryParse(qtyTxtbox.Text, out int q) || q <= 0) return false;
            if (!double.TryParse(priceTxtbox.Text, out double p) || p <= 0) return false;

            qty = q;
            price = p;
            return true;
        }

        public void Compute(TextBox qtyTxtbox, TextBox priceTxtbox,
                    TextBox discountTxtbox, TextBox discountedTxtbox)
        {
            if (!ConvertQuantityPrice(qtyTxtbox, priceTxtbox)) return;

            discount_amt = (qty * price) * discountRate;
            discounted_amt = (qty * price) - discount_amt;

            discountTxtbox.Text = discount_amt.ToString("N2");
            discountedTxtbox.Text = discounted_amt.ToString("N2");
        }


        public void UpdateTotals(TextBox qtyTotalTxtbox, TextBox discountTotalTxtbox, TextBox discountedTotalTxtbox)
        {
            // Accumulate values
            total_qty += qty;
            total_discount += discount_amt;        // ⬅ add the per-item discount to running total
            total_discounted += discounted_amt;    // ⬅ add the per-item discounted amount

            // Update UI
            qtyTotalTxtbox.Text = total_qty.ToString("N0");
            discountTotalTxtbox.Text = total_discount.ToString("N2");   // Running total of all discounts
            discountedTotalTxtbox.Text = total_discounted.ToString("N2");
        }

        public void ClearQuantity(TextBox qtyTxtbox)
        {
            qtyTxtbox.Text = "0";
        }

        public void ClearAllTotals()
        {
            total_qty = 0;
            total_discount = 0;
            total_discounted = 0;
        }

        public void SetItem(TextBox itemNameTxtbox, TextBox priceTxtbox, string itemName, string price)
        {
            itemNameTxtbox.Text = itemName;
            priceTxtbox.Text = price;
        }*/
    }
}
