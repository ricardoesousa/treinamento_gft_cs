using System;

namespace DesafioMattos2
{
    class Cliente
    {
        static void Main(string[] args)
        {
            FabricaDePizza fabrica = new Pizzaria_SP();
            Pizza pizza = fabrica.CriarPizza();
            string sabor = Console.ReadLine();
        }

    }

    public interface FabricaDePizza
    {
        public Pizza CriarPizza(string sabor);
    }


    public class Pizzaria_SP: FabricaDePizza
    {
        public Pizza CriarPizza(string sabor)
        {
            switch (sabor.ToLower())
            {
                case "mussarela":
                    return new PizzaMussarela("Massa, Molho, Mussarela, Tomate, Alecrim, Mangericão");
                case "calabresa":
                    return new PizzaCalabresa("Massa, Molho, Calabresa, Orégano, Azeitona");
                case "atum":
                    return new PizzaAtum("Massa, Molho, Atum, Mussarela, Tomate, Azeitona");
                default:
                    return null;
            }
    }

    public class Pizzaria_RJ : FabricaDePizza
    {
        public Pizza CriarPizza(string sabor)
        {
            switch (sabor.ToLower())
            {
                case "mussarela":
                    return new PizzaMussarela("Massa, Molho, Queijo, Tomate, Orégano, Azeitona");
                case "calabresa":
                    return new PizzaCalabresa("Massa, Molho, Calabresa, Cebola, Orégano, Azeitona");
                case "atum":
                    return new PizzaAtum("Massa, Molho, Atum, Cebola, Orégano, Azeitona");
                default:
                    return null;
            }
        }
    }

    public abstract class Pizza
    {
        string ingredientes;
        public Pizza(string ingredientes)
        {
            this.ingredientes = ingredientes;
        }
        void exibirIngredientes()
        {
            Console.WriteLine(ingredientes);
        }
    }

    public class PizzaMussarela : Pizza
    {
        public PizzaMussarela(string ingredientes) : base(ingredientes)
        {

        }
        public void exibirIngredientes()
        {
        }
    }

    public class PizzaCalabresa : Pizza
    {
        public PizzaCalabresa(string ingredientes) : base(ingredientes)
        {

        }
        public void exibirIngredientes()
        {
        }
    }

    public class PizzaAtum : Pizza
    {
        public PizzaAtum(string ingredientes) : base(ingredientes)
        {

        }
        public void exibirIngredientes()
        {
        }
    }

}