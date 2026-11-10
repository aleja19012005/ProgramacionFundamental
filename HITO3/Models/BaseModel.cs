namespace SistemaLegadoApp.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}