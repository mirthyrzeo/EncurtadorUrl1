using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Encurtador.Infrastructure.Data;
using Encurtador.Models;
using Encurtador.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Encurtador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly IUrlService _urlService;

        public UrlController(ILogger<UrlController> logger, IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<ActionResult<UrlEncurtada>> EncurtarUrl(UrlParaEncurtar urlParaEncurtar)
        {
            try
            {
                var urlEncurtada = await _urlService.EncurtarUrl(urlParaEncurtar);
                return Ok(urlEncurtada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao encurtar URL");
                return BadRequest("Não foi possível encurtar a URL");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RedirecionarUrl(string id)
        {
            try
            {
                var urlOriginal = await _urlService.ObterUrlOriginal(id);

                if (urlOriginal != null)
                {
                    return Redirect(urlOriginal);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter URL original");
                return BadRequest("Não foi possível obter a URL original");
            }
        }
    }
}