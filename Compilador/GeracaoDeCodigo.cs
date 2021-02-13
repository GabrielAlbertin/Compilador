using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	class GeracaoDeCodigo
	{
		public List<GeracaoDeCodigo> codigo = new List<GeracaoDeCodigo>();    //Lista 
		public string label;                //Label
		public string instrucao;            //Comando
		public string arg1;                 //Argumento 1
		public string arg2;                 //Argumento 2
		public int rotulo = 0;
		public int auxAlloc = 0;

		public GeracaoDeCodigo()
		{
		}

		public GeracaoDeCodigo(string Label, string Instrucao, string Arg1, string Arg2)
		{
			this.label = Label;
			this.instrucao = Instrucao;
			this.arg1 = Arg1;
			this.arg2 = Arg2;
		}

		public void Gerar(string Label, string Instrucao, string Arg1, string Arg2)
		{
			codigo.Add(new GeracaoDeCodigo(Label, Instrucao, Arg1, Arg2));
		}

		public void GerarALLOC(int quantVar)
		{
			Gerar("", "ALLOC", "" + auxAlloc, "" + quantVar);
			auxAlloc = auxAlloc + quantVar;
		}

		public int GerarDALLOC(TabelaDeSimbolos tab)
		{
			int maiorNivel = tab.tabela[tab.tabela.Count - 1].escopo;
			int i = 0, quant_var = 0;

			while (i <= tab.tabela.Count - 1)
			{
				if (tab.tabela[i].escopo == maiorNivel)
				{
					if (tab.tabela[i].tipo == "inteiro" || tab.tabela[i].tipo == "boolean")
					{
						quant_var++;
					}
				}
				i++;
			}

			if (maiorNivel == 0)
			{
				Gerar("", "DALLOC", "" + 0, "" + (quant_var + 1));
			}
			else
			{
				if (quant_var == 0)
				{
					return 0;
				}

				Gerar("", "DALLOC", "" + (auxAlloc - quant_var), "" + quant_var);
			}
			return quant_var;
		}

		public void GerarArquivoObj()
		{
			string[] diretorioArquivoObj = Program.diretorio.Split('\\');
			string nome = "obj-" + diretorioArquivoObj[diretorioArquivoObj.Length - 1];
			diretorioArquivoObj[diretorioArquivoObj.Length - 1] = nome;
			int i = 0;
			nome = "";
			while (i != diretorioArquivoObj.Length)
			{
				nome = nome + diretorioArquivoObj[i] + '\\';
				i++;
			}

			nome = nome.Substring(0, nome.Length - 1);
			File.WriteAllText(nome, GerarTexto());
		}

		public string GerarTexto()
		{
			string texto = "", subtexto = "";
		

			foreach (var i in codigo)
			{
				subtexto = "";
				if (i.label != "")
				{
					subtexto = i.label + " " + i.instrucao + '\n';
				}
				else
				{
					if (i.instrucao != "" && i.arg1 != "" && i.arg2 != "")
					{
						subtexto = i.instrucao + " " + i.arg1 + "," + i.arg2 + '\n';
					}
					else
					{
						if (i.instrucao != "" && i.arg1 != "" && i.arg2 == "")
						{
							subtexto = i.instrucao + " " + i.arg1 + '\n';
						}
						else
						{
							if (i.instrucao != "" && i.arg1 == "" && i.arg2 == "")
							{
								subtexto = i.instrucao +'\n';
							}
						}
					}
				}
				texto = texto + subtexto;
			}
			texto = texto.Substring(0, texto.Length - 1);
			return texto;
		}
	}
}
