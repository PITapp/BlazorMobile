using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaubKumuliertDienstzeiten")]
  public partial class MitarbeiterUrlaubKumuliertDienstzeiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubKumuliertDienstzeitenID
    {
      get;
      set;
    }
    public int MitarbeiterFirmaID
    {
      get;
      set;
    }
    public MitarbeiterFirmen MitarbeiterFirmen { get; set; }
    public int Sortierung
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public string DienstzeitCode
    {
      get;
      set;
    }
    public string DienstzeitAnrechnungInfo
    {
      get;
      set;
    }
    public double? DienstzeitBerechnet
    {
      get;
      set;
    }
    public double? DienstzeitAnrechnung
    {
      get;
      set;
    }
  }
}
