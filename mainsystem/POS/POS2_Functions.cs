using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace mainsystem
{
    public class POS2_Functions
    {
        public double total_amount { get; private set; } = 0;
        public int total_qty { get; private set; } = 0;

        private double currentItemLastAmount = 0.0;
        private int currentItemLastQuantity = 0;


        // Handle quantity change
        public void UpdateQuantity(TextBox qtyTxtbox,
                                   TextBox priceTxtBox,
                                   TextBox discountTxtbox,
                                   TextBox discountedTxtbox,
                                   TextBox totalBillsTxtbox,
                                   TextBox totalQtyTxtbox)
        {
            if (!double.TryParse(priceTxtBox.Text, out double price)) return;
            if (!int.TryParse(qtyTxtbox.Text, out int quantity)) quantity = 0;
            if (!double.TryParse(discountTxtbox.Text, out double discountAmt)) discountAmt = 0.0;

            double currentItemAmount = (price * quantity) - discountAmt;
            double amountDelta = currentItemAmount - currentItemLastAmount;
            int qtyDelta = quantity - currentItemLastQuantity;

            total_amount += amountDelta;
            total_qty += qtyDelta;

            currentItemLastAmount = currentItemAmount;
            currentItemLastQuantity = quantity;

            discountedTxtbox.Text = currentItemAmount.ToString("N2");
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        // Reset everything
        public void Reset(TextBox discountedTxtbox, TextBox totalBillsTxtbox,
                          TextBox totalQtyTxtbox, ListBox displayListbox)
        {
            total_amount = 0;
            total_qty = 0;
            currentItemLastAmount = 0.0;
            currentItemLastQuantity = 0;

            discountedTxtbox.Text = "0.00";
            totalBillsTxtbox.Text = "0.00";
            totalQtyTxtbox.Text = "0";
            displayListbox.Items.Clear();
        }
    }
}
