using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Narudzbe
{
    public int Id { get; set; }

    public int KorisnikId { get; set; }

    public DateTime DatumKreiranja { get; set; }

    public DateTime DatumVrijemeDostave { get; set; }

    public bool JeDostavljeno { get; set; }

    public virtual Korisnici Korisnik { get; set; } = null!;

    public virtual ICollection<NarudzbeDetalji> NarudzbeDetalji { get; set; } = new List<NarudzbeDetalji>();
}
