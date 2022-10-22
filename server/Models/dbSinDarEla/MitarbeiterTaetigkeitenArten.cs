using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterTaetigkeitenArten")]
  public partial class MitarbeiterTaetigkeitenArten
  {
    [Key]
    public int MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }

    public IEnumerable<FirmenMitarbeiterTaetigkeiten> FirmenMitarbeiterTaetigkeitens { get; set; }
    public IEnumerable<MitarbeiterTaetigkeiten> MitarbeiterTaetigkeitens { get; set; }
    public string TaetigkeitArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
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
