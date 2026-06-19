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
    public partial class frmCadPeca : Form
    {
        public frmCadPeca()
        {
            InitializeComponent();
        }
        Produto produto;
        
        private void frmCadPeca_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            try
            {
                Produto produto = new Produto();

                grdDados.DataSource = produto.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[3].Visible = false;
                grdDados.Columns[5].Visible = false;
                grdDados.Columns[6].Visible = false;
                grdDados.Columns[7].Visible = false;

                grdDados.Columns[1].HeaderText = "Produto";
                grdDados.Columns[2].HeaderText = "Descrição";
                grdDados.Columns[4].HeaderText = "Preço de Custo";

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
            txtPreco.Text = produto.preco.ToString();
            txtPrecoCusto.Text = produto.precoCusto.ToString();
            cboFornecedor.SelectedValue = produto.idFornecedor;
            cboCategoria.SelectedValue = produto.idCategoria;
        }

        private void PreencherClasse()
        {
            produto.nome = txtNomeProduto.Text;
            produto.descricao = txtDescricao.Text;
            produto.preco = Convert.ToDecimal(txtPreco.Text);
            produto.precoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
            produto.idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
            produto.idFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
