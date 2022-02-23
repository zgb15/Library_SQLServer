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

namespace PruebaEscritorio.formsEditorial
{
    public partial class ConsultarEditorial : Form
    {

        int contador = 0;
        ArrayList listaEditoriales = new ArrayList();

        public ConsultarEditorial()
        {
            InitializeComponent();
        }

        // botón SALIR cerramos la ventana
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cargamos el primer registro que aparezca en la tabla en los textBox del formulario
        private void ConsultarEditorial_Load(object sender, EventArgs e)
        {
            Bd bd = new Bd();

            Editorial editorial = null;

            listaEditoriales = bd.cargaEditoriales();

            if (listaEditoriales.Count != 0)
            {
                editorial = (Editorial)listaEditoriales[contador];
                textBox1.Text = Convert.ToString(editorial.getId_editorial());
                textBox2.Text = editorial.getNombre();
                textBox3.Text = editorial.getNacionalidad();
               
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar");
            }
        }

        // cuando pulsamos en siguiente aparecerán los siguientes registros
        private void button4_Click(object sender, EventArgs e)
        {
            Editorial editorial = null;
            if (contador < listaEditoriales.Count)
            {
                contador++;
                editorial = (Editorial)listaEditoriales[contador];
                textBox1.Text = Convert.ToString(editorial.getId_editorial());
                textBox2.Text = editorial.getNombre();
                textBox3.Text = editorial.getNacionalidad();
               
            }
            else
            {
                MessageBox.Show("No hay más editoriales");
            }
        }
    }
}
