using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Libreria;

namespace PruebaEscritorio
{
    public partial class ConsultarAutor : Form
    {
        int contador = 0;
        ArrayList listaAutores = new ArrayList();

        public ConsultarAutor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        // cargamos el primer registro que aparezca en la tabla en los textBox del formulario
        private void ConsultarAutor_Load(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            Autor autor = null; 

            listaAutores = bd.cargaAutores();

            if (listaAutores.Count != 0)
            {
                autor = (Autor)listaAutores[contador];
                textBox1.Text = Convert.ToString(autor.getId_autor());
                textBox2.Text = autor.getNombre();
                textBox3.Text = autor.getApellidos();
                textBox4.Text = autor.getNacionalidad();
                dateTimePicker1.Value = Convert.ToDateTime(autor.getF_nacimiento());
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar");
            }
        }

        // en el botón SALIR cerramos la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cuando clickamos en el botón SIGUIENTE haremos que aparezcan los demás registros, uno por uno
        private void button4_Click(object sender, EventArgs e)
        {
            Autor autor = null;
            if (contador < listaAutores.Count)
            {
                contador++;
                autor = (Autor)listaAutores[contador];
                textBox1.Text = Convert.ToString(autor.getId_autor());
                textBox2.Text = autor.getNombre();
                textBox3.Text = autor.getApellidos();
                textBox4.Text = autor.getNacionalidad();
                dateTimePicker1.Value = Convert.ToDateTime(autor.getF_nacimiento());
            }
            else
            {
                MessageBox.Show("No hay más autores");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
