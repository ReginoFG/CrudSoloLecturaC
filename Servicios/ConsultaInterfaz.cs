using CrudSoloLectura.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSoloLectura.Servicios
{
    /// <summary>
    /// Interfaz que define los métodos de consulta sobre base de datos
    /// </summary>
    /// <author>rfg - 101023</author>
    internal interface ConsultaInterfaz
    {
        /// <summary>
        /// Método que consulta sobre el catálogo de libros
        /// Si el isbn es vacío, se devuelve la información de todo el catálogo
        /// Si el isbn está informado, se busca el libro concreto
        /// </summary>
        /// <author>rfg - 101023</author>
        /// <param name="conexion"></param>
        /// <param name="listaLibrosObtenida"></param>
        /// <param name="isbnAConsultar"></param>
        /// <returns>Devuelve la lista de libros resultantes de la consulta</returns>
        public List<LibroDto> listarLibros(NpgsqlConnection conexion, List<LibroDto> listaLibrosObtenida, String isbnAConsultar);
    }
}
