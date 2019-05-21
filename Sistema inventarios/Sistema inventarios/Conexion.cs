using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_inventarios
{
    class Conexion
    {
        private SqlConnection conexion = new SqlConnection("Server=" + server + ";DataBase=Inventarios;Integrated Security=true;MultipleActiveResultSets=True");

        public SqlConnection Abrirconexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
        public static string BD;
        public static string server, MiServidor;
        public static string cadena;
        public static string clave, user;

        public static void conectar()
        {
            server = "localhost";
            BD = "Inventarios"; user = "sa"; clave = "123456";
            cadena = "server=" + server + ";uid=" + user + ";pwd=" + clave + ";database=" + BD;
        }
        public static void instanInstaladas()
        {

            Microsoft.Win32.RegistryKey baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64);
            Microsoft.Win32.RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");

            foreach (string s in key.GetValueNames())
            {

                if (s == "MSSQLSERVER")
                {
                    MiServidor = "(local)";
                }
                else
                {
                    MiServidor = @"(local)\" + s;
                }

            }

        }
    }
}
