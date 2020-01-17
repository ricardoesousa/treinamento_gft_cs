using System;
using System.Collections.Generic;

namespace Desafio04_cs
{
    public class Principal
    {
        static void Main(string[] args)
        {
            List<Livro> livros = new List<Livro>();
            livros.Add(new Livro("Harry Potter", 40, 50, "J. K. Rowling", "fantasia", 300));
            livros.Add(new Livro("Senhor do Anéis", 60, 30, "J. R. R. Tolfien", "fantasia", 500));
            livros.Add(new Livro("Java POO", 20, 50, "GFT", "educativo", 500));

            List<VideoGame> games = new List<VideoGame>();
            games.Add(new VideoGame("PS4", 1800, 100, "Sony", "Slim", false));
            games.Add(new VideoGame("PS4", 1000, 7, "Sony", "Slim", true));
            games.Add(new VideoGame("XBOX", 1500, 500, "Microsoft", "One", false));

            Loja americanas = new Loja("Americanas", "12345678", livros, games);

            livros[1].calculaImposto();
            livros[2].calculaImposto();

            games[1].calculaImposto();
            games[0].calculaImposto();

            americanas.listaLivros();
            americanas.listaVideoGames();
            americanas.calculaPatrimonio();
        }
    }

    public abstract class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Qtd { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, double preco, int qtd)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Qtd = qtd;
        }
    }

    public class Livro : Produto, Imposto
    {
        public string Autor { get; set; }
        public string Tema { get; set; }
        public int QtdPag { get; set; }

        public Livro()
        {

        }

        public Livro(string nome, double preco, int qtd, string autor, string tema, int qtdPag) : base(nome, preco, qtd)
        {
            this.Autor = autor;
            this.Tema = tema;
            this.QtdPag = qtdPag;
        }

        public double calculaImposto()
        {
            if (this.Tema == "educativo")
            {
                Console.WriteLine("Livro Educativo não tem imposto: {0}", this.Nome);
                return 0;
            }
            else
            {
                double imposto;
                imposto = this.Preco * 0.10;
                Console.WriteLine("R$ {0:0.00} de impostos sobre o livro {1}", imposto, this.Nome);
                return imposto;
            }

        }


    }

    public class VideoGame : Produto, Imposto
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool IsUsado { get; set; }

        public VideoGame()
        {

        }

        public VideoGame(string nome, double preco, int qtd, string marca, string modelo, bool isUsado) : base(nome, preco, qtd)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.IsUsado = isUsado;
        }

        public double calculaImposto()
        {
            if (this.IsUsado)
            {
                double imposto;
                imposto = this.Preco * 0.25;
                Console.WriteLine("Imposto {0} {1} usado, R$ {2:0.00}.", this.Nome, this.Modelo, imposto);
                return imposto;
            }
            else
            {
                double imposto;
                imposto = this.Preco * 0.45;
                Console.WriteLine("Imposto {0} {1}, R$ {2:0.00}.", this.Nome, this.Modelo, imposto);
                return imposto;
            }

        }
    }

    public class Loja
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public List<Livro> livros { get; set; }
        public List<VideoGame> videoGames { get; set; }

        public Loja()
        {

        }

        public Loja(string nome, string cnpj, List<Livro> livros, List<VideoGame> videoGames)
        {
            this.Nome = nome;
            this.Cnpj = cnpj;
            this.livros = livros;
            this.videoGames = videoGames;

        }

        public void listaLivros()
        {
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            if (livros.Count.Equals(0))
            {
                Console.WriteLine("A loja não tem livros no seu estoque");
            }
            else
            {
                Console.WriteLine("A loja {0} possui estes livros para venda:", this.Nome);

                for (int i = 0; i < livros.Count; i++)
                {
                    Console.WriteLine("Titulo: {0} , preço: {1:0.00} , quantidade: {2} em estoque.", livros[i].Nome, livros[i].Preco, livros[i].Qtd);
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }

        public void listaVideoGames()
        {
            if (livros.Count.Equals(0))
            {
                Console.WriteLine("A loja não tem video-games no seu estoque");
            }
            else
            {
                Console.WriteLine("A loja {0} possui estes video-games para venda:", this.Nome);

                for (int i = 0; i < videoGames.Count; i++)
                {
                    Console.WriteLine("Video-game: {0} , preço: {1:0.00} , quantidade: {2} em estoque.", videoGames[i].Modelo, videoGames[i].Preco, livros[i].Qtd);
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        }

        public void calculaPatrimonio()
        {
            double somaProdutos = 0;
            for (int i = 0; i < livros.Count; i++)
            {
                somaProdutos += livros[i].Preco * livros[i].Qtd;
            }
            for (int i = 0; i < livros.Count; i++)
            {
                somaProdutos += videoGames[i].Preco * videoGames[i].Qtd;
            }
            Console.WriteLine("O patrimonio da loja: {0} é de R$ {1:0.00}", this.Nome, somaProdutos);
        }
    }

    public interface Imposto
    {
        public double calculaImposto();

    }
    
}
