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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        Categoria categoria;

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            categoria = new Categoria();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            try
            {
                grdDados.DataSource = categoria.Consultar();
                grdDados.Columns[0].Visible = false;
                grdDados.Columns[1].HeaderText = "Categoria";
                grdDados.Columns[1].Width = 318;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            categoria = new Categoria();
            categoria.categoria = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                categoria = new Categoria();
                categoria.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                categoria.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtCategoria.Text = categoria.categoria;
        }
        private void PreencherClasse()
        {
            categoria.categoria = txtCategoria.Text;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtCategoria.Text == string.Empty)
            {
                msgErro = "Preencha o campo CATEGORIA.\n";
            }
            return msgErro;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    MessageBox.Show(mensagem, "Erro de Preenchimento",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();
                categoria.Gravar();
                MessageBox.Show("Categoria gravada com sucesso!!!",
                    "Cadastro de Categoria",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Limpar()
        {
            categoria = new Categoria();
            txtCategoria.Clear();
            txtPesquisa.Clear();
            txtPesquisa.Focus();
        }
    }
}
