using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarModeAPI.Models;
using WarModeAPI.Services.Interface;

namespace WarModeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly ILogger<PersonagemController> _logger;
        private readonly IWarModeService _warModeService;

        public PersonagemController(ILogger<PersonagemController> logger, IWarModeService warModeService)
        {
            _logger = logger;
            _warModeService = warModeService;
        }

        [HttpGet("GetPersonagem")]
        public async Task<ActionResult> GetPersonagem(string nome)
        {
            try
            {
                Personagem personagem = await _warModeService.GetPersonagem(nome);

                return Ok(personagem);
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        [HttpGet("GetBossBoosted")]
        public async Task<ActionResult> GetBossBoosted()
        {
            try
            {
                BossBoosted bossBoosted = await _warModeService.GetBossBoosted();

                return Ok(bossBoosted);
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }

        [HttpGet("GetCriaturaBoosted")]
        public async Task<ActionResult> GetCriaturaBoosted()
        {
            try
            {
                CriaturaBoosted criaturaBoosted = await _warModeService.GetCriaturaBoosted();

                return Ok(criaturaBoosted);
            }
            catch (Exception _error)
            {
                throw new Exception(_error.Message);
            }
        }


    }
}
