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
    public partial class InsertarEditorial : Form
    {
        public InsertarEditorial()
        {
            InitializeComponent();
        }

        // cuando pulsamos en SALIR cerramos la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cuando pulsamos en RESETEAR vaciamos los campos de la formulario
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        // hacemos un método que comprueba si los campos están rellenados
        private Boolean validar()
        {
            Boolean val=false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Editorial miEditorial = new Editorial(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
                Bd miBd = new Bd();
                miBd.insertarEditorial(miEditorial);
                MessageBox.Show("La editorial se ha insertado correctamente");
                this.Close();

            } else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder insertar una editorial");
            }
        }
    }
}
