using Aplikacija;

Izbornik();


public partial class Program
{
    public static void Izbornik()
    {
        bool ponovi = true;
        Console.Clear();
        while (ponovi)
        {
            ponovi = false;
            Console.WriteLine("********** SKLADISTE **********");
            Console.WriteLine("* 1. Blagajna                 *");
            Console.WriteLine("* 2. Skladiste                *");
            Console.WriteLine("* 3. Kupci                    *");
            Console.WriteLine("* 4. Izlaz                    *");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.Write("Odaberite opciju: ");
            string odabir = Console.ReadLine();


            switch(odabir)
            {
                case "1":
                    Blagajna.Izbornik();
                    break;
                case "2":
                    Skladiste.Izbornik();
                    break;
                case "3":
                    Kupci.Izbornik();
                    break;
                default:
                    break;
            }
        }

    }
    
}



