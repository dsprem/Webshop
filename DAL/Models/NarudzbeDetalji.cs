using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class NarudzbeDetalji
{
    public int Id { get; set; }

    public int NarudzbaId { get; set; }

    public int ProizvodId { get; set; }

    public decimal Kolicina { get; set; }

    public decimal JedCijena { get; set; }

    public virtual Narudzbe Narudzba { get; set; } = null!;

    public virtual Proizvodi Proizvod { get; set; } = null!;
}
