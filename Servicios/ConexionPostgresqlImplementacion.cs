using Npgsql;
using System.Configuration;


namespace CrudSoloLectura.Servicios
{
    /// <summary>
    /// Implementación de la interfaz de conexión a base de datos para Postgresql
    /// </summary>
    /// <author>rfg - 101023</author>
    internal class ConexionPostgresqlImplementacion : ConexionInterfaz
    {
        public NpgsqlConnection generarConexion()
        {
            //Se lee la cadena de conexión a Postgresql del archivo de configuración
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            Console.WriteLine("[INFORMACIÓN-ConexionPostgresqlImplementacion-generarConexion] Cadena conexión: " + stringConexionPostgresql);

            NpgsqlConnection conexion = null;
            string estado = "";

            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    conexion = new NpgsqlConnection(stringConexionPostgresql);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    if (estado.Equals("Open"))
                    {

                        Console.WriteLine("[INFORMACIÓN-ConexionPostgresqlImplementacion-generarConexion] Estado conexión: " + estado);

                    }
                    else
                    {
                        conexion = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-ConexionPostgresqlImplementacion-generarConexion] Error al generar la conexión:" + e);
                    conexion = null;
                }
            }

            return conexion;
        }

        public void cerrarConexion(NpgsqlConnection conexion)
        {
            conexion.Close();
        }
    }
}
