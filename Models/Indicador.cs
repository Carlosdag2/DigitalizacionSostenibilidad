using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DigitalizacionSostenibilidad.Models
{
    [Table("Indicador")]
    public class Indicador
    {
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Valor { get; set; } = null!;
        public string? Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Ambito { get; set; } = null!;
    }
}
