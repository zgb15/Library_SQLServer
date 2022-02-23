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
    public partial class ModificarLibro : Form
    {
        public ModificarLibro()
        {
            InitializeComponent();
        }

        // cuando le damos a SALIR se cierra la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cuando le damos a RESETEAR se ponen todos los textbox vacíos
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }


        // comprobar que los campos se hayan rellenado
        private Boolean validar()
        {
            Boolean val = false;
            int contador = 0;

            if (textBox1.Text.Length != 0)
            {
                contador++;
            }
            if (textBox2.Text.Length != 0)
            {
                contador++;
            }
            if (textBox3.Text.Length != 0)
            {
                contador++;
            }
            if (textBox4.Text.Length != 0)
            {
                contador++;
            }
            if (textBox5.Text.Length != 0)
            {
                contador++;
            }
            if (textBox6.Text.Length != 0)
            {
                contador++;
            }

            if (contador == 6)
            {
                val = true;
            }
            return val;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            int idLibro;

            idLibro = Int32.Parse(textBox1.Text); // parseamos a int el String del textbox del ID

            if (validar())
            {
                Libro miLibro = new Libro(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text));
                Bd miBd = new Bd();
                miBd.modificarLibro(miLibro, idLibro); // pasamos por parámetro el objeto miAutor y su ID, para buscarlo en la tabla
                MessageBox.Show("El libro se ha modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder modificar un libro");
            }
        }
    }
}
