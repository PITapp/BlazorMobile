using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Mitarbeiter")]
  public partial class Mitarbeiter
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterFirmen> MitarbeiterFirmens { get; set; }
    public IEnumerable<MitarbeiterFortbildungen> MitarbeiterFortbildungens { get; set; }
    public IEnumerable<MitarbeiterKundenbudget> MitarbeiterKundenbudgets { get; set; }
    public IEnumerable<MitarbeiterTaetigkeiten> MitarbeiterTaetigkeitens { get; set; }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public int MitarbeiterArtID
    {
      get;
      set;
    }
    public MitarbeiterArten MitarbeiterArten { get; set; }
  }
}
