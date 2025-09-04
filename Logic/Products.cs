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

        public Products(List<TextBox> listTextBox, List<Label> listLabel)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
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
                var rows = db.Insert(new Product() // Insertar en base de datos

                {
                    ID = int.Parse(listTextBox[0].Text),
                    Name = listTextBox[1].Text,
                    Price = decimal.Parse(listTextBox[2].Text, CultureInfo.InvariantCulture), //Coge el punto como referencia para crear el decimal
                    Stock = int.Parse(listTextBox[3].Text),
                });

                //MessageBox.Show($"Filas insertadas: {rows}");
            }

            MessageBox.Show("Product inserted correctly ✅");
        }
   
    }
}

