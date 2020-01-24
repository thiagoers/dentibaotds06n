using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrando_BD
{
    interface ICadForm
    {
        void gerenciarCampos(Boolean t);
        void atualizarGrid();
        void lerDados();
        void limparCampos();
    }
}
