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
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }
        Status status;

        private void frmStatus_Load(object sender, EventArgs e)
        {
            status = new Status();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            grdDados.DataSource = status.Consultar();
            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].HeaderText = "Status";
            grdDados.Columns[1].Width = 318;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            status = new Status();
            status.status = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                status = new Status();
                status.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                status.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtStatus.Text = status.status;
        }

        private void PreencherClasse()
        {
            status.status = txtStatus.Text;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtStatus.Text == string.Empty)
            {
                msgErro = "Preencha o campo STATUS.\n";
            }
            return msgErro;
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtStatus.Clear();
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
                status.Gravar();
                MessageBox.Show("Cargo gravado com sucesso!!!",
                    "Cadastro de Status",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Status",
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
