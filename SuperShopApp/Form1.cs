using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopApp
{

    public partial class Form1 : Form
    {
        public string showDetails;
        ShopInformation shop= new ShopInformation();
        ProductInformation product = new ProductInformation();

        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            shop.Name = nameTextBox.Text;
            shop.Address = addressTextBox.Text;


            nameTextBox.Clear();
            addressTextBox.Clear();
           
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            product.ProductId = productTextBox.Text;
            product.Quantity = Convert.ToInt32(quantityTextBox.Text);
            if (shop.ProductDictionary.ContainsKey(product.ProductId))
            {
                shop.ProductDictionary[product.ProductId] = product.Quantity;
            }
            else
            {
                shop.ProductDictionary.Add(product.ProductId, product.Quantity);
            }
            productTextBox.Clear();
            quantityTextBox.Clear();

        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            
                foreach (KeyValuePair<string, int> kvalue in shop.ProductDictionary)
                {
                    product.ProductId = kvalue.Key;
                    product.Quantity = kvalue.Value;
                    showDetails =  product.GetProductInfo();
                }
                MessageBox.Show(shop.GetShopInfo()  + showDetails);

            
        }


        


    }
}
