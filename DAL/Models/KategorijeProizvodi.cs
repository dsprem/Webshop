using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class KategorijeProizvodi
{
    public int Id { get; set; }

    public int ProizvodId { get; set; }

    public int KategorijaId { get; set; }

    public virtual Kategorije Kategorija { get; set; } = null!;

    public virtual Proizvodi Proizvod { get; set; } = null!;
}
