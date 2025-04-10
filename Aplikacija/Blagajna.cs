using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CRUD METODE ZA BLAGAJNU
// 1. Novi racun
// 2. Ispis racuna
// 3. Brisanje racuna
// 4. Update racuna (pomocu ID-a)
// 5. Povratak na glavni izbornik


namespace Aplikacija
{
    class Blagajna
    {
        public static void Izbornik()
        {
            bool ponovi = true;
            Console.Clear();
            while(ponovi)
            {
                ponovi = false;
                Console.WriteLine("*********** BLAGAJNA ***********");
                Console.WriteLine("* 1. Novi racun                *");
                Console.WriteLine("* 2. Ispis racuna              *");
                Console.WriteLine("* 3. Brisanje racuna           *");
                Console.WriteLine("* 4. Azuriranje racuna         *");
                Console.WriteLine("* 5. Povratak na glavni izbornik");
                Console.WriteLine("********************************");
                Console.WriteLine();
                Console.Write("Odaberite opciju: ");
                string odabir = Console.ReadLine();

                switch(odabir)
                {
                    case "1":
                        Narudzbe racun = new Narudzbe();
                        Console.Write("Unesite ID korisnika: ");
                        if (int.TryParse(Console.ReadLine(), out int korisnikId))
                        {
                            racun.KorisnikId = korisnikId;
                        }

                        racun.DatumKreiranja = DateTime.Now;
                        racun.DatumVrijemeDostave = DateTime.Now.AddDays(7);
                        racun.JeDostavljeno = false;

                        DbMethods.DodajNarudzbu(racun);
                        Console.WriteLine("Racun uspjesno dodan!");

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("***** ISPIS RACUNA *****");

                        foreach (Narudzbe n in DbMethods.DohvatiNarudzbe())
                        {
                            Console.WriteLine($"{n.Id}. Korisnik ID: {n.KorisnikId}, Datum kreiranja: {n.DatumKreiranja}, Dostavljeno: {n.JeDostavljeno}");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("***** BRISANJE RACUNA *****");

                        Console.Write("Unesite ID računa za brisanje: ");
                        if (int.TryParse(Console.ReadLine(), out int idZaBrisanje))
                        {
                            DbMethods.ObrisiNarudzbu(idZaBrisanje);
                            Console.WriteLine("Racun uspjesno obrisan!");
                        }
                        else
                        {
                            Console.WriteLine("Neispravan ID!");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("***** AZURIRANJE RACUNA *****");

                        Console.Write("Unesite ID računa za ažuriranje: ");
                        if (int.TryParse(Console.ReadLine(), out int idZaAzuriranje))
                        {
                            Narudzbe racunZaAzuriranje = DbMethods.DohvatiNarudzbu(idZaAzuriranje);
                            if (racunZaAzuriranje != null)
                            {
                                Console.Write($"Unesite novi ID korisnika ({racunZaAzuriranje.KorisnikId}): ");
                                if (int.TryParse(Console.ReadLine(), out int noviKorisnikId))
                                {
                                    racunZaAzuriranje.KorisnikId = noviKorisnikId;
                                }

                                Console.Write($"Je li dostavljeno ({racunZaAzuriranje.JeDostavljeno}): ");
                                if (bool.TryParse(Console.ReadLine(), out bool jeDostavljeno))
                                {
                                    racunZaAzuriranje.JeDostavljeno = jeDostavljeno;
                                }

                                DbMethods.AzurirajNarudzbu(racunZaAzuriranje);
                                Console.WriteLine("Racun uspjesno azuriran!");
                            }
                            else
                            {
                                Console.WriteLine("Racun nije pronadjen!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Neispravan ID!");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;

                    case "5":
                        Program.Izbornik();
                        break;

                    default:
                        Console.WriteLine("Nepostojeca opcija!");
                        Console.ReadKey();
                        ponovi = true;
                        break;
                }
            }
        }

    }
}
