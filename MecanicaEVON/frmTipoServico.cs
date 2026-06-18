using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MecanicaEVON
{
    public partial class frmTipoServico : Form
    {
        public frmTipoServico()
        {
            InitializeComponent();
        }
        TipoServico tipoServico;

        private void frmTipoServico_Load(object sender, EventArgs e)
        {
            tipoServico = new TipoServico();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            grdDados.DataSource = tipoServico.Consultar();
            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].HeaderText = "Tipo Servico";
            grdDados.Columns[1].Width = 318;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            tipoServico = new TipoServico();
            tipoServico.tipoServico = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tipoServico = new TipoServico();
                tipoServico.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                tipoServico.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Tipo Serviço",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtTipoServico.Text = tipoServico.tipoServico;
        }

        private void PreencherClasse()
        {
            tipoServico.tipoServico = txtTipoServico.Text;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtTipoServico.Text == string.Empty)
            {
                msgErro = "Preencha o campo TIPO SERVIÇO.\n";
            }
            return msgErro;
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtTipoServico.Clear();
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
                tipoServico.Gravar();
                MessageBox.Show("Cargo gravado com sucesso!!!",
                    "Cadastro de Serviço",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Serviço",
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
