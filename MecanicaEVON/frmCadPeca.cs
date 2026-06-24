using System;
using System.Windows.Forms;

namespace MecanicaEVON
{
    public partial class frmCadPeca : Form
    {
        public frmCadPeca()
        {
            InitializeComponent();
        }
        Produto produto;
        Fornecedor fornecedor;
        bool load = false;

        private void frmCadPeca_Load(object sender, EventArgs e)
        {
            PreencherGrid();
            CarregarCategoria();
            CarregarFornecedor();
        }

        private void PreencherGrid()
        {
            try
            {
                produto = new Produto();

                grdDados.DataSource = produto.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[3].Visible = false;
                grdDados.Columns[5].Visible = false;
                grdDados.Columns[6].Visible = false;
                grdDados.Columns[7].Visible = false;

                grdDados.Columns[1].HeaderText = "Produto";
                grdDados.Columns[2].HeaderText = "Descrição";
                grdDados.Columns[4].HeaderText = "Preço de Custo";
                grdDados.Columns[4].DefaultCellStyle.Format = "C";

                grdDados.Columns[1].Width = 245;
                grdDados.Columns[2].Width = 265;
                grdDados.Columns[4].Width = 160;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void PreencherFormulario()
        {
            txtNomeProduto.Text = produto.nome;
            txtDescricao.Text = produto.descricao;
            txtPreco.Text = produto.preco.ToString("F2");
            txtPrecoCusto.Text = produto.precoCusto.ToString("F2");
            cboFornecedor.SelectedValue = produto.idFornecedor;
            cboCategoria.SelectedValue = produto.idCategoria;
            txtQuantidade.Text = produto.quantidade.ToString();
        }

        private void PreencherClasse()
        {
            produto.nome = txtNomeProduto.Text;
            produto.descricao = txtDescricao.Text;
            produto.preco = Convert.ToDecimal(txtPreco.Text);
            produto.precoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
            produto.idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            produto.idFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
            produto.quantidade = Convert.ToInt32(txtQuantidade.Text);
        }

        private void CarregarFornecedor()
        {
            cboFornecedor.DataSource = (new Fornecedor()).Consultar();
            cboFornecedor.DisplayMember = "nome";
            cboFornecedor.ValueMember = "id";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregarCategoria()
        {
            cboCategoria.DataSource = (new  Categoria()).Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";
            cboCategoria.SelectedIndex = -1;
        }

        private void PesquisarCliente()
        {

            produto = new Produto();
            fornecedor = new Fornecedor();
            if (rdbProduto.Checked)
            {
               produto.nome  = txtPesquisa.Text;
            }
            else if (rdbFornecedor.Checked)
            {
               fornecedor.nome = txtPesquisa.Text;
            }
            PreencherGrid();

            grdDados.DataSource = produto.Consultar();

            if (produto.id != 0)
            {
                PreencherFormulario();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void rdbFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void Limpar()
        {
            txtNomeProduto.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtPrecoCusto.Clear();
            txtQuantidade.Clear();
            cboCategoria.SelectedValue = -1;
            cboFornecedor.SelectedValue = -1;

            txtPesquisa.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            produto = new Produto(); 
            produto.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
            produto.Consultar();

            fornecedor = new Fornecedor();
            fornecedor.id = produto.idFornecedor;
            PreencherFormulario();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (produto == null)
                {
                    produto = new Produto();
                }

                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    MessageBox.Show(mensagem, "Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();
                produto.Gravar();

                MessageBox.Show("Produto gravado com sucesso!!!",
                   "Cadastro de Produto",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;

            if (txtNomeProduto.Text == string.Empty)
            {
                msgErro += "Preencha o campo NOME. \n";
            }
            if (txtDescricao.Text == string.Empty)
            {
                msgErro += "Preencha o campo DESCRIÇÃO. \n";
            }
            if (txtPreco.Text == string.Empty)
            {
                msgErro += "Preencha o campo PREÇO. \n";
            }
            if (txtPrecoCusto.Text == string.Empty)
            {
                msgErro += "Preencha o campo PREÇO CSUTO. \n";
            }
            if (cboFornecedor.SelectedIndex == -1)
            {
                msgErro += "Preencha o campo FORNECEDOR. \n";
            }
            if (cboCategoria.SelectedIndex == -1)
            {
                msgErro += "Preencha o campo CATEGORIA. \n";
            }
            return msgErro;
        }

    }
}
