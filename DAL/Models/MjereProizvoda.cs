using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MjereProizvoda
{
    public short Id { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Proizvodi> Proizvodi { get; set; } = new List<Proizvodi>();
}
