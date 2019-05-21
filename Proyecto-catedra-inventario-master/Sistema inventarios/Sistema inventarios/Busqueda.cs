using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;

namespace Sistema_inventarios
{
    public partial class Busqueda : Form
    {
        private SqlConnection conn;
        private string sCn;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;
        Hashtable thash = new Hashtable();
        SqlCommand leerDatos;

        public Busqueda()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
            
            
        }
        private void actualizarGrid()
        {
            Activo activo = new Activo();
            try
            {
                datagridBusqueda.DataSource = null;
                conn.Open();
                DataTable dt = new DataTable();
                string query = "SELECT Activos.CodigoActivo, Descripcion, Ubicacion, NombreMarca, Modelo, Serie, Estado, Color, FechaAdquisicion, ValorAdquisicion, Observacion, Caracteristicas, ResponsableTraslado  FROM Activos INNER JOIN Traslados ON Activos.CodigoActivo = Traslados.CodigoActivo";
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                datagridBusqueda.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
           
        }
        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btBusqueda_Click(object sender, EventArgs e)
        {
            actualizarGrid();
            txtBusqueda.Clear();
        }
    }
}
