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
    public partial class InsertarLibro : Form
    {
        public InsertarLibro()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

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

        // cuando le damos a aceptar, se insertará el libro
        private void button1_Click(object sender, EventArgs e)
        {
            int id_editorial;
            int id_autor;
            int contador = 0;
            if (validar())
            {
                Bd miBd = new Bd();

                // tenemos que obtener el ID del autor y la editorial del libro que intenta insertar
                id_editorial = miBd.searchEditorial(textBox6.Text); // con este método obtendremos el id de la editorial
                id_autor = miBd.searchAutor(textBox5.Text);// método para obtener el id del autor
                // en caso de que el resultado sea bueno
                if (id_editorial != -1)
                {
                    contador++;

                } else if (id_editorial <0)
                {
                    // saltará la ventana de si desea agregar una nueva editorial
                    agregarEditorial ae = new agregarEditorial();
                    ae.ShowDialog();
                }
                if (id_autor != -1)
                {
                    contador++;
                }
                else if(id_autor <0)
                {
                    // saltará la ventana de si desea agregar un nuevo autor
                    agregarAutor aa = new agregarAutor();

                    aa.ShowDialog();
                }

                if (contador == 2)
                {
                    Libro miLibro = new Libro(Convert.ToInt32(textBox1.Text), id_autor, id_editorial, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text));
                    miBd.insertarLibro(miLibro);
                    MessageBox.Show("El libro se ha insertado correctamente");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario, debes rellenar los campos para poder insertar un autor");
            }
        }
    }
}
