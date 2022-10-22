using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterVerlaufDienstzeitenArten")]
  public partial class MitarbeiterVerlaufDienstzeitenArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterVerlaufDienstzeitenArtID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterVerlaufDienstzeiten> MitarbeiterVerlaufDienstzeitens { get; set; }
    public string Status
    {
      get;
      set;
    }
    public bool? DienstzeitRechnen
    {
      get;
      set;
    }
    public string DienstzeitGruppe
    {
      get;
      set;
    }
    public int? Referenz_MitarbeiterStatusID
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
