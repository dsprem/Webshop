using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DbMethods
    {
        #region ProizvodiMethods
        public static List<Proizvodi> DohvatiProizvode()
        {
            List<Proizvodi> proizvodi = new List<Proizvodi>();
            using (WebShopContext context = new WebShopContext())
            {
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                proizvodi = context.Proizvodi.Include(x => x.MjeraProizvoda).ToList();
            }
            return proizvodi;
        }

        public static void DodajProizvod(Proizvodi noviProizvod)
        {
            try
            {
                using (WebShopContext context = new WebShopContext())
                {
                    Console.WriteLine();
                    Console.WriteLine("Molimo pricekajte....");
                    Console.WriteLine();
                    context.Proizvodi.Add(noviProizvod);
                    context.SaveChanges();
                }
                Console.WriteLine("Proizvod je uspjesno dodan!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Dogodila se greska! Detalji: " + e.Message);
            }
        }
        public static Proizvodi DohvatiProizvod(int id)
        {
            using (WebShopContext context = new WebShopContext())
            {
                Proizvodi proizvod = context.Proizvodi.FirstOrDefault(x => x.Id == id);
                if (proizvod != default)
                {
                    return proizvod;
                }
            }
            return null;
        }
        public static void IzmjenaProizvoda(Proizvodi proizvod)
        {
            using (WebShopContext context = new WebShopContext())
            {
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                Proizvodi proizvodZaIzmjenu = context.Proizvodi.FirstOrDefault(x => x.Id == proizvod.Id);
                if (proizvod != default)
                {
                    proizvodZaIzmjenu.Naziv = proizvod.Naziv;
                    proizvodZaIzmjenu.MjeraProizvoda = proizvod.MjeraProizvoda;
                    proizvodZaIzmjenu.Cijena = proizvod.Cijena;
                    proizvodZaIzmjenu.Dostupan = proizvod.Dostupan;
                    proizvodZaIzmjenu.VrijemeKreiranja = proizvod.VrijemeKreiranja;
                    context.SaveChanges();

                }
                Console.WriteLine("Proizvod je uspjesno izmjenjen!");
            }
        }
        public static void ObrisiProizvod(int id)
        {
            using (WebShopContext context = new WebShopContext())
            {
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                Proizvodi proizvodZaBrisanje = context.Proizvodi.Include(x => x.MjeraProizvoda).FirstOrDefault(x => x.Id == id);
                if (proizvodZaBrisanje != default)
                {
                    context.Remove(proizvodZaBrisanje);
                    context.SaveChanges();
                }
            }
        }
        #endregion
        #region KornisniciMethods
        public static List<Korisnici> Dohvatikorisnike()
        {
            List<Korisnici> korisnici = new List<Korisnici>();
            using (WebShopContext context = new WebShopContext())
            {
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                korisnici = context.Korisnici.ToList();
            }
            return korisnici;
        }
        public static void Dodajkorisnika(Korisnici noviKorisnik)
        {
            using (WebShopContext context = new WebShopContext())
            {
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                context.Korisnici.Add(noviKorisnik);
                context.SaveChanges();
            }
            Console.WriteLine("korisnik je uspjesno dodan. ");
        }
        public static Korisnici DohvatiKorisnika(int id)
        {
            using (WebShopContext context = new WebShopContext())
            {
                Korisnici korisnik = context.Korisnici.FirstOrDefault(x => x.Id == id);
                if (korisnik != default)
                {
                    return korisnik;
                }
            }
            return null;
        }

        public static void IzmjeniKorisnika(Korisnici korisnik)
        {
            using (WebShopContext context = new WebShopContext())
            { 
                Console.WriteLine();
                Console.WriteLine("Molimo pricekajte....");
                Console.WriteLine();
                Korisnici korisnikZaIzmjenu = context.Korisnici.FirstOrDefault(x => x.Id == korisnik.Id);
                if (korisnikZaIzmjenu != default)
                {
                    korisnikZaIzmjenu.Ime = korisnik.Ime;
                    korisnikZaIzmjenu.Prezime = korisnik.Prezime;
                    korisnikZaIzmjenu.Email = korisnik.Email;
                    korisnikZaIzmjenu.AdresaDostave = korisnik.AdresaDostave;
                    korisnikZaIzmjenu.Kontakt = korisnik.Kontakt;
                    korisnikZaIzmjenu.Napomena = korisnik.Napomena;
                    context.SaveChanges();
                }

            }
            Console.WriteLine("Korisnik je uspjesno izmjenjen...");
        }
        public static void ObrisiKorisnika(int id)
        {
            using (WebShopContext context = new WebShopContext())
            { 
                Console.WriteLine();
            Console.WriteLine("Molimo pricekajte....");
            Console.WriteLine();
                Korisnici korisnikZaBrisanje = context.Korisnici.FirstOrDefault(x => x.Id == id);
                if(korisnikZaBrisanje != default)
                {
                    context.Remove(korisnikZaBrisanje);
                    context.SaveChanges();
                }
                
            }
            Console.WriteLine("Korisnik je uspjesno obrisan.");
        }
        #endregion
        #region BlagajnaMethods
        public static void DodajNarudzbu(Narudzbe narudzba)
        {
            using (WebShopContext context = new WebShopContext())
            {
                context.Narudzbe.Add(narudzba);
                context.SaveChanges();
            }
        }
        public static List<Narudzbe> DohvatiNarudzbe()
        {
            using (WebShopContext context = new WebShopContext())
            {
                return context.Narudzbe.ToList();
            }
        }
        public static void ObrisiNarudzbu(int id)
        {
            using (WebShopContext context = new WebShopContext())
            {
                var narudzba = context.Narudzbe.Find(id);
                if (narudzba != null)
                {
                    context.Narudzbe.Remove(narudzba);
                    context.SaveChanges();
                }
            }
        }
        public static void AzurirajNarudzbu(Narudzbe narudzba)
        {
            using (WebShopContext context = new WebShopContext())
            {
                context.Narudzbe.Update(narudzba);
                context.SaveChanges();
            }
        }
        public static Narudzbe DohvatiNarudzbu(int id)
        {
            using (WebShopContext context = new WebShopContext())
            {
                return context.Narudzbe.Find(id);
            }
        }
        #endregion
    }

}
