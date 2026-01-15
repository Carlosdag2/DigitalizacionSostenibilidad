using DigitalizacionSostenibilidad.Models;
using DigitalizacionSostenibilidad.Repositories;


namespace DigitalizacionSostenibilidad.Services
{
    public class IndicadorService
    {
        private readonly IIndicadorRepository _indicadorRepository;


        public IndicadorService(IIndicadorRepository indicadorRepository)
        {
            _indicadorRepository = indicadorRepository;
        }


        // READ
        public IEnumerable<Indicador> GetAll()
        {
            return _indicadorRepository.GetAll();
        }


        public Indicador? GetById(int id)
        {
            return _indicadorRepository.GetById(id);
        }


        public IEnumerable<Indicador> GetByTipo(string tipo)
        {
            return _indicadorRepository.GetByTipo(tipo);
        }


        public IEnumerable<Indicador> GetByCategoria(string categoria)
        {
            return _indicadorRepository.GetByCategoria(categoria);
        }


        public IEnumerable<Indicador> GetByAmbito(string ambito)
        {
            return _indicadorRepository.GetByAmbito(ambito);
        }


        // CREATE
        public void Add(Indicador indicador)
        {
            _indicadorRepository.Add(indicador);
        }


        // UPDATE
        public void Update(Indicador indicador)
        {
            _indicadorRepository.Update(indicador);
        }


        // DELETE
        public void Delete(int id)
        {
            _indicadorRepository.Delete(id);
        }


        // CONSULTA AGREGADA
        public Dictionary<string, int> GetTotalPorTipo()
        {
            return _indicadorRepository.GetTotalPorTipo();
        }

        public Dictionary<string, int> GetTotalPorCategoria()
        {
            return _indicadorRepository.GetTotalPorCategoria();
        }

        public Dictionary<string, int> GetTotalPorAmbito()
        {
            return _indicadorRepository.GetTotalPorAmbito();
        }
    }
}
