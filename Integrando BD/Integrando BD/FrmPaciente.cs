using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Integrando_BD
{
    public partial class FrmPaciente : Form, ICadForm
    {
        Paciente objPaciente;
        Conexao con;

        public FrmPaciente()
        {
            InitializeComponent();
            con = new Conexao();            
        }        

        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            atualizarGrid();
            gerenciarCampos(true);
        }

        public void atualizarGrid()
        {
            limpaDados();
            List<Paciente> listPaciente = new List<Paciente>();
            con.conectar();

            SqlDataReader reader;

            reader = con.exeConsulta("select * from tb_paciente");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.id = reader.GetInt32(0);
                    paciente.nome = reader.GetString(1);
                    paciente.cpf = reader.GetString(2);
                    paciente.endereco = reader.GetString(3);
                    paciente.telefone = reader.GetString(4);
                    paciente.dt_nasc = reader.GetDateTime(5);

                    listPaciente.Add(paciente);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados!");
            }
            dgvDados.DataSource = null;
            dgvDados.DataSource = listPaciente;
        }

        private void limpaDados()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtCPF.Clear();
        }

        public void lerDados()
        {
            objPaciente = new Paciente();

            objPaciente.id = int.Parse(txtId.Text.Trim());
            objPaciente.nome = txtNome.Text;
            objPaciente.cpf = txtCPF.Text;
            objPaciente.telefone = txtTelefone.Text;
            objPaciente.endereco = txtEndereco.Text;
            objPaciente.dt_nasc = dtpNasc.Value;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            con.conectar();
            limpaDados();
            gerenciarCampos(false);
        }

        public void gerenciarCampos(Boolean t)
        {            
            txtId.ReadOnly = t;
            txtNome.ReadOnly = t;
            txtCPF.ReadOnly = t;
            txtEndereco.ReadOnly = t;
            txtTelefone.ReadOnly = t;                       
        }

        public void limparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtCPF.Text = "";
            dtpNasc.Value = DateTime.Today;            
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvDados.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvDados.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = dgvDados.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = dgvDados.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = dgvDados.CurrentRow.Cells[4].Value.ToString();
            dtpNasc.Value = DateTime.Parse(dgvDados.CurrentRow.Cells[5].Value.ToString());
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult salvar = MessageBox.Show("Deseja realmente salvar os dados?","Alerta!",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(salvar == DialogResult.Yes)
            {
                lerDados();
                String sql = "insert into tb_paciente " + "values (" + objPaciente.id + ", '" +
                    objPaciente.nome + "', '" +
                    objPaciente.cpf + "', '" +
                    objPaciente.endereco + "', '" +
                    objPaciente.telefone + "', " + " convert(date, '" + objPaciente.dt_nasc.ToShortDateString() + "', 103))";                   

                if(con.executar(sql) == 1)
                {
                    MessageBox.Show("Dados salvos com sucesso!");
                }
                else
                {
                    MessageBox.Show("Dados não foram salvos.");
                }

                gerenciarCampos(true);
                atualizarGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult excluir = MessageBox.Show("Deseja realmente exluir estes dados?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (excluir == DialogResult.Yes)
            {
                String id = dgvDados.CurrentRow.Cells[0].Value.ToString();
                String sql = "delete from tb_paciente where id_paciente = " + id;

                con.executar(sql);
                atualizarGrid();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult cancel = MessageBox.Show("Cancelar operação?","Alerta!",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(cancel == DialogResult.Yes)
            {
                gerenciarCampos(true);
                atualizarGrid();
            }
        }
    }
}
