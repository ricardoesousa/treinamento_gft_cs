using System;

namespace DesafioMattos
{
    public class Principal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione uma linguagem:");
            Console.WriteLine("1 para Inglês");
            Console.WriteLine("2 para Espanhol");
            Console.WriteLine("3 para Alemão");

            FabricaAlo fabrica = new FabricaAlo();
            AloMundo aloMundo;
 
            do
            {
                int selecao = Convert.ToInt32(Console.ReadLine());
                aloMundo = fabrica.CriaAloMundo(selecao);
                if (aloMundo == null)
                {
                    Console.WriteLine("Escolha um opção válida!");
                }
            }
            while (aloMundo == null);

            aloMundo.falaAlo();
        }
    }

    public interface AloMundo
    {
        public void falaAlo();
    }

    public class Ingles : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hello World");
        }
    }

    public class Espanhol : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hola Mundo");
        }
    }

    public class Alemao : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hallo Welt");
        }
    }

    public class FabricaAlo
    {
        
        public AloMundo CriaAloMundo(int selecao)
        {
            switch (selecao)
            {
                case 1:
                    return new Ingles();
                case 2:
                    return new Espanhol();
                case 3:
                    return new Alemao();
                default:
                    return null;
            }
        }
    }
}


