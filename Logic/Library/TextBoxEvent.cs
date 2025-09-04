using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic.Library
{
    public static class TextBoxEvent
    {
        public static void textKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; } // permite utilizar letras
            //else if (char.IsDigit(e.KeyChar)) { e.Handled = false; } // permite utilizar números
            //else if (e.KeyChar == '.') { e.Handled = false; } // permite utilizar punto
            else if ( e.KeyChar == Convert.ToChar(Keys.Enter)) {  e.Handled = true; } // no permite salto de línea
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; } // permite utilizar backspace
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; } //permite utilizar el espacio
            else { e.Handled = true; }
        }
        public static void numKeyPress(KeyPressEventArgs e)
        {
            //if (char.IsLetter(e.KeyChar)) { e.Handled = false; } // permite utilizar letras
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; } // permite utilizar números
            //else if (e.KeyChar == '.') { e.Handled = false; } // permite utilizar punto
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; } // no permite salto de línea
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; } // permite utilizar backspace
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; } //permite utilizar el espacio
            else { e.Handled = true; }
        }

        public static void decimalKeyPress( KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; } // permite utilizar números
            else if (e.KeyChar == '.') { e.Handled = false; } // permite utilizar punto
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; } // no permite salto de línea
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; } // permite utilizar backspace
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; } //permite utilizar el espacio
            else { e.Handled = true; }
        }
    }
}
