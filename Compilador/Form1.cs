using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using FastColoredTextBoxNS;

namespace Compilador
{
	public partial class Form1 : Form
	{
		public string texto_aberto;
		Style newstyle = new TextStyle(Brushes.White, Brushes.Red, FontStyle.Bold);
		
		public Form1()
		{
			InitializeComponent();
		}

		private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				var FD = new System.Windows.Forms.OpenFileDialog();
				if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
					Program.diretorio = FD.FileName;
				}

				textBox1.Text = "";
				textBox1.Text = System.IO.File.ReadAllText(Program.diretorio);
				texto_aberto = textBox1.Text;
				textBox2.Text = "";
			}
			catch
			{
				Console.WriteLine("Erro ao ler arquivo");
			}
		}

		private void AbrirToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				var FD = new System.Windows.Forms.OpenFileDialog();
				if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
					Program.diretorio = FD.FileName;
				}

				textBox1.Text = "";
				textBox1.Text = System.IO.File.ReadAllText(Program.diretorio);
				texto_aberto = textBox1.Text;
				textBox2.Text = "";
			}
			catch
			{
				Console.WriteLine("Erro ao ler arquivo");
			}
		}

		private void NovoToolStripButton_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		private void CompilarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (texto_aberto != textBox1.Text)
			{
				string message = "Para compilar é necessário salvar o arquivo.";
				string title = "Compilar";
				DialogResult result = MessageBox.Show(message, title);
			}
			else
			{
				Program.LerArquivo();
				textBox2.Text = "";
				try
				{
					Program.sintatico.ExecutarSintatico();
					textBox2.Text = "Sucesso.";

				}
				catch (Erro ex)
				{
					textBox2.Text = ex.Mensagem + ex.Linha;

					//Alterando a cor da linha
					Range rng = new Range(textBox1, 0, ex.Linha, 0, ex.Linha-1);
					rng.SetStyle(newstyle);

				}

				Program.ResetaVariaveis();
				//textBox2.Text = "Arquivo não carregado.";
			}

		}


		private void SalvarToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				File.WriteAllText(Program.diretorio, textBox1.Text);
			}
			catch
			{
				SaveFileDialog savefile = new SaveFileDialog();
				savefile.Title = "Salvar como...";
				savefile.Filter = "Text Files .(txt)|*.txt";
				if (savefile.ShowDialog() == DialogResult.OK)
				{
					StreamWriter txtoutput = new StreamWriter(savefile.FileName);
					txtoutput.Write(textBox1.Text);
					txtoutput.Close();
					Program.diretorio = savefile.FileName;
				}
			}
			texto_aberto = textBox1.Text;
		}

		private void SalvarcomoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog savefile = new SaveFileDialog();
			savefile.Title = "Salvar como...";
			savefile.Filter = "Text Files .(txt)|*.txt";
			if (savefile.ShowDialog() == DialogResult.OK)
			{
				StreamWriter txtoutput = new StreamWriter(savefile.FileName);
				txtoutput.Write(textBox1.Text);
				txtoutput.Close();
			}
			texto_aberto = textBox1.Text;
		}

		private void SairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SalvarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			File.WriteAllText(Program.diretorio, textBox1.Text);
			texto_aberto = textBox1.Text;
		}

		private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			int n = 0;
			foreach (string i in textBox1.Lines)
			{
				n++;
			}
			Range rng = new Range(textBox1, 0, 0, 0, n);
			rng.ClearStyle(newstyle);
		}
	}
}
