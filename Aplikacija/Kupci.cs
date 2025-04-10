using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija
{
    class Kupci
    {
        public static void Izbornik()
        {
            bool ponovi = true;
            Console.Clear();
            while (ponovi)
            {
                ponovi = false;
                Console.WriteLine("***** KUPCI *****");
                Console.WriteLine("* 1. Popis      *");
                Console.WriteLine("* 2. Dodavanje  *");
                Console.WriteLine("* 3. Izmjena    *");
                Console.WriteLine("* 4. Brisanje   *");
                Console.WriteLine("* 5. Povratak   *");
                Console.WriteLine("*****************");
                Console.WriteLine();
                Console.Write("Odaberite opciju: ");
                string odabir = Console.ReadLine();


                switch (odabir)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("POPIS KUPACA");
                        foreach (Korisnici k in DbMethods.Dohvatikorisnike())
                        {
                            Console.WriteLine($"{k.Id}. Ime i prezime: {k.Ime} {k.Prezime}, Kontakt telefon: {k.Kontakt} , " +
                                $"Email {k.Email}, Adresa: {k.AdresaDostave}, Napomena: {k.Napomena}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("DODAVANJE KUPCA");
                        Korisnici kupac = new Korisnici();

                        Console.Write("Ime: ");
                        string imeKupca = Console.ReadLine();
                        if(!string.IsNullOrEmpty(imeKupca))
                        {
                            kupac.Ime = imeKupca;
                        }

                        Console.Write("Prezime: ");
                        string prezimeKupca = Console.ReadLine();
                        if(!string.IsNullOrEmpty(prezimeKupca))
                        {
                            kupac.Prezime = prezimeKupca;
                        }

                        Console.Write("Email: ");
                        string emailKupca = Console.ReadLine();
                        if(!string.IsNullOrEmpty(emailKupca))
                        {
                            kupac.Email = emailKupca;
                        }

                        Console.Write("Adresa dostave: ");
                        string adresaDostave = Console.ReadLine();
                        if(!string.IsNullOrEmpty(adresaDostave))
                        {
                            kupac.AdresaDostave = adresaDostave;
                        }

                        Console.Write("Kontakt: ");
                        string kontaktKupca = Console.ReadLine();
                        if(!string.IsNullOrEmpty(kontaktKupca))
                        {
                            kupac.Kontakt = kontaktKupca;
                        }

                        Console.Write("Napomena: ");
                        string napomenaKupca = Console.ReadLine();
                        if(!string.IsNullOrEmpty(napomenaKupca))
                        {
                            kupac.Napomena = napomenaKupca;
                        }

                        DbMethods.Dodajkorisnika(kupac);
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("IZMJENA KUPCA");
                        Console.Write("Unesite id:");

                        Korisnici kupacZaIzmjenu = DbMethods.DohvatiKorisnika(int.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        Console.Write($"Ime ({kupacZaIzmjenu.Ime}): ");
                        string ime = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ime))
                        {
                            kupacZaIzmjenu.Ime = ime;
                        }
                        Console.WriteLine();
                        Console.Write($"Prezime ({kupacZaIzmjenu.Prezime}): ");
                        string prezime = Console.ReadLine();
                        if(!string.IsNullOrEmpty(prezime))
                        {
                            kupacZaIzmjenu.Prezime = prezime;
                        }

                        Console.WriteLine();
                        Console.Write($"Email ({kupacZaIzmjenu.Email}): ");
                        string email = Console.ReadLine();
                        if(!string.IsNullOrEmpty(email))
                        {
                            kupacZaIzmjenu.Email = prezime;
                        }

                        Console.WriteLine();
                        Console.Write($"Adresa dostave ({kupacZaIzmjenu.AdresaDostave}): ");
                        string adresa = Console.ReadLine();
                        if(!string.IsNullOrEmpty(adresa))
                        {
                            kupacZaIzmjenu.AdresaDostave = adresa;
                        }

                        Console.WriteLine();
                        Console.Write($"Kontakt ({kupacZaIzmjenu.Kontakt}): ");
                        string kontakt = Console.ReadLine();
                        if(!string.IsNullOrEmpty(kontakt))
                        {
                            kupacZaIzmjenu.Kontakt = kontakt;
                        }

                        Console.WriteLine();
                        Console.Write($"Napomena ({kupacZaIzmjenu.Napomena}): ");
                        string napomena = Console.ReadLine();
                        if(!string.IsNullOrEmpty(napomena))
                        {
                            kupacZaIzmjenu.Napomena = napomena;
                        }
                        DbMethods.IzmjeniKorisnika(kupacZaIzmjenu);
                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("BRISANJE KUPCA: ");
                        Console.Write("Unesite id: ");
                        Korisnici kupacZaBrisanje = DbMethods.DohvatiKorisnika(int.Parse(Console.ReadLine()));
                        Console.WriteLine();

                        DbMethods.ObrisiKorisnika(kupacZaBrisanje.Id);

                        Console.WriteLine();
                        Console.WriteLine("Pritisnite bilo koju tipku za nastavak....");
                        Console.ReadKey();
                        Izbornik();
                        break;
                    case "5":
                        Program.Izbornik();
                        break;
                }
            }
        }
    }
}
