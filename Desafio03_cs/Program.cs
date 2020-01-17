using System;

namespace Desafio03
{
    class Principal
    {
        static void Main(string[] args)
        {
            Veiculo teste = new Veiculo("Teste", "Teste", "Teste");

            teste.acelerar();
            teste.abastecer(60);

            Carro teste1 = new Carro("Renault", "Kwid", "Laranja");

            teste1.acelerar();
            teste1.abastecer(80);

            Aviao teste2 = new Aviao("Boeing", "777", "Azul");

            teste2.acelerar();
            teste2.abastecer("Querosene");

            Caminhao teste3 = new Caminhao("Volvo", "FH460", "Preto");

            teste3.acelerar();
            teste3.abastecer(500.1f);

        }
    }

    public class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public float Km { get; set; }
        public bool IsLigado { get; set; }
        public int LitrosCombustivel { get; set; }
        public int Velocidade { get; set; }
        public double Preco { get; set; }

        public Veiculo(string marca, string modelo, string cor)
        {
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }

        public virtual void acelerar()
        {
            Velocidade += 20;
            LitrosCombustivel -= 1;
            Console.WriteLine("Velocidade atual: {0}.", Velocidade);
        }

        public virtual void abastecer(int qtd)
        {
            LitrosCombustivel += qtd;
            Console.WriteLine("Você abasteceu {0} litros.", qtd);
        }

    }

    public class Carro : Veiculo
    {
        public Carro(string marca, string modelo, string cor) : base(marca, modelo, cor)
        {

        }

        public override void acelerar()
        {
            Velocidade += 20;
            LitrosCombustivel -= 1;
            Console.WriteLine("Velocidade atual: {0}.", Velocidade);
        }

        public override void abastecer(int qtd)
        {
            LitrosCombustivel += qtd;
            Console.WriteLine("Você abasteceu {0} litros.", qtd);
        }
    }

    public class Aviao : Veiculo
    {
        public Aviao(string marca, string modelo, string cor) : base(marca, modelo, cor)
        {

        }

        public override void acelerar()
        {
            Velocidade += 20;
            LitrosCombustivel -= 1;
            Console.WriteLine("Velocidade atual: {0}.", Velocidade);
        }

        public void abastecer(string qtd)
        {
            Console.WriteLine("Você abasteceu {0}.", qtd);
        }

    }
    
    public class Caminhao : Veiculo
    {
        public Caminhao(string marca, string modelo, string cor) : base(marca, modelo, cor)
        {

        }

        public override void acelerar()
        {
            Velocidade += 20;
            LitrosCombustivel -= 1;
            Console.WriteLine("Velocidade atual: {0}.", Velocidade);
        }

        public void abastecer(float qtd)
        {
            Console.WriteLine("Você abasteceu {0} litros.", qtd);
        }
    }
}
