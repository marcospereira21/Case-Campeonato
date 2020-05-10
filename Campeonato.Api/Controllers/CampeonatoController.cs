using Campeonato.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Campeonato.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {

        private ICampeonatoService _service;
        private readonly ILogger _logger;
        public CampeonatoController(ICampeonatoService service, ILogger<CampeonatoController> logger)
        {
            _service = service;
            _logger = logger;
        }

              
        [HttpGet]
        [Route("PorTime")]
        public ActionResult GetPorTime( )
        {
            if (_service._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {
                _logger.LogError(_service._message.Mensagem);
                return BadRequest(_service._message.Mensagem);
            }

            _logger.LogInformation(_service._message.Mensagem);
            return Ok(_service.PorTime().ToList());
        }

        [HttpGet]
        [Route("PorEstado")]
        public ActionResult GetPorEstado()
        {
            if (_service._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {
                _logger.LogError(_service._message.Mensagem);
                return BadRequest(_service._message.Mensagem);
            }

            _logger.LogInformation(_service._message.Mensagem);
            return Ok(_service.PorEstado().ToList());
        }

        [HttpGet]
        [Route("Info")]
        public ActionResult GetInfo()
        {
            if (_service._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {
                _logger.LogError(_service._message.Mensagem);
                return BadRequest(_service._message.Mensagem);
            }

            _logger.LogInformation(_service._message.Mensagem);
            return Ok(_service.InfoComplementar());
           
        }
    }
}