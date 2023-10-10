using CrudSoloLectura.Dtos;
using Npgsql;


namespace CrudSoloLectura.Util
{
    internal class ADto
    {
        public List<LibroDto> readerALibroDto(NpgsqlDataReader resultadoConsulta)
        {
            List<LibroDto> listaLibros = new List<LibroDto>();
            while (resultadoConsulta.Read())
            {
                listaLibros.Add(new LibroDto(
                    long.Parse(resultadoConsulta[0].ToString()),
                    resultadoConsulta[1].ToString(),
                    resultadoConsulta[2].ToString(),
                    resultadoConsulta[3].ToString(),
                    (int)Int64.Parse(resultadoConsulta[4].ToString())
                    )
                    );

            }
            return listaLibros;
        }
    }
}
