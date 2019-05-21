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
    public partial class Login : Form
    {
        private string usuario, password;
        private string sCn;
        private SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            Conexion.conectar();
            sCn = Conexion.cadena;
            conn = new SqlConnection(sCn);
            GetUser();
        }
        private void GetUser()// verifica si ya hay un usuario en la base, si no hay ingresa el unico usuario del administrador del programa
        {
            try
            {
                SqlDataReader reader;
                SqlCommand InsertUser, LeerUser;
                conn.Open();
                bool Isnull = false;
                string query = "SELECT * FROM Usuarios";
                LeerUser = new SqlCommand(query, conn);
                reader = LeerUser.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(0) == DBNull.Value)
                    {
                        Isnull = true;
                    }
                }
                reader.Close();
                if (Isnull)
                {
                    string insert = "INSERT INTO Usuarios(CodigoUsuario,Nombre,Apellido,NombreUsuario,Contraseña,Permiso)";
                    insert += "VALUES(@CodigoUsuario,@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Permiso)";
                    InsertUser = new SqlCommand(insert, conn);
                    InsertUser.Parameters.Add(new SqlParameter("@CodigoUsuario", SqlDbType.Char));
                    InsertUser.Parameters["CodigoUsuario"].Value = '1';
                    InsertUser.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
                    InsertUser.Parameters["@Nombre"].Value = "Ana";
                    InsertUser.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar));
                    InsertUser.Parameters["@Apellido"].Value = "Larios";
                    InsertUser.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar));
                    InsertUser.Parameters["@NombreUsuario"].Value = "AnaLilian";
                    InsertUser.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar));
                    InsertUser.Parameters["@Contraseña"].Value = "UCSFIlourdes";
                    InsertUser.Parameters.Add(new SqlParameter("@Permiso", SqlDbType.Int));
                    InsertUser.Parameters["@Permiso"].Value = 1;
                    InsertUser.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser.Clear();
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
            txtPass.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader;
                SqlCommand LeerUser;
                conn.Open();
                string query = "SELECT * FROM Usuarios";
                LeerUser = new SqlCommand(query, conn);
                reader = LeerUser.ExecuteReader();
                while (reader.Read())
                {
                        usuario = reader.GetString(3);
                        password = reader.GetString(4);
                }
                reader.Close();
                conn.Close();
                if (txtUser.Text == usuario && txtPass.Text == password)
                {
                    Menu irMenu = new Menu();
                    this.Visible = false;
                    irMenu.Show();
                }
                if (txtPass.Text != password && txtUser.Text != usuario)
                {
                    MessageBox.Show("El usuario y contraseña ingresados son incorrectos", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtUser.Text != usuario)
                {
                    MessageBox.Show("El usuario ingresado es incorrecto", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtPass.Text != password)
                {
                    MessageBox.Show("La contraseña ingresada es incorrecta", "Error al ingresar al sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
