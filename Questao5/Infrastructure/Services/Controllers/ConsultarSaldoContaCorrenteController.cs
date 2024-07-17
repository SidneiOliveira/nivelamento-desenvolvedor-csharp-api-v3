using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Models;
using Questao5.Shared.Validator;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultarSaldoContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteProvider _contaCorrenteProvider;

        public ConsultarSaldoContaCorrenteController
            (
                IContaCorrenteProvider contaCorrenteProvider
            )
        {
            _contaCorrenteProvider = contaCorrenteProvider;
        }

        [HttpGet]
        [Route("consultar-saldo-conta")]
        public ConsultarSaldoResponse GetSaldoAsync([FromQuery] string contaIdentity)
        {
            var conta = _contaCorrenteProvider.GetAccountInfoAsync(contaIdentity);
            var validator = new ContaCorrenteValidator();
            validator.Validate(conta.Result);
            return _contaCorrenteProvider.GetSaldoAsync(conta.Result);
        }
    }
}
