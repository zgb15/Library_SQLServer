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

namespace PruebaEscritorio.formsEditorial
{
    public partial class ModificarEditorial : Form
    {
        public ModificarEditorial()
        {
            InitializeComponent();
        }

        // botón restear, ponemos todos los campos en blanco
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        // cuando le damos a SALIR cerramos la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // hacemos un método que comprueba si los campos están rellenados
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
            if (contador == 3)
            {
                val = true;
            }

            return val;
        }

        // botón aceptar
        private void button1_Click(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            int posicion;

            posicion = Int32.Parse(textBox1.Text); // parseamos a int el String del textbox del ID

            if (validar())
            {
                Editorial miEditorial = new Editorial(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
                Bd miBd = new Bd();
                miBd.modificarEditorial(miEditorial, posicion); // pasamos por parámetro el objeto miEditorial y su ID, para buscarlo en la tabla
                MessageBox.Show("La editorial se ha modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder modificar una editorial");
            }
        }
    }
}
