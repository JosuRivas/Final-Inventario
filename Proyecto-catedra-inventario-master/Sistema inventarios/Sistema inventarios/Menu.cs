using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventarios
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }

       private void AbrirFormulario<Miform>() where Miform : Form, new()
        {
            Form formulario;
            formulario = panelFormularios.Controls.OfType<Miform>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new Miform();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
        private void btCerrar_Click(object sender, EventArgs e)
        {
            Login irLogin = new Login();
            this.Visible = false;
            irLogin.Visible = true;
        }

        private void btIngreso_Click(object sender, EventArgs e)
        {
            AbrirFormulario<IngresoActivos>();
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Busqueda>();
        }

        private void btRegistros_Click(object sender, EventArgs e)
        {
            AbrirFormulario<RegistrosTotales>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Retiro_de_Activos>();
        }

        private void panelBarra_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void btTranseferir_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Traslado>();
        }
        private void panelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Editar>();
        }
    }
}
