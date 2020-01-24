using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrando_BD
{
    class Consulta
    {
        public int id { get; set; }
        public DateTime dtConsulta { get; set; }
        public DateTime dtRetorno { get; set; }
        public string motivo { get; set; }
        public string diagnostico { get; set; }
        public string receita { get; set; }
        public string motRetorno { get; set; }
        public int idPaciente { get; set; }
        public int idDentista { get; set; }
    }
}
