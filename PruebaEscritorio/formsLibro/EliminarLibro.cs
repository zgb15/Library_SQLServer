using Libreria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEscritorio.formsLibro
{
    public partial class EliminarLibro : Form
    {
        public EliminarLibro()
        {
            InitializeComponent();
        }

        // cuando pulsamos en el botón SALIR se cierra la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cuando pulsamos en RESETEAR
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        // comprobamos que el usuario rellene el campo del ID
        private Boolean validar()
        {
            Boolean val = false;
            if (textBox1.Text.Length != 0)
            {
                val = true;
            }
            return val;
        }

        // cuando le damos a ACEPTAR eliminaremos el libro cuyo ID es el insertado
        private void button1_Click(object sender, EventArgs e)
        {
            int numero = 0;
            if (validar())
            {
                numero = Int32.Parse(textBox1.Text); // parseamos a int el texto que haya en el campo del ID
                Bd miBd = new Bd();
                miBd.eliminarLibro(numero); // pasamos por parámetro el ID que ha introducido el usuario una vez parseado
                MessageBox.Show("El libro se ha eliminado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar el campo ID para poder eliminar un libro");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
