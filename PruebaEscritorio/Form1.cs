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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido usuario");
        }
        private void insertarToolStringMenuItem_click(object sender, EventArgs e)
        {
            InsertarAutor ia = new InsertarAutor();
            ia.ShowDialog();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ConsultarAutor ca = new ConsultarAutor();
            ca.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ModificarAutor ma = new ModificarAutor();
            ma.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            EliminarAutor ea = new EliminarAutor();
            ea.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            formsEditorial.EliminarEditorial ee = new formsEditorial.EliminarEditorial();
            ee.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            formsEditorial.InsertarEditorial ie = new formsEditorial.InsertarEditorial();
            ie.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            formsEditorial.ModificarEditorial me = new formsEditorial.ModificarEditorial();
            me.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            formsEditorial.ConsultarEditorial ce = new formsEditorial.ConsultarEditorial();
            ce.ShowDialog();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            formsLibro.InsertarLibro il = new formsLibro.InsertarLibro();
            il.ShowDialog();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            formsLibro.ModificarLibro ml = new formsLibro.ModificarLibro();
            ml.ShowDialog();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            formsLibro.EliminarLibro el = new formsLibro.EliminarLibro();
            el.ShowDialog();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            formsLibro.ConsultarLibro cl = new formsLibro.ConsultarLibro();
            cl.ShowDialog();
        }
    }
}
