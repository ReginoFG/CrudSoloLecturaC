using Npgsql;


namespace CrudSoloLectura.Servicios
{
    /// <summary>
    /// Interfaz que declara los métodos relacionados con la conexión
    /// a base de datos
    /// <author> rfg - 051023</author>
    /// </summary>
    internal interface ConexionInterfaz
    {
        /// <summary>
        /// Método que genera una conexión sobre base de datos
        /// BD según la implementación
        /// </summary>
        /// <author> rfg - 051023</author>
        /// <returns>Devuelve un tipo Connection de la base
        /// de datos de la implementación</returns>
        public NpgsqlConnection generarConexion();

        /// <summary>
        /// Método que cierra la conexión sobre base de datos
        /// </summary>
        /// <author> rfg - 101023</author>
        /// <param name="conexion">Conexión a cerrar</param>
        public void cerrarConexion(NpgsqlConnection conexion);

    }
}
