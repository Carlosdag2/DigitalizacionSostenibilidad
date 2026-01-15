using DigitalizacionSostenibilidad.Data;
using DigitalizacionSostenibilidad.Models;


namespace DigitalizacionSostenibilidad.Repositories
{
    public class IndicadorRepository : IIndicadorRepository
    {
        private readonly DigitalizacionContext _context;


        public IndicadorRepository(DigitalizacionContext context)
        {
            _context = context;
        }


        public IEnumerable<Indicador> GetAll()
        {
            return _context.Indicadores.ToList();
        }


        public Indicador? GetById(int id)
        {
            return _context.Indicadores.Find(id);
        }


        public IEnumerable<Indicador> GetByTipo(string tipo)
        {
            return _context.Indicadores
                           .Where(i => i.Tipo == tipo)
                           .ToList();
        }


        public IEnumerable<Indicador> GetByCategoria(string categoria)
        {
            return _context.Indicadores
                           .Where(i => i.Categoria == categoria)
                           .ToList();
        }


        public IEnumerable<Indicador> GetByAmbito(string ambito)
        {
            return _context.Indicadores
                           .Where(i => i.Ambito == ambito)
                           .ToList();
        }


        public void Add(Indicador indicador)
        {
            _context.Indicadores.Add(indicador);
            _context.SaveChanges();
        }


        public void Update(Indicador indicador)
        {
            _context.Indicadores.Update(indicador);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var indicador = _context.Indicadores.Find(id);
            if (indicador != null)
            {
                _context.Indicadores.Remove(indicador);
                _context.SaveChanges();
            }
        }


        public Dictionary<string, int> GetTotalPorTipo()
        {
            return _context.Indicadores
                           .GroupBy(i => i.Tipo)
                           .ToDictionary(
                               g => g.Key,
                               g => g.Count()
                           );
        }

        public Dictionary<string, int> GetTotalPorCategoria()
        {
            return _context.Indicadores
                           .GroupBy(i => i.Categoria)
                           .ToDictionary(
                               g => g.Key,
                               g => g.Count()
                           );
        }

        public Dictionary<string, int> GetTotalPorAmbito()
        {
            return _context.Indicadores
                           .GroupBy(i => i.Ambito)
                           .ToDictionary(
                               g => g.Key,
                               g => g.Count()
                           );
        }
    }
}
