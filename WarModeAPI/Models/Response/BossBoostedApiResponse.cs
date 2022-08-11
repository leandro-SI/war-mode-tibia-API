using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarModeAPI.Models.Response
{
    public class BossBoostedApiResponse
    {
        public BoostableBosses Boostable_bosses { get; set; }
    }

    public class BoostableBosses
    {
        public BossBoosted Boosted { get; set; }
    }
}
