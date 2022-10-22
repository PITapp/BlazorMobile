using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwMitarbeiterTaetigkeiten")]
  public partial class VwMitarbeiterTaetigkeiten
  {
    public int MitarbeiterID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public int MitarbeiterArtID
    {
      get;
      set;
    }
    public int MitarbeiterTaetigkeitenID
    {
      get;
      set;
    }
    public string MitarbeiterName
    {
      get;
      set;
    }
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
