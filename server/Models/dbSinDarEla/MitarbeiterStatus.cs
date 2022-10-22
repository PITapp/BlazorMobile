using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterStatus")]
  public partial class MitarbeiterStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterStatusID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterFirmen> MitarbeiterFirmens { get; set; }
    public string Status
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
