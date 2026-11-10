using System.IO;
using SistemaLegadoApp.Exceptions;

namespace SistemaLegadoApp.Services
{
    public class FileHandler
    {
        private readonly string _rutaArchivo = "datos_legados.txt";

        public void GuardarDato(string linea)
        {
            try
            {
                File.AppendAllText(_rutaArchivo, linea + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new LegacyException("Error al guardar el archivo de forma segura.", ex);
            }
        }
    }
}