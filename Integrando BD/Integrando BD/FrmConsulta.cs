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
    public partial class FrmConsulta : Form, ICadForm
    {
        Consulta cst;
        Conexao con;

        public FrmConsulta()
        {
            InitializeComponent();
            con = new Conexao();
        }        

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            atualizarGrid();
            LoadCbPac();
            LoadCbDent();
            gerenciarCampos(true);
        }

        private void LoadCbPac()
        {
            List<Paciente> listPaciente = new List<Paciente>();            
            con.conectar();

            SqlDataReader reader;

            reader = con.exeConsulta("select * from tb_paciente");            

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Paciente p = new Paciente();                                        
                    p.id = reader.GetInt32(0);
                    p.nome = reader.GetString(1);

                    listPaciente.Add(p);                    
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados");
            }            
            cbPaciente.DataSource = null;            
            cbPaciente.DataSource = listPaciente;
            cbPaciente.DisplayMember = "nome";
            cbPaciente.ValueMember = "id";            
        }

        private void LoadCbDent()
        {
            List<Dentista> listDentista = new List<Dentista>();
            con.conectar();

            SqlDataReader reader;

            reader = con.exeConsulta("select * from tb_dentista");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dentista d = new Dentista();
                    d.id = reader.GetInt32(0);
                    d.nome = reader.GetString(1);

                    listDentista.Add(d);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados");
            }
            cbDentista.DataSource = null;
            cbDentista.DataSource = listDentista;
            cbDentista.DisplayMember = "nome";
            cbDentista.ValueMember = "id";
        }

        public void atualizarGrid()
        {
            limparCampos();
            List<Consulta> listConsulta = new List<Consulta>();
            con.conectar();

            SqlDataReader reader;

            reader = con.exeConsulta("select * from tb_consulta2");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Consulta cst = new Consulta();
                    cst.id = reader.GetInt32(0);
                    cst.motivo = reader.GetString(1);
                    cst.dtConsulta = reader.GetDateTime(2);
                    cst.diagnostico = reader.GetString(3);
                    cst.receita = reader.GetString(4);
                    cst.dtRetorno = reader.GetDateTime(5);
                    cst.motRetorno = reader.GetString(6);
                    cst.idPaciente = reader.GetInt32(7);
                    cst.idDentista = reader.GetInt32(8);

                    listConsulta.Add(cst);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados");
            }

            dgvDados.DataSource = null;
            dgvDados.DataSource = listConsulta;
        }

        public void gerenciarCampos(Boolean t)
        {
            txtId.ReadOnly = t;
            txtMotivo.ReadOnly = t;
            txtMotRetorno.ReadOnly = t;
            txtReceita.ReadOnly = t;
            txtDiagnostico.ReadOnly = t;
        }

        public void lerDados()
        {
            cst = new Consulta();
            cst.id = int.Parse(txtId.Text.Trim());
            cst.motivo = txtMotivo.Text;
            cst.motRetorno = txtMotRetorno.Text;
            cst.dtConsulta = dtpConsulta.Value;
            cst.dtRetorno = dtpRetorno.Value;
            cst.diagnostico = txtDiagnostico.Text;
            cst.receita = txtReceita.Text;
            cst.idPaciente = int.Parse(cbPaciente.SelectedValue.ToString());
            cst.idDentista = int.Parse(cbDentista.SelectedValue.ToString());
        }

        public void limparCampos()
        {
            txtId.Clear();
            txtMotRetorno.Clear();
            txtMotivo.Clear();
            txtDiagnostico.Clear();
            txtReceita.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            gerenciarCampos(false);            
        }
    }
}
