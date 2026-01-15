using DigitalizacionSostenibilidad.Models;
using Microsoft.EntityFrameworkCore;


namespace DigitalizacionSostenibilidad.Data
{
    public class DigitalizacionContext : DbContext
    {
        public DigitalizacionContext(DbContextOptions<DigitalizacionContext> options)
            : base(options)
        {
        }


        public DbSet<Indicador> Indicadores { get; set; }
    }
}
