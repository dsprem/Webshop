using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Kategorije
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }

    public virtual ICollection<KategorijeProizvodi> KategorijeProizvodi { get; set; } = new List<KategorijeProizvodi>();
}
