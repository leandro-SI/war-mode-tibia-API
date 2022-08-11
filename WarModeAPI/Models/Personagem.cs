using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarModeAPI.Models
{
    public class Personagem
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Vocation { get; set; }
        public int Level { get; set; }
        public string World { get; set; }
        public string Residence { get; set; }
        public DateTime Last_login { get; set; }
        public string Account_status { get; set; }
    }
}
