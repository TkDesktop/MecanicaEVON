using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MecanicaEVON
{
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }
        Marca marca;

        private void frmMarca_Load(object sender, EventArgs e)
        {
            marca = new Marca();
            PreencherGrid();
        }
        private void PreencherGrid()
        {
            grdDados.DataSource = marca.Consultar();
            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].HeaderText = "Marca";
            grdDados.Columns[1].Width = 318;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            marca = new Marca();
            marca.marca = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                marca = new Marca();
                marca.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                marca.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Marca",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherFormulario()
        {
            txtMarca.Text = marca.marca;
        }

        private void PreencherClasse()
        {
            marca.marca = txtMarca.Text;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtMarca.Text == string.Empty)
            {
                msgErro = "Preencha o campo Marca.\n";
            }
            return msgErro;
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtMarca.Clear();
            txtPesquisa.Focus();
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
                marca.Gravar();
                MessageBox.Show("Cargo gravado com sucesso!!!",
                    "Cadastro de Marca",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Marca",
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
    }
}
