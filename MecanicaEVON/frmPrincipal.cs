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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        DateTime dttLogin;
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Usuario: {Global.nome} ({Global.login})";
            lblServidor.Text = $"Servidor: {Global.servidor}";
            lblBanco.Text = $"Banco: {Global.banco}";
            dttLogin = DateTime.Now;
            tmrTempo.Enabled = true;

            
            if (Global.perfil != "administrador" && Global.perfil != "gerente")
            {
                mnuCadastro.Visible = false;
                mnuDominios.Visible = false;
            }
            if (Global.perfil != "administrador" && Global.perfil != "gerente" && Global.perfil != "estoquista")
            {
                mnuEstoque.Visible = false;
            }
            if (Global.perfil != "administrador" && Global.perfil != "gerente" && Global.perfil != "atendente")
            {
                mnuGerarPedido.Visible = false;
            }
            if (Global.perfil != "administrador" && Global.perfil != "gerente" && Global.perfil != "atendente" && Global.perfil != "mecanico")
            {
                mnuConsultarPedido.Visible = false;
            }
        }

        private void tmrTempo_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - dttLogin;
            lblTempo.Text = $"Tempo: {ts.Hours.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";
            Application.DoEvents();
        }

        private void AbrirForm(Form form)
        {
            foreach (Form filho in this.MdiChildren)
            {
                if (filho.Name == form.Name)
                {
                    filho.BringToFront();
                    return;
                }
            }
            form.MdiParent = this;
            form.Show();
        }

        private void mnuSobre_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmSobre());
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente encerrar a aplicação?",
              "Oficina - EVOM", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tipoModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmTipoTelefone());
        }

        private void mnuCategoria_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCategoria());
        }

        private void mnuCombustivel_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCombustivel());
        }

        private void mnuCargo_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCargo());
        }

        private void mnuEspecialidade_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmEspecialidade());
        }

        private void mnuMarca_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmMarca());
        }

        private void mnuStatus_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmStatus());
        }

        private void mnuTipoServico_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmTipoServico());
        }

        private void mnuCadveiculo_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCadVeiculo());
        }

        private void mnuModelo_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmModelo());
        }

        private void mnuCadPeca_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCadPeca());
        }

        private void mnuCadCliente_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCadCliente());
        }

        private void mnuEstoquePeca_Click(object sender, EventArgs e)
        {
            AbrirForm (new frmEstoquePeca());
        }

        private void mnuEstoqueVeiculo_Click(object sender, EventArgs e)
        {
            AbrirForm (new frmEstoqueVeiculo());
        }

        private void mnuCadFornecedor_Click(object sender, EventArgs e)
        {
            AbrirForm (new frmCadFornecedor());
        }

        private void mnuCadFuncionario_Click(object sender, EventArgs e)
        {
            AbrirForm (new frmCadFuncionario());
        }
    }
}
