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
    public partial class frmCombustivel : Form
    {
        public frmCombustivel()
        {
            InitializeComponent();
        }
        Combustivel combustivel;

        private void frmCombustivel_Load(object sender, EventArgs e)
        {
            combustivel = new Combustivel();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            try
            {
                grdDados.DataSource = combustivel.Consultar();
                grdDados.Columns[0].Visible = false;
                grdDados.Columns[1].HeaderText = "Combustível";
                grdDados.Columns[1].Width = 318;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Combustível",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            combustivel = new Combustivel();
            combustivel.combustivel = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                combustivel = new Combustivel();
                combustivel.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                combustivel.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Combustível",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtCombustivel.Text = combustivel.combustivel;
        }
        private void PreencherClasse()
        {
            combustivel.combustivel = txtCombustivel.Text;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtCombustivel.Text == string.Empty)
            {
                msgErro = "Preencha o campo COMBUSTÍVEL.\n";
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
                combustivel.Gravar();
                MessageBox.Show("Combustível gravado com sucesso!!!",
                    "Cadastro de Combustível",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Combustível",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpar()
        {
            combustivel = new Combustivel();
            txtCombustivel.Clear();
            txtPesquisa.Clear();
            txtPesquisa.Focus();
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
