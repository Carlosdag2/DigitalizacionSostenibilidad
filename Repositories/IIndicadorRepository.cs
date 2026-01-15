using DigitalizacionSostenibilidad.Models;


namespace DigitalizacionSostenibilidad.Repositories
{
    public interface IIndicadorRepository
    {
        IEnumerable<Indicador> GetAll();
        Indicador? GetById(int id);
        IEnumerable<Indicador> GetByTipo(string tipo);
        IEnumerable<Indicador> GetByCategoria(string categoria);
        IEnumerable<Indicador> GetByAmbito(string ambito);


        void Add(Indicador indicador);


        void Update(Indicador indicador);


        void Delete(int id);


        Dictionary<string, int> GetTotalPorTipo();
        Dictionary<string, int> GetTotalPorCategoria();

        Dictionary<string, int> GetTotalPorAmbito();
    }
}
