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
    public partial class Editar : Form
    {
        private SqlConnection conn;
        private string sCn;
        private SqlDataReader reader;

        SqlCommand leerDatos;
        public Editar()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Hashtable thash = new Hashtable();
            Activo activo = new Activo();
            conn.Open();
            string query = "SELECT CodigoActivo, Descripcion, NombreMarca, Modelo, Serie, Estado, Color, Observacion, Caracteristicas FROM Activos";
            leerDatos = new SqlCommand(query, conn);
            reader = leerDatos.ExecuteReader();
            while (reader.Read())
            {
                if (reader["CodigoActivo"].ToString() == txtCodigo.Text)
                {
                    activo.descripcion = reader["Descripcion"];
                    activo.nombreMarca = reader["NombreMarca"];
                    activo.modelo = reader["Modelo"];
                    activo.serie = reader["Serie"];
                    activo.estado = reader["Estado"];
                    activo.color = reader["Color"];
                    activo.observacion=reader["Observacion"];
                    activo.caracteristicas = reader["Caracteristicas"];
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
                    txtMarca.Text = activo.nombreMarca.ToString();
                    txtModelo.Text = activo.modelo.ToString();
                    txtSerie.Text = activo.serie.ToString();
                    txtEstado.Text = activo.estado.ToString();
                    txtColor.Text = activo.color.ToString();
                    txtObservación.Text = activo.observacion.ToString();
                    txtCaracteristica.Text = activo.caracteristicas.ToString();
                }
            }
        }
        private void btRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            SqlCommand Actualizar;
            try
            {
                conn.Open();
                string Update = "UPDATE Activos SET Descripcion = '" + txtDescripcion.Text + "', NombreMarca = '" + txtMarca.Text + "', Modelo = '" + txtModelo.Text + "', Serie = '" + txtSerie.Text + "', Estado = '" + txtEstado.Text + "', Color = '" + txtColor.Text + "', Observacion = '" + txtObservación.Text + "', Caracteristicas = '" + txtCaracteristica.Text + "' WHERE CodigoActivo = '" + txtCodigo.Text + "'";
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
        private void LimpiarForm()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtEstado.Clear();
            txtColor.Clear();
            txtObservación.Clear();
            txtCaracteristica.Clear();
        }
    }
}

