using System;
using System.Collections.Generic;

namespace DC1.Models;

public partial class Stade
{
    public int IdStade { get; set; }

    public string? NomStade { get; set; }

    public int? CapaciteStade { get; set; }

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
