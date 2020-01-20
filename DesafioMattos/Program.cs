using System;

namespace DesafioMattos
{
    public class Principal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione uma linguagem:");
            Console.WriteLine("'en' para English");
            Console.WriteLine("'sp' para Spanish");
            Console.WriteLine("'de' para German");

            string language = Console.ReadLine();

            FabricaAlo fabrica = new FabricaAlo();

            AloMundo a = fabrica.CriaAloMundo(language);

            a.falaAlo();
        }
    }

    public interface AloMundo
    {
        public void falaAlo();
    }

    public class English : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hello World");
        }
    }

    public class Spanish : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hola Mundo");
        }
    }

    public class German : AloMundo
    {
        public void falaAlo()
        {
            Console.WriteLine("Hallo Welt");
        }
    }

    public class FabricaAlo
    {
        public AloMundo CriaAloMundo(string language)
        {
            switch (language)
            {
                case "en":
                    return new English();
                case "sp":
                    return new Spanish();
                case "de":
                    return new German();
                default:
                    return null;
            }
        }
    }
}


