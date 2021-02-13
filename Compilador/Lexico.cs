using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
	class Lexico
	{
		public Token ExecutarLexico()
		{
			//Algoritmo
			//Tratando espaços e comentarios
			TratarComentarioeEspaco();

			if (Program.i != Program.texto.Length)
			{
				//TRATA CARACTER
				if (Char.IsDigit(Program.texto[Program.i]))
				{
					TrataDigito();
				}
				else
				{
					if (Char.IsLetter(Program.texto[Program.i]))
					{
						//TRATA IDENTIFICADOR E PALAVRA RESERVADA
						TrataIdentificadorePalavraReservada();
					}
					else
					{
						if (Program.texto[Program.i] == ':')
						{
							//TRATAR ATRIBUICAO
							TrataAtribuicao();
						}
						else
						{
							if (Program.texto[Program.i] == '+' || Program.texto[Program.i] == '-' || Program.texto[Program.i] == '*')
							{
								//TRATA OPERADOR ARITMETICO
								TrataOperadorAritmetico();
							}
							else
							{
								if (Program.texto[Program.i] == '>' || Program.texto[Program.i] == '<' || Program.texto[Program.i] == '=' || Program.texto[Program.i] == '!')
								{
									//TRATA OPERADOR RELACIONAL
									TrataOperadorRelacional();
								}
								else
								{
									if (Program.texto[Program.i] == ';' || Program.texto[Program.i] == ',' || Program.texto[Program.i] == '(' || Program.texto[Program.i] == ')' || Program.texto[Program.i] == '.')
									{
										//TRATA PONTUACAO
										TrataPontuacao();
									}
									else
									{
										throw new Erro("Erro, palavra usada incorretamente na linha: ", Program.RetornaLinha(Program.i));
									}
								}
							}
						}
					}
				}
			}
			return Program.tokens[Program.tokens.Count - 1];
		}

		public void TratarComentarioeEspaco()
		{
			while (Program.i != Program.texto.Length && (Program.texto[Program.i] == ' ' || Program.texto[Program.i] == '{' || Program.texto[Program.i] == '/'))
			{
				if (Program.texto[Program.i] == '{')
				{
					while (Program.i != Program.texto.Length && Program.texto[Program.i] != '}')
					{
						Program.i++;
					}
					if (Program.i != Program.texto.Length)
					{
						Program.i++;
					}
				}
				while (Program.i != Program.texto.Length && Program.texto[Program.i] == ' ')
				{
					Program.i++;
				}
				if (Program.i != Program.texto.Length && Program.texto[Program.i] == '/')
				{
					Program.i++;
					if (Program.texto[Program.i] == '*')
					{
						while (Program.i != Program.texto.Length)
						{
							Program.i++;
							if (Program.i != Program.texto.Length && Program.texto[Program.i] == '*')
							{
								Program.i++;
								if (Program.i != Program.texto.Length && Program.texto[Program.i] == '/')
								{
									Program.i++;
									break;
								}
							}
						}
					}
					else
					{
						throw new Erro("Erro, caracter '/' nao esperado na linha: ", Program.RetornaLinha(Program.i));
					}
				}
			}
		}

		public void TrataDigito()
		{
			string num;
			num = "";
			num = num + Program.texto[Program.i];
			Program.i++;
			while (Char.IsDigit(Program.texto[Program.i]))
			{
				num = num + Program.texto[Program.i];
				Program.i++;
			}
			Program.tokens.Add(new Token(num, "snumero", Program.RetornaLinha(Program.i)));
		}

		public void TrataIdentificadorePalavraReservada()
		{
			string id = "";
			id = id + Program.texto[Program.i];
			Program.i++;

			while (Program.i != Program.texto.Length && (Char.IsLetter(Program.texto[Program.i]) || Char.IsDigit(Program.texto[Program.i]) || Program.texto[Program.i] == '_'))
			{
				id = id + Program.texto[Program.i];
				Program.i++;
			}

			switch (id)
			{
				case "programa":
					Program.tokens.Add(new Token(id, "sprograma", Program.RetornaLinha(Program.i)));
					break;
				case "se":
					Program.tokens.Add(new Token(id, "sse", Program.RetornaLinha(Program.i)));
					break;
				case "entao":
					Program.tokens.Add(new Token(id, "sentao", Program.RetornaLinha(Program.i)));
					break;
				case "senao":
					Program.tokens.Add(new Token(id, "ssenao", Program.RetornaLinha(Program.i)));
					break;
				case "enquanto":
					Program.tokens.Add(new Token(id, "senquanto", Program.RetornaLinha(Program.i)));
					break;
				case "faca":
					Program.tokens.Add(new Token(id, "sfaca", Program.RetornaLinha(Program.i)));
					break;
				case "faça":
					Program.tokens.Add(new Token(id, "sfaca", Program.RetornaLinha(Program.i)));
					break;
				case "inicio":
					Program.tokens.Add(new Token(id, "sinicio", Program.RetornaLinha(Program.i)));
					break;
				case "fim":
					Program.tokens.Add(new Token(id, "sfim", Program.RetornaLinha(Program.i)));
					break;
				case "escreva":
					Program.tokens.Add(new Token(id, "sescreva", Program.RetornaLinha(Program.i)));
					break;
				case "leia":
					Program.tokens.Add(new Token(id, "sleia", Program.RetornaLinha(Program.i)));
					break;
				case "var":
					Program.tokens.Add(new Token(id, "svar", Program.RetornaLinha(Program.i)));
					break;
				case "inteiro":
					Program.tokens.Add(new Token(id, "sinteiro", Program.RetornaLinha(Program.i)));
					break;
				case "booleano":
					Program.tokens.Add(new Token(id, "sbooleano", Program.RetornaLinha(Program.i)));
					break;
				case "verdadeiro":
					Program.tokens.Add(new Token(id, "sverdadeiro", Program.RetornaLinha(Program.i)));
					break;
				case "falso":
					Program.tokens.Add(new Token(id, "sfalso", Program.RetornaLinha(Program.i)));
					break;
				case "procedimento":
					Program.tokens.Add(new Token(id, "sprocedimento", Program.RetornaLinha(Program.i)));
					break;
				case "funcao":
					Program.tokens.Add(new Token(id, "sfuncao", Program.RetornaLinha(Program.i)));
					break;
				case "div":
					Program.tokens.Add(new Token(id, "sdiv", Program.RetornaLinha(Program.i)));
					break;
				case "e":
					Program.tokens.Add(new Token(id, "se", Program.RetornaLinha(Program.i)));
					break;
				case "ou":
					Program.tokens.Add(new Token(id, "sou", Program.RetornaLinha(Program.i)));
					break;
				case "nao":
					Program.tokens.Add(new Token(id, "snao", Program.RetornaLinha(Program.i)));
					break;
				default:
					Program.tokens.Add(new Token(id, "sidentificador", Program.RetornaLinha(Program.i)));
					break;

			}
		}

		public void TrataAtribuicao()
		{
			string id;
			id = "";
			id = id + Program.texto[Program.i];
			Program.i++;
			if (Program.texto[Program.i] == '=')
			{
				id = id + Program.texto[Program.i];
				Program.tokens.Add(new Token(id, "satribuicao", Program.RetornaLinha(Program.i)));
				Program.i++;
			}
			else
			{
				Program.tokens.Add(new Token(id, "sdoispontos", Program.RetornaLinha(Program.i)));
			}
		}

		public void TrataOperadorAritmetico()
		{
			switch (Program.texto[Program.i])
			{
				case '+':
					Program.tokens.Add(new Token("+", "smais", Program.RetornaLinha(Program.i)));
					break;
				case '-':
					Program.tokens.Add(new Token("-", "smenos", Program.RetornaLinha(Program.i)));
					break;
				case '*':
					Program.tokens.Add(new Token("*", "smult", Program.RetornaLinha(Program.i)));
					break;
			}
			Program.i++;
		}

		public void TrataOperadorRelacional()
		{
			string id = "";
			id = id + Program.texto[Program.i];

			if (Program.texto[Program.i] == '>')
			{
				Program.i++;
				if (Program.texto[Program.i] == '=')
				{
					id = id + Program.texto[Program.i];
					Program.tokens.Add(new Token(id, "smaiorigual", Program.RetornaLinha(Program.i)));
					Program.i++;
				}
				else
				{
					Program.tokens.Add(new Token(id, "smaior", Program.RetornaLinha(Program.i)));
				}
			}
			else
			{
				if (Program.texto[Program.i] == '<')
				{
					Program.i++;
					if (Program.texto[Program.i] == '=')
					{
						id = id + Program.texto[Program.i];
						Program.tokens.Add(new Token(id, "smenorigual", Program.RetornaLinha(Program.i)));
						Program.i++;
					}
					else
					{
						Program.tokens.Add(new Token(id, "smenor", Program.RetornaLinha(Program.i)));
					}
				}
				else
				{
					if (Program.texto[Program.i] == '!')
					{
						Program.i++;
						if (Program.texto[Program.i] == '=')
						{
							id = id + Program.texto[Program.i];
							Program.tokens.Add(new Token(id, "sdif", Program.RetornaLinha(Program.i)));
							Program.i++;
						}
						else
						{
							throw new Erro("Erro, apos '!' eh esperado '=' na linha: ", Program.RetornaLinha(Program.i));
						}
					}
					else
					{
						if (Program.texto[Program.i] == '=')
						{
							Program.tokens.Add(new Token(id, "sigual", Program.RetornaLinha(Program.i)));
							Program.i++;
						}
					}
				}
			}
		}

		public void TrataPontuacao()
		{
			switch (Program.texto[Program.i])
			{
				case ';':
					Program.tokens.Add(new Token(";", "spontovirgula", Program.RetornaLinha(Program.i)));
					break;
				case ',':
					Program.tokens.Add(new Token(",", "svirgula", Program.RetornaLinha(Program.i)));
					break;
				case '(':
					Program.tokens.Add(new Token("(", "sabre_parenteses", Program.RetornaLinha(Program.i)));
					break;
				case ')':
					Program.tokens.Add(new Token(")", "sfecha_parenteses", Program.RetornaLinha(Program.i)));
					break;
				case '.':
					Program.tokens.Add(new Token(".", "sponto", Program.RetornaLinha(Program.i)));
					break;
			}
			Program.i++;
		}
	}
}
