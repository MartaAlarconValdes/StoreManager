using Logic;
using Logic.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StoreManager
{
    public partial class Form1 : Form
    {
        private Products products;
        public Form1()
        {
            InitializeComponent();

            var listTextBox = new List<TextBox>();
            listTextBox.Add(textBoxID);
            listTextBox.Add(textBoxName);
            listTextBox.Add(textBoxPrice);
            listTextBox.Add(textBoxStock);

            var listLabel = new List<Label>();
            listLabel.Add(labelID);
            listLabel.Add(labelName);
            listLabel.Add(labelPrice);
            listLabel.Add(labelStock);

            var listSearch = new List<TextBox>();
            listSearch.Add(textBoxSearchID);
            listSearch.Add(textBoxSearchName);
            listSearch.Add(textBoxSearchPrice);
            listSearch.Add(textBoxSearchStock);

            var listUpdate = new List<TextBox>();
            listUpdate.Add(textBoxIDUpdate);
            listUpdate.Add(textBoxNameUpdate);
            listUpdate.Add(textBoxPriceUpdate);
            listUpdate.Add(textBoxStockUpdate);

            products = new Products(listTextBox, listLabel, dataGridView, listSearch, listUpdate);
            products.ShowProducts();

        }


        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.numKeyPress(e);
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.textKeyPress(e);
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.decimalKeyPress(e);
        }

        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.numKeyPress(e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            products.CreateProduct();
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxID.Text != "")
            {
                labelID.Text = "ID";
                labelID.ForeColor = Color.Sienna;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                labelName.Text = "Name";
                labelName.ForeColor = Color.Sienna;
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrice.Text != "")
            {
                labelPrice.Text = "Price";
                labelPrice.ForeColor = Color.Sienna;
            }
        }

        private void textBoxStock_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStock.Text != "")
            {
                labelStock.Text = "Stock";
                labelStock.ForeColor = Color.Sienna;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            products.SelectProductByNameOrID(textBoxSearch.Text);
            textBoxSearch.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            products.UpdateProduct();
        }

        private void textBoxIDUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.numKeyPress(e);
        }

        private void textBoxNameUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.textKeyPress(e);
        }

        private void textBoxPriceUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.decimalKeyPress(e);
        }

        private void textBoxStockUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxEvent.numKeyPress(e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            products.DeleteProduct();
        }
    }
}
