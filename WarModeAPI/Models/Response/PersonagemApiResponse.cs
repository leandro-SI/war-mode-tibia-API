using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarModeAPI.Models.Response
{
    public class PersonagemApiResponse
    {
        public Personagens Characters { get; set; }
    }

    public class Personagens
    {
        public PersonagemResponse character { get; set; }
    }

    public class PersonagemResponse
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Vocation { get; set; }
        public int Level { get; set; }
        public string World { get; set; }
        public string Residence { get; set; }
        public string Last_login { get; set; }
        public string Account_status { get; set; }
    }
}
