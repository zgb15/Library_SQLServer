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
    public partial class InsertarAutor : Form
    {
        public InsertarAutor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // botón de salir cierra la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // botón resetear pone todos los campos vacíos
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
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
            if (contador == 4)
            {
                val = true;
            }
            return val;
        }

        // cuando le damos a aceptar se ejecuta el método de insertar
        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Autor miAutor = new Autor(Convert.ToInt32(textBox1.Text),textBox2.Text,textBox3.Text,textBox4.Text,dateTimePicker1.Value);
                Bd miBd = new Bd();
                miBd.insertarAutor(miAutor);
                MessageBox.Show("El autor se ha insertado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder insertar un autor");
            }
        }
    }
}
