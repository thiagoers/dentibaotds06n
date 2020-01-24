using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrando_BD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnDentista_Click(object sender, EventArgs e)
        {
            FrmDentista f = new FrmDentista();
            f.Show();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            FrmPaciente f = new FrmPaciente();
            f.Show();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta f = new FrmConsulta();
            f.Show();
        }
    }
}
