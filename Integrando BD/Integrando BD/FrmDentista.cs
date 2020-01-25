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
    public partial class FrmDentista : Form, ICadForm
    {
        Dentista objDentista;
        Conexao con;
        Boolean novo;

        public FrmDentista()
        {
            InitializeComponent();
            con = new Conexao();
        }        

        public void atualizarGrid()
        {
            limparDados();
            List<Dentista> listDentista = new List<Dentista>();
            con.conectar();

            SqlDataReader reader;

            reader = con.exeConsulta("select * from tb_dentista");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dentista dentista = new Dentista();
                    dentista.id = reader.GetInt32(0);
                    dentista.nome = reader.GetString(1);
                    dentista.Cro = reader.GetString(2);
                    dentista.Sexo = reader.GetString(3);
                    dentista.Instagram = reader.GetBoolean(4) ? 1 : 0;
                    dentista.Facebook = reader.GetBoolean(5) ? 1 : 0;
                    dentista.Twitter = reader.GetBoolean(6) ? 1 : 0;
                    dentista.LinkedIn = reader.GetBoolean(7) ? 1 : 0;

                    listDentista.Add(dentista);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Não retornou dados");
            }

            dgvDados.DataSource = null;
            dgvDados.DataSource = listDentista;
        }

        private void FrmDentista_Load(object sender, EventArgs e)
        {
            dgvDados.Enabled = false;            
            atualizarGrid();
            gerenciarCampos(true);            
        }
        
        public void limparDados()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCRO.Clear();
            chbInstagram.Checked = false;
            chbFacebook.Checked = false;
            chbTwitter.Checked = false;
            chbLinkedIn.Checked = false;
        }

        public void gerenciarCampos(Boolean t)
        {
            txtId.ReadOnly = t;
            txtCRO.ReadOnly = t;
            txtNome.ReadOnly = t;
        }
       
        public void lerDados()
        {
            objDentista = new Dentista();

            objDentista.id = int.Parse(txtId.Text.Trim());
            objDentista.nome = txtNome.Text;
            objDentista.Cro = txtCRO.Text;

            objDentista.Instagram = chbInstagram.Checked ? 1 : 0;
            objDentista.Facebook = chbFacebook.Checked ? 1 : 0;
            objDentista.Twitter = chbTwitter.Checked ? 1 : 0;
            objDentista.LinkedIn = chbLinkedIn.Checked ? 1 : 0;
                        
            objDentista.Sexo = rbFeminino.Checked ? "F" : "M";
        }

        public void limparCampos()
        {
            txtId.Text = "";
            txtCRO.Text = "";
            txtNome.Text = "";
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvDados.CurrentRow.Cells[0].Value.ToString();
            txtCRO.Text = dgvDados.CurrentRow.Cells[2].Value.ToString();
            txtNome.Text = dgvDados.CurrentRow.Cells[1].Value.ToString();

            chbInstagram.Checked = dgvDados.CurrentRow.Cells[4].Value.Equals(1);
            chbFacebook.Checked = dgvDados.CurrentRow.Cells[5].Value.Equals(1);
            chbTwitter.Checked = dgvDados.CurrentRow.Cells[6].Value.Equals(1);
            chbLinkedIn.Checked = dgvDados.CurrentRow.Cells[7].Value.Equals(1);

            rbFeminino.Checked = dgvDados.CurrentRow.Cells[3].Value.Equals("F");
            rbMasculino.Checked = dgvDados.CurrentRow.Cells[3].Value.Equals("M");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {            
            novo = true;
            limparCampos();
            gerenciarCampos(false);
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            DialogResult salvar = MessageBox.Show("Deseja realmente salvar os dados?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(salvar == DialogResult.Yes)
            {
                if (novo)
                {
                    lerDados();
                    String sql = "insert into tb_dentista " + "values (" + objDentista.id + ", '" +
                        objDentista.nome + "', '" +
                        objDentista.Cro + "', '" +
                        objDentista.Sexo + "', " +
                        objDentista.Instagram + ", " +
                        objDentista.Facebook + ", " +
                        objDentista.Twitter + ", " +
                        objDentista.LinkedIn + ") ";

                    if (con.executar(sql) == 1)
                    {
                        MessageBox.Show("Dados salvos com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Dados não foram salvos!");
                    }                    
                }
                else
                {
                    lerDados();
                    String sql = "update tb_dentista " + "set " +
                        "nome = '" +objDentista.nome + "', "+
                        "CRO = '" +objDentista.Cro + "', " +
                        "sexo = '" +objDentista.Sexo + "', " +
                        "instagram = " +objDentista.Instagram + ", " +
                        "facebook = " +objDentista.Facebook + ", " +
                        "twitter = " +objDentista.Twitter + ", " +
                        "linkedin = " +objDentista.LinkedIn + " where id_dentista = " + objDentista.id;

                    if (con.executar(sql) == 1)
                    {
                        MessageBox.Show("Dados salvos com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Dados não foram salvos!");
                    }
                }
                

                gerenciarCampos(true);
                atualizarGrid();
                dgvDados.Enabled = false;
            }            
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            DialogResult excluir = MessageBox.Show("Deseja realmente excluir este cadastro?","Alerta!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(excluir == DialogResult.Yes)
            {
                String id = dgvDados.CurrentRow.Cells[0].Value.ToString();
                String sql = "delete from tb_dentista where id_dentista = " + id;

                con.executar(sql);
                atualizarGrid();
            }           
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Deseja realmente cancelar o cadastro?","Alerta!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(msg == DialogResult.Yes)
            {
                gerenciarCampos(true);
                atualizarGrid();
            }           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            novo = false;
            gerenciarCampos(false);
            dgvDados.Visible = true;
            dgvDados.Enabled = true;            
        }
    }
}
