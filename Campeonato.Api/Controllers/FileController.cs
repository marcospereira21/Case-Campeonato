using Campeonato.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Campeonato.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IJsonService _jsonService;
        private readonly ILogger _logger;
        public FileController(IJsonService jsonService, ILogger<FileController> logger)
        {
            _jsonService = jsonService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(JObject[] jsonString)
        {
            if (jsonString == null)
                return NotFound();

            _jsonService.ParseJson(jsonString);

            if (_jsonService._message.Tipo == Model.Enums.MensagemTipoEnum.Erro)
            {
                _logger.LogError(_jsonService._message.Mensagem);
                return BadRequest(_jsonService._message.Mensagem);
            }

            _logger.LogInformation(_jsonService._message.Mensagem);
            return Ok(_jsonService._message.Mensagem);
        }
    }
}