namespace SistemaLegadoApp.Models
{
    public class LegacyRecord : BaseModel
    {
        public string CodigoLegacy { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}