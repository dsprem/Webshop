using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Proizvodi
{
    public int Id { get; set; }

    public short MjeraProizvodaId { get; set; }

    public DateTime VrijemeKreiranja { get; set; }

    public string Naziv { get; set; } = null!;

    public decimal Cijena { get; set; }

    public bool Dostupan { get; set; }

    public virtual ICollection<KategorijeProizvodi> KategorijeProizvodi { get; set; } = new List<KategorijeProizvodi>();

    public virtual MjereProizvoda MjeraProizvoda { get; set; } = null!;

    public virtual ICollection<NarudzbeDetalji> NarudzbeDetalji { get; set; } = new List<NarudzbeDetalji>();
}
