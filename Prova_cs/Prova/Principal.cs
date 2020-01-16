using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Parte_1

{
	public class Principal
	{
		static void Main(string[] args)
		{
			List<Pessoa> pessoas = new List<Pessoa>();
			pessoas.Add(new Pessoa("Joao", 15));
			pessoas.Add(new Pessoa("Leandro", 21));
			pessoas.Add(new Pessoa("Paulo", 17));
			pessoas.Add(new Pessoa("Jessica", 18));

			int maiorIdade = -1;
			string maisVelha = "";
			int idadeJessica = -1;

			for (int i = 0; i < pessoas.Count; i++)
			{
				if ((pessoas[i].idade) > maiorIdade)
				{
					maiorIdade = pessoas[i].idade;
					maisVelha = pessoas[i].nome;
				}
			}
			Console.WriteLine("A pessoa mais velha é: {0}", maisVelha);

			Console.WriteLine("A lista possui {0} pessoas", pessoas.Count);

			for (int i = 0; i < pessoas.Count; i++)
			{
				if (pessoas[i].idade < 18)
				{
					pessoas.RemoveAt(i);
				}

			}
			Console.WriteLine("A lista possui {0} pessoas", pessoas.Count);

			for (int i = 0; i < pessoas.Count; i++)
			{
				if (pessoas[i].nome == "Jessica")
				{
					idadeJessica = pessoas[i].idade;
				}
			}
			Console.WriteLine("A Jessica está na lista e tem {0} anos", idadeJessica);




		}
	}
	public class Pessoa
	{
		public string nome { get; set; }
		public int idade;

		public Pessoa(String nome, int idade)
		{
			this.nome = nome;
			this.idade = idade;
		}
	}
}