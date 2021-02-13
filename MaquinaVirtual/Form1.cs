using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MaquinaVirtual
{
	public partial class Form1 : Form
	{
		public string enderecoArquivo = "";
		public List<Linha> linhas = new List<Linha>();
		public List<int> breakpoints = new List<int>();

		//Memoria
		public int[] memoria = new int[30000];
		public int s = 1;
		public int sMax = -1;
		public int i = 0;

		public Form1()
		{
			InitializeComponent();

			//Criando tabela da Pilha
			//Sendo vetor, as colunas devem ser criadas manualmente
			guna2DataGridView2.Columns.Add("Endereço", "Endereço");
			guna2DataGridView2.Columns.Add("Valor", "Valor");
		}

		private void Button_Carregar_Arquivo(object sender, EventArgs e)
		{
			//Resetando numero de linhas
			Linha.count = 0;

			//Recebendo o arquivo que sera executado
			RecebendoArquivo();

			linhas.Clear();
			breakpoints.Clear();
			//Separando atributos de cada linha do arquivo em objetos Linha
			CriandoLinhas();

			//Carregando as linhas na tabela
			guna2DataGridView1.DataSource = "";
			Console.WriteLine("Linhas" + linhas);
			guna2DataGridView1.DataSource = linhas;
		}

		//Botão para Executar
		private void Button_Executar(object sender, EventArgs e)
		{
			while (i < Linha.TotalLinhas())
			{
				AlterandoCorExecucao(i);
				ExecutarIntrucoes();
				AtualizarPilha();
				for (int j = 0; j < breakpoints.Count; j++)
				{
					if (breakpoints[j] == i+1)
					{
						i++;
						return;
					}
				}
				i++;
			}

			//Desabilitando botoes
			guna2Button2.Enabled = false;
			guna2Button3.Enabled = false;
		}

		public void AlterandoCorExecucao(int i)
		{
			int aux = 0;
			foreach (DataGridViewRow linha in guna2DataGridView1.Rows)
			{
				if (aux == i)
				{
					if (linha.Cells[0].Style.BackColor == Color.Khaki)
					{
						for (int j = 1; j <= 4; j++)
							linha.Cells[j].Style.BackColor = Color.LimeGreen;
					}
					else
					{
						for (int j = 0; j <= 4; j++)
							linha.Cells[j].Style.BackColor = Color.LimeGreen;
					}

				}
				else
				{
					if (linha.Cells[0].Style.BackColor == Color.Khaki)
					{
						for (int j = 1; j <= 4; j++)
							linha.Cells[j].Style.BackColor = Color.White;
					}
					else
					{
						for (int j = 0; j <= 4; j++)
							linha.Cells[j].Style.BackColor = Color.White;
					}
				}
				aux++;
			}
		}

		//Botao para Debbug
		private void Button_Debbug(object sender, EventArgs e)
		{
			if (i < Linha.TotalLinhas())
			{
				ExecutarIntrucoes();
				AtualizarPilha();
				AlterandoCorExecucao(i);
				i++;
			}
			else
			{
				guna2Button2.Enabled = false;
				guna2Button3.Enabled = false;
			}

		}

		//Botao para Ajuda
		private void Button_Help(object sender, EventArgs e)
		{
			Ajuda openForm = new Ajuda();
			openForm.Show();
		}

		//Botao reset
		private void Guna2Button1_Click_1(object sender, EventArgs e)
		{
			guna2Button2.Enabled = true;
			guna2Button3.Enabled = true;
			guna2DataGridView2.Rows.Clear();
			ResetVariaveis();

			foreach (DataGridViewRow linha in guna2DataGridView1.Rows)
			{
				if (linha.Cells[0].Style.BackColor == Color.Khaki)
				{
					for (int j = 1; j <= 4; j++)
						linha.Cells[j].Style.BackColor = Color.White;
				}
				else
				{
					for (int j = 0; j <= 4; j++)
						linha.Cells[j].Style.BackColor = Color.White;
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		//Atualiza a tabela da pilha
		private void AtualizarPilha()
		{
			if (s > sMax)
			{
				sMax = s;
			}

			guna2DataGridView2.Rows.Clear();

			for (int j = 0; j < sMax; j++)
			{
				guna2DataGridView2.Rows.Add(new object[] { j, memoria[j] });
			}
		}

		//Reseta variaveis
		private void ResetVariaveis()
		{
			for (int j = 0; j < memoria.Length; j++)
			{
				memoria[j] = 0;
			}
			sMax = -1;
			i = 0;
			textBox1.Text = "";
			textBox2.Text = "";
		}

		public void CriandoLinhas()
		{
			string[] linha;
			string[] linhaEspacada;
			string[] atributos;
			string[] instrucoes = { "LDC", "LDV", "ADD", "SUB", "MULT", "DIVI", "INV", "AND", "OR", "NEG", "CME", "CMA", "CEQ", "CDIF", "CMEQ", "CMAQ", "START", "HLT", "STR", "JMP", "JMPF", "NULL", "RD", "PRN", "ALLOC", "DALLOC", "CALL", "RETURN" };
			int aux = 1;

			//Lendo o arquivo
			if (enderecoArquivo != "")
			{
				linha = System.IO.File.ReadAllLines(enderecoArquivo);
				//Criando Objetos com as linhas
				for (int n = 0; n < linha.Length; n++)
				{
					if (linha[n].Contains(' '))
					{
						linhaEspacada = linha[n].Split(' ');
						if (linhaEspacada.Length == 3)
						{
							if (linhaEspacada[2].Contains(','))
							{
								atributos = linhaEspacada[2].Split(',');
								linhas.Add(new Linha(n, linhaEspacada[0], linhaEspacada[1], atributos[0], atributos[1]));
							}
							else
							{
								linhas.Add(new Linha(n, linhaEspacada[0], linhaEspacada[1], linhaEspacada[2]));
							}
						}
						else
						{
							for (int j = 0; j < instrucoes.Length; j++)
							{
								if (linhaEspacada[0].Equals(instrucoes[j]))
								{
									if (linhaEspacada[1].Contains(','))
									{
										atributos = linhaEspacada[1].Split(',');
										linhas.Add(new Linha(n, null, linhaEspacada[0], atributos[0], atributos[1]));
										aux = 0;
										break;
									}
									else
									{
										linhas.Add(new Linha(n, null, linhaEspacada[0], linhaEspacada[1], null));
										aux = 0;
										break;
									}
								}
							}
							if (aux == 1)
							{
								linhas.Add(new Linha(n, linhaEspacada[0], linhaEspacada[1]));
							}
							else
							{
								aux = 1;
							}
						}
					}
					else
					{
						linhas.Add(new Linha(n, linha[n]));
					}
				}
			}
		}

		public void RecebendoArquivo()
		{
			var FD = new System.Windows.Forms.OpenFileDialog();
			if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
				enderecoArquivo = FD.FileName;
			}
		}

		//Executa as instruções 
		public void ExecutarIntrucoes()
		{
			int k, j;
			string valor = "";
			bool numerico = true;
			switch (linhas[i].Instrução)
			{

				case "LDC": //S:=s + 1 ; M [s]: = k
					s = s + 1;
					memoria[s] = int.Parse(linhas[i].Atributo1);
					break;

				case "LDV": //S:=s + 1 ; M[s]:=M[n] 
					s = s + 1;
					memoria[s] = memoria[int.Parse(linhas[i].Atributo1)];
					break;

				case "ADD": //M[s-1]:=M[s-1] + M[s]; s:=s - 1
					memoria[s - 1] = memoria[s - 1] + memoria[s];
					s = s - 1;
					break;

				case "SUB": //M[s-1]:=M[s-1] - M[s]; s:=s - 1
					memoria[s - 1] = memoria[s - 1] - memoria[s];
					s = s - 1;
					break;

				case "MULT": //  M[s-1]:=M[s-1] * M[s]; s:=s - 1
					memoria[s - 1] = memoria[s - 1] * memoria[s];
					s = s - 1;
					break;

				case "DIVI": //M[s-1]:=M[s-1] div M[s]; s:=s - 1 
					memoria[s - 1] = memoria[s - 1] / memoria[s];
					s = s - 1;
					break;

				case "INV":// M[s]:= -M[s] 
					memoria[s] = -memoria[s];
					break;

				case "AND"://se M [s-1] = 1 e M[s] = 1  então M[s-1]:=1  senão M[s-1]:=0;  s:=s - 1 
					if (memoria[s - 1] == 1 && memoria[s] == 1)
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "OR"://se M[s-1] = 1  ou M[s] = 1  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] == 1 || memoria[s] == 1)
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "NEG":// M[s]:= 1 - M[s] 
					memoria[s] = 1 - memoria[s];
					break;

				case "CME"://se M[s-1] < M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] < memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "CMA"://se M[s-1] > M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] > memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "CEQ"://se M[s-1] = M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] == memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "CDIF"://se M[s-1] ≠ M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] != memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "CMEQ"://se M[s-1] <= M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] <= memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "CMAQ"://se M[s-1] >= M[s]  então M[s-1]:=1  senão M[s-1]:=0; s:=s - 1 
					if (memoria[s - 1] >= memoria[s])
					{
						memoria[s - 1] = 1;
					}
					else
					{
						memoria[s - 1] = 0;
					}
					s = s - 1;
					break;

				case "START"://S:=-1 
					s = -1;
					break;

				case "HLT": //“Pára a execução da MVD”  
					textBox2.Text = textBox2.Text + "" + "Programa Finalizado."+ "\n";
					return;

				case "STR": //M[n]:=M[s]; s:=s-1 
					memoria[int.Parse(linhas[i].Atributo1)] = memoria[s];
					s = s - 1;
					break;

				case "JMP": // i:= t 
					foreach (Linha n in linhas)
					{
						if (linhas[i].Atributo1 == n.Label)
						{
							i = n.Indice - 1;
							break;
						}
					}
					break;

				case "JMPF": //se M[s] = 0 então i:=t senão i:=i + 1;  s:=s-1;
					if (memoria[s] == 0)
					{
						foreach (Linha n in linhas)
						{
							if (linhas[i].Atributo1 == n.Label)
							{
								i = n.Indice - 1;
								break;
							}
						}
					}
					else
					{
						//i = i + 1;
					}
					s = s - 1;
					break;

				case "NULL"://Nada
					break;

				//ARRUMAR
				case "RD": //S:=s + 1; M[s]:= “próximo valor de entrada”. 
					s = s + 1;
					do
					{
						valor = Microsoft.VisualBasic.Interaction.InputBox("Digite o valor desejado.", "Máquina Virtual");
						numerico = true;
						for (j = 0; j < valor.Length; j++)
						{
							if(!char.IsDigit(valor[j]))
							{
								if (valor[0] == '-' || valor[0] == '+')
								{
								
								}
								else
								{
									numerico = false;
								}
							}
						}
					}while (valor == "" || numerico == false);
					memoria[s] = int.Parse(valor);
					textBox2.Text = textBox2.Text + "" + memoria[s] + "\n";
					break;

				//ARRUMAR
				case "PRN": // “Imprimir M[s]”; s:=s-1 
					textBox1.Text = textBox1.Text + "" + memoria[s] + "\n";
					s = s - 1;
					break;

				case "ALLOC": //Para k:=0 até n-1 faça      {s:=s + 1; M[s]:=M[m+k]}
					k = 0;
					while (k <= (int.Parse(linhas[i].Atributo2) - 1))
					{
						s = s + 1;
						memoria[s] = memoria[int.Parse(linhas[i].Atributo1) + k];
						k++;
					}
					break;

				case "DALLOC": //Para  k:=n-1  até 0  faça       {M[m+k]:=M[s]; s:=s - 1} 
					k = (int.Parse(linhas[i].Atributo2) - 1);
					while (k > -1)
					{
						memoria[(int.Parse(linhas[i].Atributo1) + k)] = memoria[s];
						s = s - 1;
						k--;
					}
					break;

				case "CALL": //S:=s + 1; M[s]:=i + 1; i:=t 
					s = s + 1;
					memoria[s] = i + 1;
					foreach (Linha n in linhas)
					{
						if (linhas[i].Atributo1 == n.Label)
						{
							i = n.Indice - 1;
							break;
						}
					}
					break;

				case "RETURN"://  i:= M[s]; s:=s - 1 
					i = memoria[s] - 1;
					s = s - 1;
					break;
			}
		}

		private void SelecionaBreakPoint(object sender, DataGridViewCellEventArgs e)
		{
			bool encontrado = false;
			int j;

			for (int i = 0; i < breakpoints.Count; i++)
			{
				if (breakpoints[i] == e.RowIndex)
				{
					breakpoints.RemoveAt(i);
					encontrado = true;
				}
			}
	
			if(encontrado == false)
				breakpoints.Add(e.RowIndex);

			//Colocando BreakPoint
			int aux = 0;
			for (int i = 0; i < breakpoints.Count; i++)
			{
				j = breakpoints[i];
				aux = 0;
				foreach (DataGridViewRow linha in guna2DataGridView1.Rows)
				{
					if (aux == j)
					{
						linha.Cells[0].Style.BackColor = Color.Khaki;
					}
					aux++;
				}
			}

			//Retirando BreakPoint
			aux = 0;
			foreach (DataGridViewRow linha in guna2DataGridView1.Rows)
			{
				encontrado = false;
				if (linha.Cells[0].Style.BackColor == Color.Khaki)
				{
					for (int i = 0; i < breakpoints.Count; i++)
					{
						if (aux == breakpoints[i])
						{
							encontrado = true;
						}
					}
					if (encontrado == false)
					{
						linha.Cells[0].Style.BackColor = Color.White;
					}
				}
				aux++;
			}
		}
	}
}
