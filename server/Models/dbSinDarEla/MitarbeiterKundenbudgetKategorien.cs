using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterKundenbudgetKategorien")]
  public partial class MitarbeiterKundenbudgetKategorien
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenbudgetKategorieID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterKundenbudget> MitarbeiterKundenbudgets { get; set; }
    public string Titel
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
