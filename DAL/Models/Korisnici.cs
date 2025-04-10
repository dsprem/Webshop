using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Korisnici
{
    public int Id { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AdresaDostave { get; set; } = null!;

    public string Kontakt { get; set; } = null!;

    public string? Napomena { get; set; }

    public virtual ICollection<Narudzbe> Narudzbe { get; set; } = new List<Narudzbe>();
}
