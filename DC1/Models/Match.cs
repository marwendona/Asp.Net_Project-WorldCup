using System;
using System.Collections.Generic;

namespace DC1.Models;

public partial class Match
{
    public int IdMatch { get; set; }

    public int? ScoreA { get; set; }

    public int? ScoreB { get; set; }

    public int? IdEquipeA { get; set; }

    public int? IdEquipeB { get; set; }

    public int? IdStade { get; set; }

    public int? IdArbitre { get; set; }

    public virtual Arbitre? IdArbitreNavigation { get; set; }

    public virtual Equipe? IdEquipeANavigation { get; set; }

    public virtual Equipe? IdEquipeBNavigation { get; set; }

    public virtual Stade? IdStadeNavigation { get; set; }
}
