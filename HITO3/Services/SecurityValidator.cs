using System.Text.RegularExpressions;

namespace SistemaLegadoApp.Services
{
    public static class SecurityValidator
    {
        public static bool ValidarCodigo(string codigo)
        {
            return !string.IsNullOrEmpty(codigo) && Regex.IsMatch(codigo, @"^[a-zA-Z0-9\-_]{3,20}$");
        }

        public static decimal ValidarMonto(string montoStr)
        {
            if (decimal.TryParse(montoStr, out decimal monto) && monto >= 0)
                return monto;
            
            throw new FormatException("El monto ingresado no es válido.");
        }
    }
}