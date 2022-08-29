using Microsoft.AspNetCore.Mvc;
using MovEstqZdzCodeAPI.Models.Dto;
using MovEstqZdzCodeAPI.Service;

namespace MovEstqZdzCodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovEstqController : ControllerBase
    {
        private readonly MovEstqService _movEstqService;

        public MovEstqController(MovEstqService movEstqService)
        {
            _movEstqService = movEstqService;
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] MovEstqDTO novaMovEstq)
        {
            _movEstqService.SalvarMovEstq(novaMovEstq);
            return Ok();
        }
    }
}
