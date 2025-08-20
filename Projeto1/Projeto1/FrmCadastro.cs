using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class FrmCadastro : Form
    {
        //INSTANCIANDO A CONEXÃO

        Conexao con = new Conexao();
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("O Campo Nome não pode ficar vazio");
                txtNome.Focus();
            }
            else
            {
                try
                {
                    string sql = "insert into tbProduto(nome)values(@nome)";
                    MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtNome.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados Cadastrado com Sucesso");
                    con.DesConnectarBD();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }

            }
        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {

        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void dvgCadastro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregarDados();
        }

        //CRIANDO A FUNÇÃO CARREGAR DADOS

        public void carregarDados()
        {
            try
            {
                txtNome.Text = dvgCadastro.SelectedRows[0].Cells[0].Value.ToString();
            }

            catch(Exception erro)
            {
                MessageBox.Show("Erro ao clicar" + erro);
            }
        }
    }
}
