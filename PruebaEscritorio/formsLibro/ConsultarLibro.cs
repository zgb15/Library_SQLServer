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

namespace PruebaEscritorio.formsLibro
{
    public partial class ConsultarLibro : Form
    {
        int contador = 0;
        ArrayList listaLibros = new ArrayList();

        public ConsultarLibro()
        {
            InitializeComponent();
        }

        // mostramos el primer libro al cargar la ventana
        private void ConsultarLibro_Load(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            Libro libro = null;

            listaLibros = bd.cargaLibros();

            if (listaLibros.Count != 0)
            {
                libro = (Libro)listaLibros[contador];
                textBox1.Text = Convert.ToString(libro.getId_libro());
                textBox2.Text = Convert.ToString(libro.getId_editorial());
                textBox3.Text = Convert.ToString(libro.getId_autor());
                textBox4.Text = libro.getTitulo();
                textBox5.Text = libro.getIsbn();
                textBox6.Text = Convert.ToString(libro.getNum_paginas());

            }
            else
            {
                MessageBox.Show("No hay datos para mostrar");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // si pulsamos en SALIR se cierra la ventana
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // al pulsar en SIGUIENTE se muestran los datos del siguiente libro del arraylist
        private void button3_Click(object sender, EventArgs e)
        {
            Libro libro = null;
            if (contador < listaLibros.Count)
            {
                contador++;
                libro = (Libro)listaLibros[contador];
                textBox1.Text = Convert.ToString(libro.getId_libro());
                textBox2.Text = Convert.ToString(libro.getId_editorial());
                textBox3.Text = Convert.ToString(libro.getId_autor());
                textBox4.Text = libro.getTitulo();
                textBox5.Text = libro.getIsbn();
                textBox6.Text = Convert.ToString(libro.getNum_paginas());
            }
            else
            {
                MessageBox.Show("No hay más libros");
            }
        }
    }
}
