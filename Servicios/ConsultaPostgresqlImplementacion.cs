using CrudSoloLectura.Dtos;
using CrudSoloLectura.Util;
using Npgsql;


namespace CrudSoloLectura.Servicios
{
    /// <summary>
    /// Implementación de la interfaz de consultas sobre postgresql
    /// </summary>
    /// <author>rfg - 101023</author>
    internal class ConsultaPostgresqlImplementacion : ConsultaInterfaz
    {
        public List<LibroDto> listarLibros(NpgsqlConnection conexion, List<LibroDto> listaLibrosObtenida, string isbnAConsultar)
        {
            ADto aDto = new ADto();
            if (!String.IsNullOrEmpty(isbnAConsultar))
            {
                try
                {
                    //Se define y ejecuta la consulta Select
                    NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"gbp_almacen\".\"gbp_alm_cat_libros\" WHERE isbn = @isbn", conexion);
                    consulta.Parameters.AddWithValue("@isbn", isbnAConsultar);
                    NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                    //Paso de DataReader a lista de alumnoDTO
                    listaLibrosObtenida = aDto.readerALibroDto(resultadoConsulta);
                    resultadoConsulta.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-ConsultasPostgresqlImplementacion-listarLibros] Error al ejecutar consulta de libro particular: " + e);
                }
            }
            else
            {
                try
                {
                    //Se define y ejecuta la consulta Select
                    NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"gbp_almacen\".\"gbp_alm_cat_libros\"", conexion);
                    NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                    //Paso de DataReader a lista de alumnoDTO
                    listaLibrosObtenida = aDto.readerALibroDto(resultadoConsulta);
                    resultadoConsulta.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-ConsultasPostgresqlImplementacion-listarLibros] Error al ejecutar consulta de todos los libros: " + e);
                }
            }
            
            return listaLibrosObtenida;

        }
    }
}
