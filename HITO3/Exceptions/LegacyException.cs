using System;

namespace SistemaLegadoApp.Exceptions
{
    public class LegacyException : Exception
    {
        public LegacyException(string message) : base(message) { }
        public LegacyException(string message, Exception innerException) : base(message, innerException) { }
    }
}