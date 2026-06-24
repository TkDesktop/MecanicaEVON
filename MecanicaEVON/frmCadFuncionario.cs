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
    public partial class frmCadFuncionario : Form
    {
        public frmCadFuncionario()
        {
            InitializeComponent();
        }
        Funcionario funcionario;
        CargoFuncao cargo;
        Especialidade especialidade;
        private void frmCadFuncionario_Load(object sender, EventArgs e)
        {
            Preenchergrid();
            CarregarCargo();
            CarregarEspecialidade();

            dtpFuncionario.Format = DateTimePickerFormat.Custom;
            dtpFuncionario.CustomFormat = "dd/MM/yyyy";
        }

        private void Preenchergrid()
        {
            funcionario = new Funcionario();

            grdDados.DataSource = funcionario.Consultar();

            grdDados.Columns[0].Visible = false;
            grdDados.Columns[4].Visible = false;
            grdDados.Columns[5].Visible = false;

            grdDados.Columns[1].HeaderText = "Funcionario";
            grdDados.Columns[3].HeaderText = "Data de Admissão";

            grdDados.Columns[1].Width = 200;
            grdDados.Columns[2].Width = 170;
            grdDados.Columns[3].Width = 200;
        }

        private void PreencherFormulario()
        {
            txtNome.Text = funcionario.nomeCompleto;
            txtCpf.Text = funcionario.cpf;
            dtpFuncionario.Value = funcionario.dataAdmissao;
            cboCargo.SelectedValue = funcionario.idCargo;
            cboEspecialidade.SelectedValue = funcionario.idEspecialidade;
        }

        private void PreencherClasse()
        {
            funcionario.nomeCompleto = txtNome.Text;
            funcionario.cpf = txtCpf.Text;
            funcionario.dataAdmissao = Convert.ToDateTime(dtpFuncionario.Value);
            funcionario.idCargo = Convert.ToInt32(cboCargo.SelectedValue);
            funcionario.idEspecialidade = Convert.ToInt32(cboEspecialidade.SelectedValue);
        }

        private void grdDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            funcionario = new Funcionario();

            funcionario.id = Convert.ToInt32(grdDados.SelectedRows[0].Cells[0].Value);
            funcionario.Consultar();

            PreencherFormulario();

        }

        private void CarregarCargo()
        {
            cboCargo.DataSource = (new CargoFuncao().Consultar());
            cboCargo.DisplayMember = "cargo";
            cboCargo.ValueMember = "id";
        }

        private void CarregarEspecialidade()
        {
            cboEspecialidade.DataSource = (new Especialidade().Consultar());
            cboEspecialidade.DisplayMember = "especialidade";
            cboEspecialidade    .ValueMember = "id";
        }

    }
}
