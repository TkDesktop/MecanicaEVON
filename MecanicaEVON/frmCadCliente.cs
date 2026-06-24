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
    public partial class frmCadCliente : Form
    {
        public frmCadCliente()
        {
            InitializeComponent();
        }
        Cliente cliente;
        Telefone telefone;
        TipoTelefone tipoTelefone;
        private void PreencherGrid()
        {
            try
            {
                cliente = new Cliente();

                grdDados.DataSource = cliente.Consultar();

                grdDados.Columns[0].Visible = false;

                grdDados.Columns[1].HeaderText = "Nome Completo";
                grdDados.Columns[2].HeaderText = "CPF";
                grdDados.Columns[3].HeaderText = "Data de Nascimento";
                grdDados.Columns[4].HeaderText = "E-mail";

                grdDados.Columns[1].Width = 150;
                grdDados.Columns[2].Width = 150;
                grdDados.Columns[3].Width = 130;
                grdDados.Columns[4].Width = 230;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void PreencherFormulario()
        {
            txtNome.Text = cliente.nomeCompleto;
            txtCpf.Text = cliente.cpf;
            txtEmail.Text = cliente.email;
            dtpCliente.Value = cliente.dataNascimento;
        }

        private void PreencherClasse()
        {
            cliente.nomeCompleto = txtNome.Text;
            cliente.cpf = txtCpf.Text;
            cliente.email = txtEmail.Text;
            cliente.dataNascimento = dtpCliente.Value;
  
        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {
            PreencherGrid();

            dtpCliente.Format = DateTimePickerFormat.Custom;
            dtpCliente.CustomFormat = "dd/MM/yyyy";
        }

        private void PesquisarCliente()
        {

            cliente = new Cliente();
            telefone = new Telefone();
            if (rdbCliente.Checked)
            {
                cliente.nomeCompleto = txtPesquisa.Text;
            }
            PreencherGrid();

            grdDados.DataSource = cliente.Consultar();

            if (cliente.id != 0)
            {
                PreencherFormulario();
            }
        }


        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            PesquisarCliente();
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente = new Cliente();
            cliente.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
            cliente.Consultar();



            PreencherFormulario();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            txtPesquisa.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();  

            txtPesquisa.Focus();
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;

            if (txtNome.Text == string.Empty)
            {
                msgErro += "Preencha o campo NOME. \n";
            }
            if (txtCpf.Text == string.Empty)
            {
                msgErro += "Preencha o campo DESCRIÇÃO. \n";
            }
            if (txtEmail.Text == string.Empty)
            {
                msgErro += "Preencha o campo PREÇO. \n";
            }
            if (dtpCliente.Text == string.Empty)
            {
                msgErro += "Preencha a DATA DE NASCIMENTO. \n";
            }
            return msgErro;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                }
                string mensagem = ValidarPreenchimento();
                if (mensagem != string.Empty)
                {
                    MessageBox.Show(mensagem, "Erro de Preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PreencherClasse();
                cliente.Gravar();
                

                MessageBox.Show("Cliente gravado com sucesso!!!",
                   "Cadastro de Cliente",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
                PreencherGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
