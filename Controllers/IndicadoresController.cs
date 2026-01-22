using DigitalizacionSostenibilidad.DTOs;
using DigitalizacionSostenibilidad.Models;
using DigitalizacionSostenibilidad.Services;
using Microsoft.AspNetCore.Mvc;


namespace DigitalizacionSostenibilidad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndicadoresController : ControllerBase
    {
        private readonly IndicadorService _indicadorService;
        private readonly ILogger<IndicadoresController> _logger;


        public IndicadoresController(
            IndicadorService indicadorService,
            ILogger<IndicadoresController> logger)
        {
            _indicadorService = indicadorService;
            _logger = logger;
        }


        // GET: api/indicadores
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Obteniendo todos los indicadores");


            var indicadores = _indicadorService.GetAll();
            return Ok(indicadores);
        }

        // GET: api/indicadores/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Obteniendo indicador con id {Id}", id);


            var indicador = _indicadorService.GetById(id);


            if (indicador == null)
            {
                return NotFound($"No existe ningún indicador con id {id}");
            }


            return Ok(indicador);
        }


        // GET: api/indicadores/tipo/{tipo}
        [HttpGet("tipo/{tipo}")]
        public IActionResult GetByTipo(string tipo)
        {
            _logger.LogInformation("Obteniendo indicadores de tipo {Tipo}", tipo);


            var indicadores = _indicadorService.GetByTipo(tipo);
            return Ok(indicadores);
        }


        // GET: api/indicadores/categoria/{categoria}
        [HttpGet("categoria/{categoria}")]
        public IActionResult GetByCategoria(string categoria)
        {
            _logger.LogInformation("Obteniendo indicadores de categoría {Categoria}", categoria);


            var indicadores = _indicadorService.GetByCategoria(categoria);
            return Ok(indicadores);
        }


        // GET: api/indicadores/ambito/{ambito}
        [HttpGet("ambito/{ambito}")]
        public IActionResult GetByAmbito(string ambito)
        {
            _logger.LogInformation("Obteniendo indicadores de ámbito {Ambito}", ambito);


            var indicadores = _indicadorService.GetByAmbito(ambito);
            return Ok(indicadores);
        }


        // GET: api/indicadores/total-por-tipo
        [HttpGet("total-por-tipo")]
        public IActionResult GetTotalPorTipo()
        {
            _logger.LogInformation("Obteniendo total de indicadores por tipo");


            var resultado = _indicadorService.GetTotalPorTipo();
            return Ok(resultado);
        }

        // GET: api/indicadores/total-por-categoria
        [HttpGet("total-por-categoria")]
        public IActionResult GetTotalPorCategoria()
        {
            _logger.LogInformation("Obteniendo total de indicadores por categoría");

            var resultado = _indicadorService.GetTotalPorCategoria();
            return Ok(resultado);
        }

        // GET: api/indicadores/total-por-ambito
        [HttpGet("total-por-ambito")]
        public IActionResult GetTotalPorAmbito() {
            _logger.LogInformation("Obteniendo total de indicadores por ámbito");
            var resultado = _indicadorService.GetTotalPorAmbito();
            return Ok(resultado);
        }

        // POST: api/indicadores
        [HttpPost]
        public IActionResult Create([FromBody] IndicadorDto indicadorDto)
        {
            _logger.LogInformation("Creando un nuevo indicador");
            var indicador = new Indicador
            {
                Tipo = indicadorDto.Tipo,
                Categoria = indicadorDto.Categoria,
                Nombre = indicadorDto.Nombre,
                Descripcion = indicadorDto.Descripcion,
                Valor = indicadorDto.Valor,
                Unidad = indicadorDto.Unidad,
                Fecha = indicadorDto.Fecha,
                Ambito = indicadorDto.Ambito
            };
            _indicadorService.Add(indicador);
            return Ok("Indicador creado correctamente");
        }

        // PUT: api/indicadores/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] IndicadorDto indicadorDto)
        {
            _logger.LogInformation("Actualizando el indicador con id {Id}", id);


            var indicador = new Indicador
            {
                Id = id,
                Tipo = indicadorDto.Tipo,
                Categoria = indicadorDto.Categoria,
                Nombre = indicadorDto.Nombre,
                Descripcion = indicadorDto.Descripcion,
                Valor = indicadorDto.Valor,
                Unidad = indicadorDto.Unidad,
                Fecha = indicadorDto.Fecha,
                Ambito = indicadorDto.Ambito
            };


            _indicadorService.Update(indicador);


            return Ok("Indicador editado correctamente");
        }

        // DELETE: api/indicadores/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Eliminando el indicador con id {Id}", id);


            _indicadorService.Delete(id);
            return Ok("Indicador eliminado correctamente");
        }


    }
}
