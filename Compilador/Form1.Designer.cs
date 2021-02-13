namespace Compilador
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
			this.textBox2 = new System.Windows.Forms.RichTextBox();
			this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salvarcomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.novoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.salvarToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.83951F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.16049F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 486);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
			this.textBox1.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
			this.textBox1.AutoScrollMinSize = new System.Drawing.Size(31, 18);
			this.textBox1.BackBrush = null;
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
			this.textBox1.CharHeight = 18;
			this.textBox1.CharWidth = 10;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Courier New", 12F);
			this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
			this.textBox1.IsReplaceMode = false;
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Paddings = new System.Windows.Forms.Padding(0);
			this.textBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.textBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBox1.ServiceColors")));
			this.textBox1.Size = new System.Drawing.Size(1078, 348);
			this.textBox1.TabIndex = 0;
			this.textBox1.Zoom = 100;
			this.textBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.TextBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Font = new System.Drawing.Font("Courier New", 12F);
			this.textBox2.ForeColor = System.Drawing.SystemColors.Control;
			this.textBox2.Location = new System.Drawing.Point(3, 357);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(1078, 126);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// arquivoToolStripMenuItem
			// 
			this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.salvarcomoToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.arquivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
			this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.arquivoToolStripMenuItem.Text = "&Arquivo";
			// 
			// novoToolStripMenuItem
			// 
			this.novoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.novoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.novoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("novoToolStripMenuItem.Image")));
			this.novoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
			this.novoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.novoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.novoToolStripMenuItem.Text = "&Novo";
			// 
			// abrirToolStripMenuItem
			// 
			this.abrirToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.abrirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
			this.abrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
			this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.abrirToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.abrirToolStripMenuItem.Text = "&Abrir";
			this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
			// 
			// salvarToolStripMenuItem
			// 
			this.salvarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.salvarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.salvarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salvarToolStripMenuItem.Image")));
			this.salvarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
			this.salvarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.salvarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.salvarToolStripMenuItem.Text = "&Salvar";
			this.salvarToolStripMenuItem.Click += new System.EventHandler(this.SalvarToolStripMenuItem_Click);
			// 
			// salvarcomoToolStripMenuItem
			// 
			this.salvarcomoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.salvarcomoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.salvarcomoToolStripMenuItem.Name = "salvarcomoToolStripMenuItem";
			this.salvarcomoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.salvarcomoToolStripMenuItem.Text = "Salvar &como";
			this.salvarcomoToolStripMenuItem.Click += new System.EventHandler(this.SalvarcomoToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.sairToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.sairToolStripMenuItem.Text = "Sai&r";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.SairToolStripMenuItem_Click);
			// 
			// compilarToolStripMenuItem
			// 
			this.compilarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
			this.compilarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.compilarToolStripMenuItem.Text = "Compilar";
			this.compilarToolStripMenuItem.Click += new System.EventHandler(this.CompilarToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.compilarToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// novoToolStripButton
			// 
			this.novoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.novoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("novoToolStripButton.Image")));
			this.novoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.novoToolStripButton.Name = "novoToolStripButton";
			this.novoToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.novoToolStripButton.Text = "&Novo";
			this.novoToolStripButton.Click += new System.EventHandler(this.NovoToolStripButton_Click);
			// 
			// abrirToolStripButton
			// 
			this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
			this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.abrirToolStripButton.Name = "abrirToolStripButton";
			this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.abrirToolStripButton.Text = "&Abrir";
			this.abrirToolStripButton.Click += new System.EventHandler(this.AbrirToolStripButton_Click);
			// 
			// salvarToolStripButton
			// 
			this.salvarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.salvarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarToolStripButton.Image")));
			this.salvarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.salvarToolStripButton.Name = "salvarToolStripButton";
			this.salvarToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.salvarToolStripButton.Text = "&Salvar";
			this.salvarToolStripButton.Click += new System.EventHandler(this.SalvarToolStripButton_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripButton,
            this.abrirToolStripButton,
            this.salvarToolStripButton,
            this.toolStripSeparator6});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1084, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(1084, 541);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Máquina Virtual";
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salvarcomoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripButton novoToolStripButton;
		private System.Windows.Forms.ToolStripButton abrirToolStripButton;
		private System.Windows.Forms.ToolStripButton salvarToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStrip toolStrip1;
		//public System.Windows.Forms.RichTextBox textBox1;
		public System.Windows.Forms.RichTextBox textBox2;
		public FastColoredTextBoxNS.FastColoredTextBox textBox1;
	}
}

