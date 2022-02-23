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

namespace PruebaEscritorio
{
    public partial class EliminarAutor : Form
    {
        public EliminarAutor()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // ponemos el campo del ID vacío en el botón resetear
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        // cerramos la ventana en el botón SALIR
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        // cuando le damos al botón de ACEPTAR ejecutamos el método eliminarAutor
        private void button1_Click(object sender, EventArgs e)
        {
            int numero = 0;
            if (validar())
            {
                numero = Int32.Parse(textBox1.Text); // parseamos a int el texto que haya en el campo del ID
                Bd miBd = new Bd();
                miBd.eliminarAutor(numero); // pasamos por parámetro el ID que ha introducido el usuario una vez parseado
                MessageBox.Show("El autor se ha eliminado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar el campo ID para poder eliminar un autor");
            }
        }
    }
}
