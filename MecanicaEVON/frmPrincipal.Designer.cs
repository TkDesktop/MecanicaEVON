namespace MecanicaEVON
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServidor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBanco = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrTempo = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadveiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadPeca = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstoqueVeiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstoquePeca = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGerarPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultarPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDominios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCombustivel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTipoServico = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoModeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblServidor,
            this.lblBanco,
            this.lblTempo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1384, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(342, 17);
            this.lblUsuario.Spring = true;
            this.lblUsuario.Text = "Usuario: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblServidor
            // 
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(342, 17);
            this.lblServidor.Spring = true;
            this.lblServidor.Text = "Servidor: ";
            // 
            // lblBanco
            // 
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(342, 17);
            this.lblBanco.Spring = true;
            this.lblBanco.Text = "Banco: ";
            // 
            // lblTempo
            // 
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(342, 17);
            this.lblTempo.Spring = true;
            this.lblTempo.Text = "Tempo:  00:00:00";
            this.lblTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrTempo
            // 
            this.tmrTempo.Interval = 1000;
            this.tmrTempo.Tick += new System.EventHandler(this.tmrTempo_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastro,
            this.mnuEstoque,
            this.mnuPedidos,
            this.mnuDominios,
            this.mnuSobre,
            this.mnuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1384, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadveiculo,
            this.mnuCadPeca,
            this.mnuCadCliente,
            this.mnuCadFornecedor,
            this.mnuCadFuncionario});
            this.mnuCadastro.Image = global::MecanicaEVON.Properties.Resources.cadastro;
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(82, 20);
            this.mnuCadastro.Text = "&Cadastro";
            // 
            // mnuCadveiculo
            // 
            this.mnuCadveiculo.Image = global::MecanicaEVON.Properties.Resources.carro_de_brinquedo;
            this.mnuCadveiculo.Name = "mnuCadveiculo";
            this.mnuCadveiculo.Size = new System.Drawing.Size(142, 22);
            this.mnuCadveiculo.Text = "&Veiculo";
            this.mnuCadveiculo.Click += new System.EventHandler(this.mnuCadveiculo_Click);
            // 
            // mnuCadPeca
            // 
            this.mnuCadPeca.Image = global::MecanicaEVON.Properties.Resources.freio;
            this.mnuCadPeca.Name = "mnuCadPeca";
            this.mnuCadPeca.Size = new System.Drawing.Size(142, 22);
            this.mnuCadPeca.Text = "&Peça";
            // 
            // mnuCadCliente
            // 
            this.mnuCadCliente.Image = global::MecanicaEVON.Properties.Resources.atendimento_ao_cliente;
            this.mnuCadCliente.Name = "mnuCadCliente";
            this.mnuCadCliente.Size = new System.Drawing.Size(142, 22);
            this.mnuCadCliente.Text = "&Cliente";
            // 
            // mnuCadFornecedor
            // 
            this.mnuCadFornecedor.Image = global::MecanicaEVON.Properties.Resources.companhia;
            this.mnuCadFornecedor.Name = "mnuCadFornecedor";
            this.mnuCadFornecedor.Size = new System.Drawing.Size(142, 22);
            this.mnuCadFornecedor.Text = "&Fornecedor";
            // 
            // mnuCadFuncionario
            // 
            this.mnuCadFuncionario.Image = global::MecanicaEVON.Properties.Resources.carteira_de_identidade;
            this.mnuCadFuncionario.Name = "mnuCadFuncionario";
            this.mnuCadFuncionario.Size = new System.Drawing.Size(142, 22);
            this.mnuCadFuncionario.Text = "F&uncionarios";
            // 
            // mnuEstoque
            // 
            this.mnuEstoque.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEstoqueVeiculo,
            this.mnuEstoquePeca});
            this.mnuEstoque.Image = global::MecanicaEVON.Properties.Resources.estoque_pronto;
            this.mnuEstoque.Name = "mnuEstoque";
            this.mnuEstoque.Size = new System.Drawing.Size(77, 20);
            this.mnuEstoque.Text = "&Estoque";
            // 
            // mnuEstoqueVeiculo
            // 
            this.mnuEstoqueVeiculo.Image = global::MecanicaEVON.Properties.Resources.carro_de_brinquedo;
            this.mnuEstoqueVeiculo.Name = "mnuEstoqueVeiculo";
            this.mnuEstoqueVeiculo.Size = new System.Drawing.Size(117, 22);
            this.mnuEstoqueVeiculo.Text = "&Veiculos";
            // 
            // mnuEstoquePeca
            // 
            this.mnuEstoquePeca.Image = global::MecanicaEVON.Properties.Resources.freio;
            this.mnuEstoquePeca.Name = "mnuEstoquePeca";
            this.mnuEstoquePeca.Size = new System.Drawing.Size(117, 22);
            this.mnuEstoquePeca.Text = "&Peça";
            // 
            // mnuPedidos
            // 
            this.mnuPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGerarPedido,
            this.mnuConsultarPedido});
            this.mnuPedidos.Image = global::MecanicaEVON.Properties.Resources.pedido;
            this.mnuPedidos.Name = "mnuPedidos";
            this.mnuPedidos.Size = new System.Drawing.Size(72, 20);
            this.mnuPedidos.Text = "&Pedido";
            // 
            // mnuGerarPedido
            // 
            this.mnuGerarPedido.Image = global::MecanicaEVON.Properties.Resources.gerar_pedido;
            this.mnuGerarPedido.Name = "mnuGerarPedido";
            this.mnuGerarPedido.Size = new System.Drawing.Size(165, 22);
            this.mnuGerarPedido.Text = "&Gerar Pedido";
            // 
            // mnuConsultarPedido
            // 
            this.mnuConsultarPedido.Image = global::MecanicaEVON.Properties.Resources.consulta_pedido;
            this.mnuConsultarPedido.Name = "mnuConsultarPedido";
            this.mnuConsultarPedido.Size = new System.Drawing.Size(165, 22);
            this.mnuConsultarPedido.Text = "&Consultar Pedido";
            // 
            // mnuDominios
            // 
            this.mnuDominios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCombustivel,
            this.mnuCategoria,
            this.mnuCargo,
            this.mnuEspecialidade,
            this.mnuMarca,
            this.mnuStatus,
            this.mnuTipoServico,
            this.tipoModeloToolStripMenuItem,
            this.mnuModelo});
            this.mnuDominios.Image = global::MecanicaEVON.Properties.Resources.armazenamento_de_banco_de_dados;
            this.mnuDominios.Name = "mnuDominios";
            this.mnuDominios.Size = new System.Drawing.Size(86, 20);
            this.mnuDominios.Text = "&Dominios";
            // 
            // mnuCombustivel
            // 
            this.mnuCombustivel.Image = global::MecanicaEVON.Properties.Resources.gasolina;
            this.mnuCombustivel.Name = "mnuCombustivel";
            this.mnuCombustivel.Size = new System.Drawing.Size(180, 22);
            this.mnuCombustivel.Text = "&Combustivel";
            this.mnuCombustivel.Click += new System.EventHandler(this.mnuCombustivel_Click);
            // 
            // mnuCategoria
            // 
            this.mnuCategoria.Image = global::MecanicaEVON.Properties.Resources.lupa;
            this.mnuCategoria.Name = "mnuCategoria";
            this.mnuCategoria.Size = new System.Drawing.Size(180, 22);
            this.mnuCategoria.Text = "C&ategoria";
            this.mnuCategoria.Click += new System.EventHandler(this.mnuCategoria_Click);
            // 
            // mnuCargo
            // 
            this.mnuCargo.Image = global::MecanicaEVON.Properties.Resources.cargo;
            this.mnuCargo.Name = "mnuCargo";
            this.mnuCargo.Size = new System.Drawing.Size(180, 22);
            this.mnuCargo.Text = "Car&go";
            this.mnuCargo.Click += new System.EventHandler(this.mnuCargo_Click);
            // 
            // mnuEspecialidade
            // 
            this.mnuEspecialidade.Image = global::MecanicaEVON.Properties.Resources.especialidade;
            this.mnuEspecialidade.Name = "mnuEspecialidade";
            this.mnuEspecialidade.Size = new System.Drawing.Size(180, 22);
            this.mnuEspecialidade.Text = "&Especialidade";
            this.mnuEspecialidade.Click += new System.EventHandler(this.mnuEspecialidade_Click);
            // 
            // mnuMarca
            // 
            this.mnuMarca.Image = global::MecanicaEVON.Properties.Resources.brazao;
            this.mnuMarca.Name = "mnuMarca";
            this.mnuMarca.Size = new System.Drawing.Size(180, 22);
            this.mnuMarca.Text = "&Marca";
            this.mnuMarca.Click += new System.EventHandler(this.mnuMarca_Click);
            // 
            // mnuStatus
            // 
            this.mnuStatus.Image = global::MecanicaEVON.Properties.Resources.status;
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.Size = new System.Drawing.Size(180, 22);
            this.mnuStatus.Text = "&Status";
            this.mnuStatus.Click += new System.EventHandler(this.mnuStatus_Click);
            // 
            // mnuTipoServico
            // 
            this.mnuTipoServico.Image = global::MecanicaEVON.Properties.Resources.servico;
            this.mnuTipoServico.Name = "mnuTipoServico";
            this.mnuTipoServico.Size = new System.Drawing.Size(180, 22);
            this.mnuTipoServico.Text = "T&ipo Serviço";
            this.mnuTipoServico.Click += new System.EventHandler(this.mnuTipoServico_Click);
            // 
            // tipoModeloToolStripMenuItem
            // 
            this.tipoModeloToolStripMenuItem.Image = global::MecanicaEVON.Properties.Resources.ligar;
            this.tipoModeloToolStripMenuItem.Name = "tipoModeloToolStripMenuItem";
            this.tipoModeloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoModeloToolStripMenuItem.Text = "Tipo &Telefone";
            this.tipoModeloToolStripMenuItem.Click += new System.EventHandler(this.tipoModeloToolStripMenuItem_Click);
            // 
            // mnuModelo
            // 
            this.mnuModelo.Image = global::MecanicaEVON.Properties.Resources.carro_de_brinquedo;
            this.mnuModelo.Name = "mnuModelo";
            this.mnuModelo.Size = new System.Drawing.Size(180, 22);
            this.mnuModelo.Text = "M&odelo";
            this.mnuModelo.Click += new System.EventHandler(this.mnuModelo_Click);
            // 
            // mnuSobre
            // 
            this.mnuSobre.Image = global::MecanicaEVON.Properties.Resources.sobre;
            this.mnuSobre.Name = "mnuSobre";
            this.mnuSobre.Size = new System.Drawing.Size(65, 20);
            this.mnuSobre.Text = "&Sobre";
            this.mnuSobre.Click += new System.EventHandler(this.mnuSobre_Click);
            // 
            // mnuSair
            // 
            this.mnuSair.Image = global::MecanicaEVON.Properties.Resources.saida;
            this.mnuSair.Name = "mnuSair";
            this.mnuSair.Size = new System.Drawing.Size(54, 20);
            this.mnuSair.Text = "&Sai&r";
            this.mnuSair.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 661);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EVOM - Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblServidor;
        private System.Windows.Forms.ToolStripStatusLabel lblBanco;
        private System.Windows.Forms.ToolStripStatusLabel lblTempo;
        private System.Windows.Forms.Timer tmrTempo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnuCadveiculo;
        private System.Windows.Forms.ToolStripMenuItem mnuCadPeca;
        private System.Windows.Forms.ToolStripMenuItem mnuCadCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuCadFornecedor;
        private System.Windows.Forms.ToolStripMenuItem mnuCadFuncionario;
        private System.Windows.Forms.ToolStripMenuItem mnuEstoque;
        private System.Windows.Forms.ToolStripMenuItem mnuPedidos;
        private System.Windows.Forms.ToolStripMenuItem mnuDominios;
        private System.Windows.Forms.ToolStripMenuItem mnuSobre;
        private System.Windows.Forms.ToolStripMenuItem mnuEstoqueVeiculo;
        private System.Windows.Forms.ToolStripMenuItem mnuEstoquePeca;
        private System.Windows.Forms.ToolStripMenuItem mnuGerarPedido;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultarPedido;
        private System.Windows.Forms.ToolStripMenuItem mnuCombustivel;
        private System.Windows.Forms.ToolStripMenuItem mnuCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidade;
        private System.Windows.Forms.ToolStripMenuItem mnuCargo;
        private System.Windows.Forms.ToolStripMenuItem mnuSair;
        private System.Windows.Forms.ToolStripMenuItem mnuStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuTipoServico;
        private System.Windows.Forms.ToolStripMenuItem mnuMarca;
        private System.Windows.Forms.ToolStripMenuItem tipoModeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModelo;
    }
}