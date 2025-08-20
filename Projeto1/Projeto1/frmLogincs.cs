using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmLogincs : Form
    {
        //INSTANCIANDO A STRING DE CONEXÃO
        Conexao con = new Conexao();
        public frmLogincs()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="" && txtSenha.Text == "") //   SE O USUARIO E SENHA ESTIVEREM VAZIOS, RETORNE UMA MENSAGEM DE TEXTO INDICANDO QUE AMBOS ESTÃO INCORRETOS 
            {
                MessageBox.Show("Usuário e senha inválidos");
            }

                try
                {
                    string sql = "select * from tbLogin where usuario = @user and senha = @senha"; //CRIE UMA VARIAVEL STRING(sql), ONDE IRÁ GUARDAR TODOS OS DADOS DA TABELA NO MYSQL
                    MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());  //CRIANDO UMA INSTANCIA PARA MYSQL ONE IRA USAR OS DADOS DA TABELA ARMAZENADOS, ENTRAR NO SERVIDOR E INDENTIFICAR O BANCO ONDE TAIS INFORMAÇÕES ESTÃO
                    cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;
                    cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = txtSenha.Text;
                    MySqlDataReader dados;
                    dados = cmd.ExecuteReader();

                    if (dados.HasRows)
                    {
                        MessageBox.Show("Seja bem-vindo ao Sistema");
                        FrmMenu menu = new FrmMenu();
                        this.Hide();
                        menu.Show();
                    }

                    else
                    {
                        txtUsuario.Clear();
                        txtSenha.Clear();
                        txtUsuario.Focus();
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

                finally
                {
                    con.DesConnectarBD();
                }

        }

        private void lblSenha_Click(object sender, EventArgs e)
        {

        }

        private void frmLogincs_Load(object sender, EventArgs e)
        {

        }
    }
}
