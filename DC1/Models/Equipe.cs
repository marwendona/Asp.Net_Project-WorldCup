using System;
using System.Collections.Generic;

namespace DC1.Models;

public partial class Equipe
{
    public int IdEquipe { get; set; }

    public string? NomEquipe { get; set; }

    public string? Groupe { get; set; }

    public virtual ICollection<Match> MatchIdEquipeANavigations { get; } = new List<Match>();

    public virtual ICollection<Match> MatchIdEquipeBNavigations { get; } = new List<Match>();
}
