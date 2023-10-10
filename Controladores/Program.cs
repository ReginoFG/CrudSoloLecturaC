using CrudSoloLectura.Servicios;
using Npgsql;
using CrudSoloLectura.Dtos;
using System;

namespace JdbcConexionPostgresql
{
    /// <summary>
    /// Clase principal de la aplicación
    /// 270923-rfg
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método main de la aplicación, puerta de entrada
        /// </summary>
        /// <author>rfg-270923</author>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConexionInterfaz conexionInterfaz = new ConexionPostgresqlImplementacion();
            MenuInterfaz menuInterfaz = new MenuImplementacion();
            ConsultaInterfaz consultaInterfaz = new ConsultaPostgresqlImplementacion();
             
            NpgsqlConnection conexion = null;
            conexion = conexionInterfaz.generarConexion();
            int opcionSeleccionada;
            bool cerrarMenu = false;
            List<LibroDto> listaLibros = new List<LibroDto>();

            while (!cerrarMenu)
            {
                opcionSeleccionada = menuInterfaz.mostrarMenuYSeleccion();
                Console.WriteLine(opcionSeleccionada);

                switch (opcionSeleccionada)
                {
                    case 0:
                        Console.WriteLine("[INFO] - Se ejecuta caso 0");
                        cerrarMenu = true;
                        break;
                    case 1:
                        listaLibros.Clear();
                        listaLibros=consultaInterfaz.listarLibros(conexion, listaLibros, "");
                        listarLibrosObtenidos(listaLibros);
                        break;
                    case 2:
                        listaLibros.Clear();
                        listaLibros = consultaInterfaz.listarLibros(conexion, listaLibros, "");
                        listarLibrosObtenidos(listaLibros);
                        listaLibros.Clear();
                        Console.WriteLine("¿Qué isbn quiere buscar?");
                        listaLibros = consultaInterfaz.listarLibros(conexion, listaLibros, Console.ReadLine());
                        listarLibrosObtenidos(listaLibros);
                        break;
                    default:
                        Console.WriteLine("[INFO] - La opcion seleccionada no coincide con ninguna.");
                        break;
                }

            }

            conexion.Close();

        }

        /// <summary>
        /// Método que lista por consola el listado de libros obtenidos tras las consultas
        /// </summary>
        /// <author>rfg - 101023</author>
        /// <param name="listaLibrosObtenida"></param>
        private static void listarLibrosObtenidos(List<LibroDto> listaLibrosObtenida)
        {
            if (listaLibrosObtenida.Count()>0)
            {
                foreach (LibroDto libro in listaLibrosObtenida)
                {
                    Console.WriteLine(libro.ToString());
                }
            }
            else
            {
                Console.WriteLine("[INFO] - No hay libros que mostrar");
            }
        }
    }
}
