using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija
{
    class Skladiste
    {
        public static void Izbornik()
        {
            bool ponovi = true;
            Console.Clear();
            while(ponovi)
            {
                ponovi = false;
                Console.WriteLine("********** SKLADISTE **********");
                Console.WriteLine("* 1. Popis proizvoda          *");
                Console.WriteLine("* 2. Dodavanje proizvoda      *");
                Console.WriteLine("* 3. Izmjena proizvoda        *");
                Console.WriteLine("* 4. Brisanje proizvoda       *");
                Console.WriteLine("* 5. Povratak na glavni izbornik");
                Console.WriteLine("*******************************");
                Console.WriteLine();
                Console.Write("Odaberite opciju: ");
                string odabir = Console.ReadLine();

                switch(odabir)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("***** POPIS PROIZVODA *****");
                        foreach(Proizvodi p in DbMethods.DohvatiProizvode())
                        {
                            Console.WriteLine($"{p.Id}. Naziv: {p.Naziv} Mjera: {p.MjeraProizvoda.Naziv}, Cijena: {p.Cijena}  '€'  , Dostupan: {p.Dostupan},Vrijeme kreriranja: {p.VrijemeKreiranja}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();

                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("***** DODAVANJE PROIZVODA *****");
                        Proizvodi proizvod = new Proizvodi();
                        Console.Write("Naziv: ");
                        string nazivProizvoda = Console.ReadLine();
                        if(!string.IsNullOrEmpty(nazivProizvoda))
                        {
                            proizvod.Naziv = nazivProizvoda;
                        }
                        Console.Write("Mjera :");
                        short mjeraProizvoda;
                        if (short.TryParse(Console.ReadLine(),out mjeraProizvoda))
                        {
                            proizvod.MjeraProizvodaId = mjeraProizvoda;
                        }
                        Console.Write("Cijena: ");
                        decimal cijena;
                        if (decimal.TryParse(Console.ReadLine(),out cijena))
                        {
                            proizvod.Cijena = cijena;
                        }
                        Console.Write("Dostupan unesite da/ne (ako je proizvod dostupan da, u suprotnom ne)");
                        string dostupan = Console.ReadLine();
                        if(!string.IsNullOrEmpty(dostupan))
                        {
                            if(dostupan.ToLower() == "da")
                            {
                                proizvod.Dostupan = true;
                            }
                            if (dostupan.ToLower() == "ne")
                            {
                                proizvod.Dostupan = false;
                            }
                        }
                        proizvod.VrijemeKreiranja = DateTime.Now;
                        DbMethods.DodajProizvod(proizvod);
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadLine();
                        Izbornik();
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("IZMJENA PROIZVODA");
                        Console.WriteLine("Uneite id proizvoda: ");

                        Proizvodi proizvodZaIzmjenu = DbMethods.DohvatiProizvod(int.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        Console.Write($"Naziv ({proizvodZaIzmjenu.Naziv}): ");
                        string naziv = Console.ReadLine();
                        if(!string.IsNullOrEmpty(naziv))
                        {
                            proizvodZaIzmjenu.Naziv = naziv;
                        }
                        Console.WriteLine();
                        Console.Write($"Cijena ({proizvodZaIzmjenu.Cijena}): ");
                        decimal cijenaProizvoda;
                        if(decimal.TryParse(Console.ReadLine(), out cijenaProizvoda))
                        {
                            proizvodZaIzmjenu.Cijena = cijenaProizvoda;
                        }
                        Console.WriteLine();
                        Console.Write($"Mjera proizvoda Id ({proizvodZaIzmjenu.MjeraProizvodaId}): ");
                        short mjeraProizvodId;
                        if(short.TryParse(Console.ReadLine(),out mjeraProizvodId))
                        {
                            proizvodZaIzmjenu.MjeraProizvodaId = mjeraProizvodId;
                        }

                        string dostupanIzBaze = (bool)(proizvodZaIzmjenu.Dostupan) ? "da" : "ne";
                        Console.Write($"Dostupan ({dostupanIzBaze}): ");
                        string dostupanProizvod = Console.ReadLine();
                        if (!string.IsNullOrEmpty(dostupanProizvod))
                        {
                            if (dostupanProizvod.ToLower() == "da")
                            {
                                proizvodZaIzmjenu.Dostupan = true;
                            }
                            else if (dostupanProizvod.ToLower() == "ne")
                            {
                                proizvodZaIzmjenu.Dostupan = false;
                            }

                            proizvodZaIzmjenu.MjeraProizvodaId = mjeraProizvodId;
                        }
                        proizvodZaIzmjenu.VrijemeKreiranja = DateTime.Now;
                        DbMethods.IzmjenaProizvoda(proizvodZaIzmjenu);
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("BRISANJE PROIZVODA: ");
                        Console.WriteLine("Unesite id: ");
                        Proizvodi proizvodZaBrisanje = DbMethods.DohvatiProizvod(int.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        DbMethods.ObrisiProizvod(proizvodZaBrisanje.Id);

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "5":
                        Program.Izbornik();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Nepostojeca opcija! ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                        Console.Clear();
                        ponovi = true;
                        break;
                }

            }
        }
    }
}
