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
    public partial class Retiro_de_Activos : Form
    {
        private SqlConnection conn;
        private string sCn;
        private SqlDataAdapter adapter;
        SqlCommand eliminar,eliminar2;
        public Retiro_de_Activos()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
        }
        private void actualizarGrid()
        {
            try
            {
                datagridactivo.DataSource = null;
                conn.Open();
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter("SELECT * FROM Activos WHERE codigoActivo = '" + txtcodigo.Text + "'", conn);
                adapter.Fill(dt);
                datagridactivo.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarGrid();
                conn.Open();
                DialogResult d = MessageBox.Show("Esta seguro que desea eliminar este elemento?", "Alerta", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    string delete2 = "DELETE FROM Traslados WHERE codigoActivo = '" + txtcodigo.Text + "'";
                    eliminar2 = new SqlCommand(delete2, conn);
                    eliminar2.ExecuteNonQuery();
                    string delete = "DELETE FROM Activos WHERE codigoActivo = '" + txtcodigo.Text + "'";
                    eliminar = new SqlCommand(delete, conn);
                    eliminar.ExecuteNonQuery();
                    MessageBox.Show("El elemento ha sido retirado del sistema con exito");
                    datagridactivo.DataSource = null;
                    conn.Close();
                    txtcodigo.Clear();
                }
                else if (d == DialogResult.No)
                {
                    conn.Close();
                    txtcodigo.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
