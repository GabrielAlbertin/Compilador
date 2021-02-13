using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	[Serializable]
	public class Erro : SystemException
	{
		public string Mensagem;
		public int Linha;

		public Erro(string mensagem, int linha)
		{
			Mensagem = mensagem;
			Linha = linha;
		}
	}
}
