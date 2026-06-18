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
    public partial class frmModelo : Form
    {
        public frmModelo()
        {
            InitializeComponent();
        }
        Modelo modelo;
        Marca marca;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreencherGrid()
        {
            try
            {
                

                grdDados.DataSource = modelo.Consultar();
                grdDados.Columns[0].Visible = false;
                grdDados.Columns[1].HeaderText = "Modelo";
                grdDados.Columns[1].Width = 318;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Modelo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmModelo_Load(object sender, EventArgs e)
        {
            modelo = new Modelo();
            PreencherGrid();
            CarregarMarca();
        }

        private void CarregarMarca()
        {
            cboMarca.DataSource = (new Marca()).Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";
            cboMarca.SelectedIndex = -1;

        }


        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            modelo = new Modelo();
            modelo.modelo = txtPesquisa.Text;
            PreencherGrid();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                modelo = new Modelo();
                modelo.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
                modelo.Consultar();
                PreencherFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Modelo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFormulario()
        {
            txtModelo.Text = modelo.modelo;

            cboMarca.SelectedValue = modelo.idMarca;
        }

        private void PreencherClasse()
        {
            modelo.modelo = txtModelo.Text;

            modelo.idMarca = Convert.ToInt32(cboMarca.SelectedValue);
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtModelo.Text == string.Empty)
            {
                msgErro = "Preencha o campo MODELO.\n";
            }
            return msgErro;
        }

        private void Limpar()
        {
            modelo = new Modelo();
            txtModelo.Clear();
            txtPesquisa.Clear();
            txtPesquisa.Focus();

            modelo = new Modelo();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
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
                modelo.Gravar();
                MessageBox.Show("Modelo gravada com sucesso!!!",
                    "Cadastro de Modelo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro--> {ex.Message}",
                    "Cadastro de Modelo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
