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
    public partial class frmEstoqueVeiculo : Form
    {
        public frmEstoqueVeiculo()
        {
            InitializeComponent();
        }
        CadVeiculo veiculo;
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreeencherGrid()
        {
            veiculo = new CadVeiculo();

            grdDados.DataSource = veiculo.Consultar();

            grdDados.Columns[0].Visible = false;
            grdDados.Columns[1].Visible = false;
            grdDados.Columns[3].Visible = false;
            grdDados.Columns[9].Visible = false;
            grdDados.Columns[10].Visible = false;
            grdDados.Columns[8].Visible = false;
            grdDados.Columns[11].Visible = false;


            grdDados.Columns[7].HeaderText = "Nome Cliente";

            grdDados.Columns[4].Width = 150;
            grdDados.Columns[5].Width = 150;
            grdDados.Columns[6].Width = 150;
            grdDados.Columns[7].Width = 200;

        }

        private void frmEstoqueVeiculo_Load(object sender, EventArgs e)
        {
            PreeencherGrid();

        }
    }
}
