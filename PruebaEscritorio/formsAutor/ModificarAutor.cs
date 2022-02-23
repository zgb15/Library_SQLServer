using Libreria;
using System;
using System.Collections;
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
    public partial class ModificarAutor : Form
    {
        ArrayList listaAutores = new ArrayList();

        public ModificarAutor()
        {
            InitializeComponent();
        }

        // comprobamos que los campos del formulario han sido rellenados
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           

        }

        // al pulsar en el botón SALIR cerramos la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cuando el usuario pincha en ACEPTAR 
        private void button1_Click(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            int idUsuario;

            idUsuario = Int32.Parse(textBox1.Text); // parseamos a int el String del textbox del ID

            if (validar())
            {
                Autor miAutor = new Autor(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value);
                Bd miBd = new Bd();
                miBd.modificarAutor(miAutor,idUsuario); // pasamos por parámetro el objeto miAutor y su ID, para buscarlo en la tabla
                MessageBox.Show("El autor se ha modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder modificar un autor");
            }
        }

        // si le damos al RESETEAR ponemos todos los campos vacíos
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
