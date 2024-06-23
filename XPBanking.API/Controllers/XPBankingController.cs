using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XPBanking.API.Services;
using XPBanking.API.Services.Dto;
using XPBanking.API.Services.Interface;

namespace XPBanking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XPBankingController : ControllerBase
    {
        private readonly IConsultInvestmentService _consultInvestmentService;

        public XPBankingController(IConsultInvestmentService consultInvestmentService)
        {
            _consultInvestmentService = consultInvestmentService;
        }

        [HttpPost]
        [Route("AssetBalance")]
        public async Task<IActionResult> AssetBalance(int id, int assetId, int value, int type)
        {
            var result = await _consultInvestmentService.AssetBalance(id, assetId, value, type);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetConsultInvestment")]
        public async Task<IActionResult> GetConsultInvestment(int id)
        {
            var result = await _consultInvestmentService.GetUserInvestment(id);

            return Ok(result); 

        }

        [HttpGet]
        [Route("UserStatement")]
        public async Task<IActionResult> GetUserStatement(int id)
        {
            var result = await _consultInvestmentService.GetStatement(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmail()
        {
             var usuarios = _consultInvestmentService.GetAssetsExpired();
            _consultInvestmentService.EnviarEmailsParaUsuarios(usuarios);

            return Ok();
        }
    }
}
