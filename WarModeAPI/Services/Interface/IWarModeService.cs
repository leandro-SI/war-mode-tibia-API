using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarModeAPI.Models;

namespace WarModeAPI.Services.Interface
{
    public interface IWarModeService
    {
        Task<Personagem> GetPersonagem(string nome);
        Task<BossBoosted> GetBossBoosted();
        Task<CriaturaBoosted> GetCriaturaBoosted();
    }
}
