using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVirtual
{
	public class Linha
	{
		
		public int Indice { set; get; }
		public string Label { set; get; }
		public string Instrução { set; get; }
		public string Atributo1 { set; get; }
		public string Atributo2 { set; get; }
		public static int count = 0;


		public Linha(int indice, string label, string instrução, string atr1, string atr2)
		{
			this.Indice = indice;
			this.Label = label;
			this.Instrução = instrução;
			this.Atributo1 = atr1;
			this.Atributo2 = atr2;
			count++;
		}

		public Linha(int indice, string label, string instrução, string atr1)
		{
			this.Indice = indice;
			this.Label = label;
			this.Instrução = instrução;
			this.Atributo1 = atr1;
			count++;
		}

		public Linha(int indice, string label, string instrução)
		{
			this.Indice = indice;
			this.Label = label;
			this.Instrução = instrução;
			count++;
		}

		public Linha(int indice, string instrução)
		{
			this.Indice = indice;
			this.Label = null;
			this.Instrução = instrução;
			count++;
		}

		public static int TotalLinhas()
		{
			return count;
		}

		public void Reset()
		{
			count = 0;

		}

	}
}
