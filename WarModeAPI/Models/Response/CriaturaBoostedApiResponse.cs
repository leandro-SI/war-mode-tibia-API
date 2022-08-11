using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarModeAPI.Models.Response
{
    public class CriaturaBoostedApiResponse
    {
        public BoostableCriaturas Creatures { get; set; }
    }

    public class BoostableCriaturas
    {
        public CriaturaBoosted Boosted { get; set; }
    }

}
