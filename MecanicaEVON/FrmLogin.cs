using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MecanicaEVON
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_MouseEnter(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.Green;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.White;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.Red;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.White;
        }

        private void pctSenha_Click(object sender, EventArgs e)
        {
            bool opcao = txtSenha.UseSystemPasswordChar;
            if (opcao)
            {
                txtSenha.UseSystemPasswordChar = false;
                pctSenha.Image = Properties.Resources.ChatGPT_Image_1_de_jun__de_2026__21_36_03;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                pctSenha.Image = Properties.Resources.ChatGPT_Image_1_de_jun__de_2026__21_36_03;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnOk.MouseEnter += btnOk_MouseEnter;
            btnOk.MouseLeave += btnOk_MouseLeave;

            btnCancelar.MouseEnter += btnCancelar_MouseEnter;
            btnCancelar.MouseLeave += btnCancelar_MouseLeave;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtUsuario.Text == string.Empty)
            {
                msgErro += "Preencha o USUÁRIO.\n";
            }
            if (txtSenha.Text == string.Empty)
            {
                msgErro += "Preencha a SENHA.\n";
            }
            return msgErro;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    MessageBox.Show(mensagem, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Usuario usuario = new Usuario();
                usuario.login = txtUsuario.Text;
                usuario.Consultar();

                if (Global.EncriptPassword(txtSenha.Text) != usuario.senhaHash || !usuario.ativo)
                {
                    MessageBox.Show("Usuário e/ou senha inválidos!!!", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Bem vindo {usuario.nome}!!!", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Global.id = usuario.id;
                    Global.nome = usuario.nome;
                    Global.login = usuario.login;
                    Global.perfil = usuario.perfil;
                    DialogResult = DialogResult.OK;

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro --> {ex.Message}", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
