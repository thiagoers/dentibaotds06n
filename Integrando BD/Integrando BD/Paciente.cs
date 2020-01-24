using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrando_BD
{
    class Paciente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public DateTime dt_nasc { get; set; }
    }
}
