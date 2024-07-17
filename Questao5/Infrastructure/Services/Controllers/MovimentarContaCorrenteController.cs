using Microsoft.AspNetCore.Mvc;
using Questao5.Domain;
using Questao5.Domain.Models;
using Questao5.Shared.Validator;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentarContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public MovimentarContaCorrenteController
            (
                IContaCorrenteRepository contaCorrenteRepository
            )
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        [HttpPost]
        [Route("movimentar-conta")]
        public async Task MovimentarContaCorrenteAsync([FromBody] MovimentarContaRequest request)
        {
            var validator = new MovimentoContaValidator();
            validator.Validate(request);
            await _contaCorrenteRepository.MovimentarContaCorrenteAsync(request);
        }
    }
}
