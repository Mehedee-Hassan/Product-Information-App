using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Product_Information_App.BLL;
using Product_Information_App.DLL.DAO;

namespace Product_Information_App
{
    public partial class ProductInfoEntryForm : Form
    {
        public ProductInfoEntryForm()
        {
            InitializeComponent();
        }

        private Product aProduct;
        private ProductBll aProductBll;

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            aProduct = new Product(productNameTextBox.Text ,productCodeTextBox.Text ,Convert.ToDouble(quantityTextBox.Text));
            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();

            aProductBll = new ProductBll();
            products = aProductBll.ShowInListView();


            double total = 0;
            foreach (Product product in products)
            {
                ListViewItem aItem = new ListViewItem(product.Code);
                aItem.SubItems.Add(product.Name);
                aItem.SubItems.Add(product.Quantity.ToString());

                total += product.Quantity;

            }

            totalQuantityTextBox.Text = total.ToString();

        }

    }
}
