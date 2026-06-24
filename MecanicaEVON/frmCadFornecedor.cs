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
    public partial class frmCadFornecedor : Form
    {
        public frmCadFornecedor()
        {
            InitializeComponent();
        }
        Fornecedor fornecedor;

        private void frmCadFornecedor_Load(object sender, EventArgs e)
        {
            PreencherGrid();
            
        }

        private void PreencherGrid()
        {
            fornecedor = new Fornecedor();

            grdDados.DataSource = fornecedor.Consultar();

            grdDados.Columns[0].Visible = false;
            grdDados.Columns[4].Visible = false;

            grdDados.Columns[1].Width = 250;
            grdDados.Columns[2].Width = 250;
            grdDados.Columns[3].Width = 250;
        }

        private void PreencherFormulario()
        {
            txtNome.Text = fornecedor.nome;
            txtCnpj.Text = fornecedor.cnpj;
            txtEmailFor.Text = fornecedor.email;
            
        }

        private void PreencherClasse()
        {
            fornecedor.nome = txtNome.Text;
            fornecedor.cnpj = txtCnpj.Text;
            fornecedor.email = txtEmailFor.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtCnpj.Clear();
            txtEmailFor.Clear();
            txtPesquisa.Clear();

            txtPesquisa.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fornecedor = new Fornecedor();

            fornecedor.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
            fornecedor.Consultar();

            PreencherFormulario();
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;

            if (txtNome.Text == string.Empty)
            {
                msgErro += "Preencha o campo EMPRESA. \n";
            }
            if (txtCnpj.Text == string.Empty)
            {
                msgErro += "Preencha o campo CNPJ. \n";
            }
            if (txtEmailFor.Text == string.Empty)
            {
                msgErro += "Preencha o campo EMAIL. \n";
            }

            return msgErro;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fornecedor == null)
                {
                    fornecedor= new Fornecedor();
                }
                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    MessageBox.Show(mensagem, "Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();
                fornecedor.Gravar();


                MessageBox.Show("Fornecedor gravado com sucesso!!!",
                   "Cadastro de Fornecedor",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
