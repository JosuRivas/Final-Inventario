using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Sistema_inventarios
{
    public partial class RegistrosTotales : Form
    {
        private SqlConnection conn;
        private string sCn;
        private SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public RegistrosTotales()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
        }

        protected void actualizarGrid()
        {
            try
            {
                datagridRegistros.DataSource = null;
                conn.Open();
                adapter = new SqlDataAdapter("SELECT * FROM Activos", conn);
                adapter.Fill(dt);
                datagridRegistros.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void RegistrosTotales_Load(object sender, EventArgs e)
        {
            actualizarGrid();
        }
    }
}
