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
    public partial class frmEspecialidade : Form
    {
        public frmEspecialidade()
        {
            InitializeComponent();
        }
        Especialidade especialidade;

        private void frmEspecialidade_Load(object sender, EventArgs e)
        {
            especialidade = new Especialidade();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            grdDados.DataSource = especialidade.Consultar();
            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].HeaderText = "Especialidade";
            grdDados.Columns[1].Width = 318;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            especialidade = new Especialidade();
            especialidade.especialidade = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                especialidade = new Especialidade();
                especialidade.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                especialidade.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Especialidade",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtEspecialidade.Text = especialidade.especialidade;
        }
        private void PreencherClasse()
        {
            especialidade.especialidade = txtEspecialidade.Text;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtEspecialidade.Text == string.Empty)
            {
                msgErro = "Preencha o campo Especialidade.\n";
            }
            return msgErro;
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtEspecialidade.Clear();
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
                especialidade.Gravar();
                MessageBox.Show("Cargo gravado com sucesso!!!",
                    "Cadastro de Especialidade",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Especialidade",
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
