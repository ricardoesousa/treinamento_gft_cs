using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Parte_2
{

	public class Principal
	{
		static void Main(string[] args)
		{
		Gerente p1 = new Gerente("Ricardo", 30, 25000);
		Supervisor p2 = new Supervisor("Silvana", 55, 10000);
		Vendedor p3 = new Vendedor("Mauro", 62, 8000);
		Gerente p4 = new Gerente("Rodrigo", 20, 30000);
		Vendedor p5 = new Vendedor("Samara", 47, 7000);
		}

	}

	public abstract class Funcionario
	{
		private string nome;
		private int idade;
		private float salario;

		public Funcionario(string nome, int idade, float salario)
		{
			this.nome = nome;
			this.idade = idade;
			this.salario = salario;

			Console.WriteLine("{0} tem {1} anos e bonificação de R${2:0,000.00}",nome,idade,bonificacao());
		}

		public virtual float bonificacao()
		{
			return this.salario;
		}
	}

	public class Gerente : Funcionario
	{
		public Gerente(string nome, int idade, float salario) : base(nome, idade, salario)
		{

		}

		public override float bonificacao()
		{
			return base.bonificacao() + 10000.00f;
		}
	}

	public class Supervisor : Funcionario
	{
		public Supervisor(string nome, int idade, float salario) : base(nome, idade, salario)
		{

		}

		public override float bonificacao()
		{
			return base.bonificacao() + 5000.00f;
		}
	}

	public class Vendedor : Funcionario
	{
		public Vendedor(string nome, int idade, float salario) : base(nome, idade, salario)
		{

		}

		public override float bonificacao()
		{
			return base.bonificacao() + 3000.00f;
		}
	}
}

