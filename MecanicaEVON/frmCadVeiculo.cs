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
    public partial class frmCadVeiculo : Form
    {
        public frmCadVeiculo()
        {
            InitializeComponent();
        }
        Cliente cliente;
        Marca marca;
        Modelo modelo;
        CadVeiculo veiculo;
        Combustivel combustivel;
        bool load = false;

        private void frmCadVeiculo_Load(object sender, EventArgs e)
        {
            CarregarCombustivel();
            CarregarMarca();
            PreencherGrid();
            load = true;

        }

        private void PreencherGrid()
        {
            try
            {
                veiculo = new CadVeiculo();

                grdDados.DataSource = veiculo.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[3].Visible = false;
                grdDados.Columns[8].Visible = false;
                grdDados.Columns[9].Visible = false;
                grdDados.Columns[10].Visible = false;

                grdDados.Columns[6].HeaderText = "Combustível";
                grdDados.Columns[7].HeaderText = "Responsável";

                grdDados.Columns[2].Width = 55;
                grdDados.Columns[7].Width = 230;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void PreencherFormulario()
        {
            txtCpf.Text = cliente.cpf;
            txtNomeCliente.Text = cliente.nomeCompleto;
            cboMarca.SelectedValue = veiculo.idMarca;
            cboModelo.SelectedValue = veiculo.idModelo;
            txtAno.Text = veiculo.ano;
            txtPlaca.Text = veiculo.placa;
            cboCombustivel.SelectedValue = veiculo.idCombustivel;

        }

        private void PreencherClasse()
        {
            veiculo.placa = txtPlaca.Text;
            veiculo.ano = txtAno.Text;
            veiculo.idModelo = Convert.ToInt32(cboModelo.SelectedValue);
            veiculo.idCombustivel = Convert.ToInt32(cboCombustivel.SelectedValue);
            veiculo.idCliente = cliente.id;
           
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            if (txtCpf.Text != "")
            {
                cliente = new Cliente();
                cliente.cpf = txtCpf.Text;
                cliente.Consultar();

                txtNomeCliente.Text = cliente.nomeCompleto;
                
            }
        }

        private void CarregarMarca()
        {
            cboMarca.DataSource = (new Marca()).Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";
            cboMarca.SelectedIndex = -1;
        }

        private void CarregarModelo(int idMarca)
        {
            Modelo modelo = new Modelo();
            modelo.idMarca = idMarca;

            cboModelo.DataSource = modelo.Consultar();
            cboModelo.DisplayMember = "modelo";
            cboModelo.ValueMember = "id";
            cboModelo.SelectedIndex = -1;
        }

        private void CarregarCombustivel()
        {
            cboCombustivel.DataSource = (new Combustivel()).Consultar();
            cboCombustivel.DisplayMember = "combustivel";
            cboCombustivel.ValueMember = "id";
            cboCombustivel.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PesquisarCliente()
        {
            
            CadVeiculo veiculo = new CadVeiculo();
            if (rdbCliente.Checked)
            {
                veiculo.cpf = txtPesquisa.Text;
            }
            else if (rdbPlaca.Checked)
            {
                veiculo.placa = txtPesquisa.Text;
            }
            PreencherGrid();

            grdDados.DataSource = veiculo.Consultar();

            if (veiculo.id != 0)
            {
                PreencherFormulario();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void rdbPlaca_CheckedChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            veiculo = new CadVeiculo();
            veiculo.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
            veiculo.Consultar();

            cliente = new Cliente();
            cliente.id = veiculo.idCliente;
            cliente.Consultar();
            PreencherFormulario();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();

        }

        private void Limpar()
        {
            txtAno.Clear();
            txtCpf.Clear();
            txtNomeCliente.Clear();
            txtPesquisa.Clear();
            txtPlaca.Clear();
            cboCombustivel.SelectedValue = -1;
            cboMarca.SelectedValue = -1;
            cboModelo.SelectedValue = -1;

            txtPesquisa.Focus();
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
            {
                CarregarModelo(Convert.ToInt32(cboMarca.SelectedValue));

            }
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;

            if (txtPlaca.Text == string.Empty)
            {
                msgErro += "Preencha o campo PLACA.\n";
            }

            if (txtAno.Text == string.Empty)
            {
                msgErro += "Preencha o campo aANO. \n";
            }
            if (cboCombustivel.SelectedIndex == -1)
            {
                msgErro += "Preencha o campo COMBUSTIVEL. \n";
            }
            if (cboMarca.SelectedIndex == -1)
            {
                msgErro += "Preencha o campo MARCA. \n";
            }
            if (cboModelo.SelectedIndex == -1)
            {
                msgErro += "Preencha o campo MODELO. \n";
            }
            if (txtCpf.Text == string.Empty)
            {
                msgErro += "Preencha o campo CPF. \n";
            }
            if (txtNomeCliente.Text == string.Empty)
            {
                msgErro += "CPF Invalido. \n";
            }

            return msgErro;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (veiculo == null)
                {
                    veiculo = new CadVeiculo();
                }

                string mensagem = ValidarPreenchimento();
                if (mensagem !=  string.Empty)
                {
                    MessageBox.Show(mensagem,"Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();
                veiculo.Gravar();

                MessageBox.Show("Veiculo gravado com sucesso!!!",
                   "Cadastro de Veiculo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
