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

namespace Sistema_inventarios
{
    public partial class IngresoActivos : Form
    {
        private SqlConnection conn;
        private SqlCommand insertActivos;
        private string sCn;
        string codigoMarca = "1";
        string codigoFuente = "1";
        public IngresoActivos()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
           
        }
        private void InicioMarcas()// si no hay marcas en la base de datos, ingresa la marca por defecto, que es "No Aplica"
        {
           
           SqlCommand LeerCodigo, MarcaInicio;
           SqlDataReader reader;
           int codigoAct;
           bool Isnull = false;
           conn.Open();
           string query = "SELECT MAX(CAST(CodigoMarca AS int)) FROM Marcas";
           LeerCodigo = new SqlCommand(query, conn);
           reader = LeerCodigo.ExecuteReader();
             while (reader.Read())
               {
                 if (reader.GetValue(0) != DBNull.Value)
                  {
                    codigoAct = reader.GetInt32(0) + 1;
                    codigoMarca = codigoAct.ToString();
                  }
                 else
                  {
                    Isnull = true;
                  }     
               }
            reader.Close();
            if (Isnull)
            {
                string marcainicio = "INSERT INTO Marcas(CodigoMarca,NombreMarca)";
                marcainicio += "VALUES(@CodigoMarca,@NombreMarca)";
                MarcaInicio = new SqlCommand(marcainicio, conn);
                MarcaInicio.Parameters.Add(new SqlParameter("@CodigoMarca", SqlDbType.Char));
                MarcaInicio.Parameters["@CodigoMarca"].Value = '1';
                MarcaInicio.Parameters.Add(new SqlParameter("@NombreMarca", SqlDbType.VarChar));
                MarcaInicio.Parameters["@NombreMarca"].Value = "No Aplica";
                MarcaInicio.ExecuteNonQuery();
            }
            conn.Close();
        }
        private void InicioFuentes()// si no hay fuentes en la base de datos, ingresa la fuente por defecto en la base de datos que es "No aplica"
        {
            try
            {
                int codigoAct;
                bool IsNull = false;
                SqlCommand FuenteInicio, LeerCodigo;
                SqlDataReader reader;
                conn.Open();
                string query = "SELECT MAX(CAST(CodigoFuente AS int)) FROM Fuentes";
                LeerCodigo = new SqlCommand(query, conn);
                reader = LeerCodigo.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(0) != DBNull.Value)
                    {
                        codigoAct = reader.GetInt32(0) + 1;
                        codigoFuente = codigoAct.ToString();
                    }
                    else
                    {
                        IsNull = true;
                    }          
                }
                reader.Close();
                if (IsNull)
                {
                    string fuenteinicio = "INSERT INTO Fuentes(CodigoFuente,Fuente)";
                    fuenteinicio += "VALUES(@CodigoFuente,@Fuente)";
                    FuenteInicio = new SqlCommand(fuenteinicio, conn);
                    FuenteInicio.Parameters.Add(new SqlParameter("@CodigoFuente", SqlDbType.Char));
                    FuenteInicio.Parameters["@CodigoFuente"].Value = '1';
                    FuenteInicio.Parameters.Add(new SqlParameter("@Fuente", SqlDbType.VarChar));
                    FuenteInicio.Parameters["@Fuente"].Value = "No Aplica";
                    FuenteInicio.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
        }
        private void LlenarComboMarcas()// llena el combobox marcas con las marcas actuales en la base de datos
        {
            try
            { 
            cboxMarca.Items.Clear();
            
            conn.Open();
            SqlDataReader reader;
            string Query = "SELECT * FROM Marcas";
            SqlCommand select = new SqlCommand(Query, conn);
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    string nombres = reader.GetString(1);
                    cboxMarca.Items.Add(nombres);
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void LlenarComboFuentes()// lena el combobox fuentes con las fuentes actuales en la base de datos
        {
            try
            { 
            cboxFuente.Items.Clear();
            conn.Open();
            SqlDataReader reader;
            string Query = "SELECT * FROM Fuentes";
            SqlCommand select = new SqlCommand(Query, conn);
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    string fuentes = reader.GetString(1);
                    cboxFuente.Items.Add(fuentes);
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void retornarCodMarca() // retorna el ultimo codigo de marcas que hay en la base, y lo aumenta en uno, cuando se ingresa una nueva marca a la base
        {
            try
            {
                SqlDataReader readerCodigo;
                SqlCommand LeerCodigo;
                string query = "SELECT * FROM Marcas WHERE NombreMarca = '" + cboxMarca.SelectedItem.ToString() + "'";
                LeerCodigo = new SqlCommand(query, conn);
                readerCodigo = LeerCodigo.ExecuteReader();
                    while (readerCodigo.Read())
                    {
                        codigoMarca = readerCodigo.GetString(0);
                    }
                readerCodigo.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe llenar todos los espacios para continuar");
                conn.Close();
            }
        }
        private void retornarCodFuente()// retorna el ultimo codigo de fuentes que hay en la base, y lo aumenta en uno, cuando se ingresa una nueva fuente a la base
        {
            try
            {
                SqlDataReader reader;
                SqlCommand leercodigo;
                string query = "SELECT * FROM Fuentes WHERE Fuente = '" + cboxFuente.SelectedItem.ToString() + "'";
                leercodigo = new SqlCommand(query, conn);
                reader = leercodigo.ExecuteReader();
                while (reader.Read())
                {
                    codigoFuente = reader.GetString(0);
                }
                reader.Close();
            }
            catch (NullReferenceException)
            {
                 MessageBox.Show("Debe llenar todos los espacios para continuar");
                conn.Close();
            }
        }
        private void LimpiarForm()
        {
            txtCodigo.Clear();
            txtDescripción.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtColor.Clear();
            txtValorActual.Clear();
            txtValorAdquisicion.Clear();
            txtObservación.Clear();
            txtCaracteristica.Clear();
        }
        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 

        private void txtDescripción_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMarca_MouseClick(object sender, MouseEventArgs e)
        {
            txtMarca.Text = "";
        }

        private void txtFuente_MouseClick(object sender, MouseEventArgs e)
        {
            txtFuente.Text = "";
        }

        private void btMarca_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int codigoAct;
                SqlDataReader reader;
                SqlCommand MarcaNueva, LeerCodigo;
                string query = "SELECT MAX(CAST(CodigoMarca AS int)) FROM Marcas";
                LeerCodigo = new SqlCommand(query, conn);
                reader = LeerCodigo.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        codigoAct = reader.GetInt32(0) + 1;
                        codigoMarca = codigoAct.ToString();
                    }
                }
                reader.Close();
                string nuevaMarca = "INSERT INTO Marcas(CodigoMarca,NombreMarca)";
                nuevaMarca += "VALUES (@CodigoMarca,@NombreMarca)";
                MarcaNueva = new SqlCommand(nuevaMarca, conn);
                MarcaNueva.Parameters.Add(new SqlParameter("@CodigoMarca", SqlDbType.Char));
                MarcaNueva.Parameters["@CodigoMarca"].Value = codigoMarca;
                MarcaNueva.Parameters.Add(new SqlParameter("@NombreMarca", SqlDbType.VarChar));
                MarcaNueva.Parameters["@NombreMarca"].Value = txtMarca.Text;
                MarcaNueva.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Marca nueva ingresada con exito al sistema", "Ingresado con exito", MessageBoxButtons.OK);
                txtMarca.Clear();
                LlenarComboMarcas();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btFuente_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int codigoAct;
                SqlDataReader reader;
                SqlCommand FuenteNueva, LeerCodigo;
                string query = "SELECT MAX(CAST(CodigoFuente AS int)) FROM Fuentes";
                LeerCodigo = new SqlCommand(query, conn);
                reader = LeerCodigo.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        codigoAct = reader.GetInt32(0) + 1;
                        codigoFuente = codigoAct.ToString();
                    }
                }
                reader.Close();
                string nuevaFuente = "INSERT INTO Fuentes(CodigoFuente,Fuente)";
                nuevaFuente += "VALUES (@CodigoFuente,@Fuente)";
                FuenteNueva = new SqlCommand(nuevaFuente, conn);
                FuenteNueva.Parameters.Add(new SqlParameter("@CodigoFuente", SqlDbType.Char));
                FuenteNueva.Parameters["@CodigoFuente"].Value = codigoFuente;
                FuenteNueva.Parameters.Add(new SqlParameter("@Fuente", SqlDbType.VarChar));
                FuenteNueva.Parameters["@Fuente"].Value = txtFuente.Text;
                FuenteNueva.ExecuteNonQuery();
                conn.Close();
                LlenarComboFuentes();
                MessageBox.Show("Nueva fuente ingresada con exito al sistema", "Ingresado con exito", MessageBoxButtons.OK);
                txtFuente.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btIngresar_Click(object sender, EventArgs e)// ingresa el activo entero a la base de datos 
        {
            try
            {
                conn.Open();
                string Activos;
                retornarCodMarca();
                retornarCodFuente();
                Activos = "INSERT INTO Activos(CodigoActivo,CodigoMarca,CodigoFuente,Descripcion,Ubicacion,NombreMarca,Modelo,Serie,Estado,Color,FechaAdquisicion,ValorAdquisicion,ValorActual,Observacion,Caracteristicas)";
                Activos += "VALUES (@CodigoActivo,@CodigoMarca,@CodigoFuente,@Descripcion,@Ubicacion,@NombreMarca,@Modelo,@Serie,@Estado,@Color,@FechaAdquisicion,@ValorAdquisicion,@ValorActual,@Observacion,@Caracteristicas)";
                insertActivos = new SqlCommand(Activos, conn);
                insertActivos.Parameters.Add(new SqlParameter("@CodigoActivo", SqlDbType.Char));
                insertActivos.Parameters["@CodigoActivo"].Value = txtCodigo.Text;
                insertActivos.Parameters.Add(new SqlParameter("@CodigoMarca", SqlDbType.Char));
                insertActivos.Parameters["@CodigoMarca"].Value = codigoMarca;
                insertActivos.Parameters.Add(new SqlParameter("@CodigoFuente", SqlDbType.Char));
                insertActivos.Parameters["@CodigoFuente"].Value = codigoFuente;
                insertActivos.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar));
                insertActivos.Parameters["@Descripcion"].Value = txtDescripción.Text;
                insertActivos.Parameters.Add(new SqlParameter("@Ubicacion", SqlDbType.VarChar));
                insertActivos.Parameters["@Ubicacion"].Value = cboxUbicacion.SelectedItem;
                insertActivos.Parameters.Add(new SqlParameter("@NombreMarca", SqlDbType.VarChar));
                insertActivos.Parameters["@NombreMarca"].Value = cboxMarca.SelectedItem;
                insertActivos.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar));
                insertActivos.Parameters["@Modelo"].Value = txtModelo.Text;
                insertActivos.Parameters.Add(new SqlParameter("@Serie", SqlDbType.VarChar));
                insertActivos.Parameters["@Serie"].Value = txtSerie.Text;
                insertActivos.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar));
                insertActivos.Parameters["@Estado"].Value = cboxEstado.SelectedItem.ToString();
                insertActivos.Parameters.Add(new SqlParameter("@Color", SqlDbType.VarChar));
                insertActivos.Parameters["@Color"].Value = txtColor.Text;
                insertActivos.Parameters.Add(new SqlParameter("@FechaAdquisicion", SqlDbType.VarChar));
                insertActivos.Parameters["@FechaAdquisicion"].Value = FechaAdquirido.Value.ToString("dd-MM-yyyy");
                insertActivos.Parameters.Add(new SqlParameter("@ValorAdquisicion", SqlDbType.Money));
                insertActivos.Parameters["@ValorAdquisicion"].Value = double.Parse(txtValorAdquisicion.Text);
                insertActivos.Parameters.Add(new SqlParameter("@ValorActual", SqlDbType.Money));
                insertActivos.Parameters["@ValorActual"].Value = double.Parse(txtValorActual.Text);
                insertActivos.Parameters.Add(new SqlParameter("@Observacion", SqlDbType.VarChar));
                insertActivos.Parameters["@Observacion"].Value = txtObservación.Text;
                insertActivos.Parameters.Add(new SqlParameter("@Caracteristicas", SqlDbType.VarChar));
                insertActivos.Parameters["@Caracteristicas"].Value = txtCaracteristica.Text;
                insertActivos.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("El elemento fue agregado con exito al sistema", "Ingreso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarForm();
                
                
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe llenar todos los espacios para continuar");
                conn.Close();
            }
        }

        private void IngresoActivos_Load(object sender, EventArgs e) // procedimientos cuando carga el form
        {
            FechaAdquirido.Format = DateTimePickerFormat.Custom;
            FechaAdquirido.CustomFormat = "dd-MM-yyyy";
            InicioMarcas();
            InicioFuentes();
            LlenarComboMarcas();
            LlenarComboFuentes();
        }
    }
}
