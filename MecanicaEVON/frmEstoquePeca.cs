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
    public partial class frmEstoquePeca : Form
    {
        public frmEstoquePeca()
        {
            InitializeComponent();
        }
        Produto produto;

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreencherGrid()
        {
            try
            {
                produto = new Produto();

                grdDados.DataSource = produto.Consultar();

                grdDados.Columns[0].Visible = false;
                grdDados.Columns[2].Visible = false;
                grdDados.Columns[6].Visible = false;
                grdDados.Columns[7].Visible = false;

                grdDados.Columns[1].HeaderText = "Produto";
                grdDados.Columns[3].HeaderText = "Preço";
                grdDados.Columns[4].HeaderText = "Preço de Custo";

                grdDados.Columns[3].DefaultCellStyle.Format = "C";
                grdDados.Columns[4].DefaultCellStyle.Format = "C";

                grdDados.Columns[1].Width = 300;
                grdDados.Columns[3].Width = 170;
                grdDados.Columns[4].Width = 170;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmEstoquePeca_Load(object sender, EventArgs e)
        {
            PreencherGrid();
        }
    }
}
