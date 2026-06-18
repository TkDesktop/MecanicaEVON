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
    public partial class frmTipoTelefone : Form
    {
        public frmTipoTelefone()
        {
            InitializeComponent();
        }
        TipoTelefone tipoTelefone;
        private void frmTipoTelefone_Load(object sender, EventArgs e)
        {
            tipoTelefone = new TipoTelefone();
            PreencherGrid();
        }
        private void PreencherGrid()
        {
            try
            {
                grdDados.DataSource = tipoTelefone.Consultar();
                grdDados.Columns[0].Visible = false;
                grdDados.Columns[1].HeaderText = "Tipo Telefone";
                grdDados.Columns[1].Width = 318;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Tipos de Telefones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            tipoTelefone = new TipoTelefone();
            tipoTelefone.tipoTelefone = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tipoTelefone = new TipoTelefone();
                tipoTelefone.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                tipoTelefone.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Tipos de Telefones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherFormulario()
        {
            txtTipoTelefone.Text = tipoTelefone.tipoTelefone;
        }
        private void PreencherClasse()
        {
            tipoTelefone.tipoTelefone = txtTipoTelefone.Text;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtTipoTelefone.Text == string.Empty)
            {
                msgErro = "Preencha o campo TIPO TELEFONE.\n";
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
                tipoTelefone.Gravar();
                MessageBox.Show("Tipo Telefone gravado com sucesso!!!",
                    "Cadastro de Tipos de Telefones",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Tipos de Telefones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpar()
        {
            tipoTelefone = new TipoTelefone();
            txtTipoTelefone.Clear();
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
