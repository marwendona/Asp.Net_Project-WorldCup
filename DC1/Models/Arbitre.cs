using System;
using System.Collections.Generic;

namespace DC1.Models;

public partial class Arbitre
{
    public int IdArbitre { get; set; }

    public string? NomArbitre { get; set; }

    public string? NationaliteArbitre { get; set; }

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
