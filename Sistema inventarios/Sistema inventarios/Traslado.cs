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
using System.Collections;

namespace Sistema_inventarios
{
    public partial class Traslado : Form
    {
        private SqlConnection conn;
        private string sCn;
        private SqlDataReader reader;
        
        SqlCommand leerDatos;
        string codigoTraslado = "1";
        public Traslado()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
        }

        private void retornarCodTraslado()
        {
            int codigoAct = 1;
            SqlDataReader reader;
            SqlCommand LeerCodigo;
            string query = "SELECT MAX(CAST(CodigoTraslado AS int)) FROM Traslados";
            LeerCodigo = new SqlCommand(query, conn);
            reader = LeerCodigo.ExecuteReader();
          
              while (reader.Read())
              {
                  if (reader.GetValue(0) != DBNull.Value)
                  {
                      codigoAct = reader.GetInt32(0) + 1;
                      codigoTraslado = codigoAct.ToString();
                  }
                  else
                  {
                    codigoAct = 1;
                    codigoTraslado = codigoAct.ToString();
                  }   
              }
            reader.Close();
        }
        private void LimpiarForm()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtEstado.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtResponsable.Clear();
            txtSerie.Clear();
            txtUbicacion.Clear();
        }
        private void btRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            Hashtable thash = new Hashtable();
            Activo activo = new Activo();
            conn.Open();
            string query = "SELECT CodigoActivo, Descripcion, Ubicacion, NombreMarca, Modelo, Serie, Estado FROM Activos";
            leerDatos = new SqlCommand(query, conn);
            reader = leerDatos.ExecuteReader();
            while (reader.Read())
            {
                if (reader["CodigoActivo"].ToString() == txtCodigo.Text)
                {
                    activo.descripcion = reader["Descripcion"];
                    activo.ubicacion = reader["Ubicacion"];
                    activo.nombreMarca = reader["NombreMarca"];
                    activo.modelo = reader["Modelo"];
                    activo.serie = reader["Serie"];
                    activo.estado = reader["Estado"];
                    thash.Add(reader["CodigoActivo"], activo);
                }
            }
            reader.Close();
            conn.Close();
            foreach (DictionaryEntry entry in thash)
            {
                if (entry.Key.ToString() == txtCodigo.Text)
                {
                    txtDescripcion.Text = activo.descripcion.ToString();
                    txtUbicacion.Text = activo.ubicacion.ToString();
                    txtEstado.Text = activo.estado.ToString();
                    txtMarca.Text = activo.nombreMarca.ToString();
                    txtModelo.Text = activo.modelo.ToString();
                    txtSerie.Text = activo.serie.ToString();
                }
            }
        }
        private void btAceptar_Click(object sender, EventArgs e)
        {
            SqlCommand Traslado, Actualizar;
            try
            {
                conn.Open();
                retornarCodTraslado();
                string InsertTraslado = "INSERT INTO Traslados(CodigoTraslado, CodigoActivo, FechaTraslado, UbicacionTraslado, ResponsableTraslado)";
                InsertTraslado += "VALUES (@CodigoTraslado, @CodigoActivo, @FechaTraslado, @UbicacionTraslado, @ResponsableTraslado)";
                Traslado = new SqlCommand(InsertTraslado, conn);
                Traslado.Parameters.Add(new SqlParameter("@CodigoTraslado", SqlDbType.Char));
                Traslado.Parameters["@CodigoTraslado"].Value = codigoTraslado;
                Traslado.Parameters.Add(new SqlParameter("@CodigoActivo", SqlDbType.Char));
                Traslado.Parameters["@CodigoActivo"].Value = txtCodigo.Text;
                Traslado.Parameters.Add(new SqlParameter("@FechaTraslado", SqlDbType.VarChar));
                Traslado.Parameters["@FechaTraslado"].Value = pickerFecha.Value.ToString("dd-MM-yyyy");
                Traslado.Parameters.Add(new SqlParameter("@UbicacionTraslado", SqlDbType.VarChar));
                Traslado.Parameters["@UbicacionTraslado"].Value = cboxUbicacion.SelectedItem;
                Traslado.Parameters.Add(new SqlParameter("@ResponsableTraslado", SqlDbType.VarChar));
                Traslado.Parameters["@ResponsableTraslado"].Value = txtResponsable.Text;
                Traslado.ExecuteNonQuery();

                string Update = "UPDATE Activos SET Ubicacion = '" + cboxUbicacion.SelectedItem + "' WHERE CodigoActivo = '" + txtCodigo.Text + "'";
                Actualizar = new SqlCommand(Update, conn);
                Actualizar.ExecuteNonQuery();
                MessageBox.Show("El elemento ha sido actualizado con exito");
                conn.Close();
                LimpiarForm();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void Traslado_Load(object sender, EventArgs e)
        {

        }
    }
}
