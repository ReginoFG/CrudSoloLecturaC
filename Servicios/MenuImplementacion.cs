using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSoloLectura.Servicios
{
    /// <summary>
    /// Clase que implementa la interfaz de menú
    /// 250923 - rfg
    /// </summary>
    internal class MenuImplementacion : MenuInterfaz
    {
        public int mostrarMenuYSeleccion()
        {
            int opcionIntroducida;

            Console.WriteLine("#############################");
            Console.WriteLine("0. Cerra aplicacion");
            Console.WriteLine("1. Información de todos los libros");
            Console.WriteLine("2. Información de un libro");
            Console.WriteLine("#############################");
            Console.WriteLine("Seleccione una opcion: ");

            opcionIntroducida = Console.ReadKey(true).KeyChar - ('0');

            return opcionIntroducida;

        }
    }
}
