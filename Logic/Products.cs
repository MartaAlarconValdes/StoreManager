using Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic
{
    public class Products : Connection
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private DataGridView dataGridView;
        private Product product;
        private List<TextBox> listSearch;
        private List<TextBox> listUpdate;
        public Products(List<TextBox> listTextBox, List<Label> listLabel, DataGridView dataGridView, List<TextBox> listSearch, List<TextBox> listUpdate)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            this.dataGridView = dataGridView;
            this.listSearch = listSearch;
            this.listUpdate = listUpdate;
        }

        public void DeleteProduct()
        {
            using (var db = new Connection())
            {
                if (!string.IsNullOrWhiteSpace(listSearch[0].Text))
                {
                    var product = _Product
                        .Where(p => p.ID.ToString() == listSearch[0].Text).FirstOrDefault();

                    db.Delete(product);
                    ShowProducts();

                    foreach (var tb in listUpdate)
                            tb.Text = string.Empty;

                        foreach (var tb in listSearch)
                            tb.Text = string.Empty;
                    
                }
            }
        }

        public void UpdateProduct()
        {
            bool hasError = false;

            for (int i = 0; i < listUpdate.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(listUpdate[i].Text))
                {
                    if (!hasError) listTextBox[i].Focus(); // foco en el primer error
                    hasError = true;
                }

            }

            if (hasError) return;

            using (var db = new Connection())
            {
                if (!string.IsNullOrWhiteSpace(listSearch[0].Text))
                {
                    var product = _Product
                        .Where(p => p.ID.ToString() == listSearch[0].Text).FirstOrDefault();
                    if (product != null)
                    {
                        product.ID = int.Parse(listUpdate[0].Text);    
                        product.Name = listUpdate[1].Text;
                        product.Price = decimal.Parse(listUpdate[2].Text, CultureInfo.InvariantCulture);
                        product.Stock = int.Parse(listUpdate[3].Text);
                        db.Update(product);
                        ShowProducts();

                        foreach (var tb in listUpdate)
                            tb.Text = string.Empty;

                        foreach (var tb in listSearch)
                            tb.Text = string.Empty;
                    }
                }
            }
        }

        public void ShowProducts()
        {
            List<Product> query = new List<Product>();
            query = _Product.ToList();
            if (query.Count > 0) 
            {
                dataGridView.DataSource = query.Select(p => new
                {
                    p.nid,
                    p.ID,
                    p.Name,
                    p.Price,
                    p.Stock
                }).ToList();
            }
        }

        public void SelectProductByNameOrID(string search)
        {
            var product = _Product
                .Where(s => s.ID.ToString() == search
                         || s.Name.ToUpper().Contains(search.ToUpper()))
                .FirstOrDefault();

            if (product != null)
            {
                listSearch[0].Text = product.ID.ToString();
                listSearch[1].Text = product.Name;
                listSearch[2].Text = product.Price.ToString(CultureInfo.InvariantCulture);
                listSearch[3].Text = product.Stock.ToString();
            }
            else
            {
                MessageBox.Show("No products found");
                foreach (var tb in listSearch)
                    tb.Text = string.Empty;
            }
        }



        public void CreateProduct()
        {
            bool hasError = false;

            for (int i = 0; i < listTextBox.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(listTextBox[i].Text))
                {
                    listLabel[i].Text = "Required parameter";
                    listLabel[i].ForeColor = Color.Red;
                    if (!hasError) listTextBox[i].Focus(); // foco en el primer error
                    hasError = true;
                }
                
            }

            if (hasError) return; // si hay errores, no sigo

            // MessageBox.Show(
            //    $"ID: {listTextBox[0].Text}, " +
            //    $"Name: {listTextBox[1].Text}, " +
            //    $"Price: {listTextBox[2].Text}, " +
            //    $"Stock: {listTextBox[3].Text}"
            // );

            using (var db = new Connection())
            {
                BeginTransactionAsync();
                try
                {
                    var rows = db.Insert(new Product() // Insertar en base de datos

                    {
                        ID = int.Parse(listTextBox[0].Text),
                        Name = listTextBox[1].Text,
                        Price = decimal.Parse(listTextBox[2].Text, CultureInfo.InvariantCulture), //Coge el punto como referencia para crear el decimal
                        Stock = int.Parse(listTextBox[3].Text),
                    });
                    CommitTransaction();
                    ShowProducts();
                    //MessageBox.Show($"Filas insertadas: {rows}");

                    for (int i = 0; i < listTextBox.Count; i++)
                    {
                        listTextBox[i].Text = string.Empty;
                    }
                }
                catch (Exception)
                {
                    RollbackTransaction();
                }
                
            }

            
        }
   
    }
}

