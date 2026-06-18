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
    public partial class frmCargo : Form
    {
        public frmCargo()
        {
            InitializeComponent();
        }
        CargoFuncao cargoFuncao;

        private void frmCargo_Load(object sender, EventArgs e)
        {
            cargoFuncao = new CargoFuncao();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            grdDados.DataSource = cargoFuncao.Consultar();
            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].HeaderText = "Especialidade";
            grdDados.Columns[1].Width = 318;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            cargoFuncao = new CargoFuncao();
            cargoFuncao.cargo = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cargoFuncao = new CargoFuncao();
                cargoFuncao.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                cargoFuncao.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Cargo / Função",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtCargoFuncao.Text = cargoFuncao.cargo;
        }
        private void PreencherClasse()
        {
            cargoFuncao.cargo = txtCargoFuncao.Text;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtCargoFuncao.Text == string.Empty)
            {
                msgErro = "Preencha o campo CARGO.\n";
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
                cargoFuncao.Gravar();
                MessageBox.Show("Cargo gravado com sucesso!!!",
                    "Cadastro de Cargo / Função",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Cargo / Função",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtCargoFuncao.Clear();
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
