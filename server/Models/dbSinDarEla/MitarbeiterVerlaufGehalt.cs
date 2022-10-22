using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterVerlaufGehalt")]
  public partial class MitarbeiterVerlaufGehalt
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterVerlaufGehaltID
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
    public DateTime Von
    {
      get;
      set;
    }
    public DateTime? Bis
    {
      get;
      set;
    }
    public int Verwendungsgruppe
    {
      get;
      set;
    }
    public int Gehaltsstufe
    {
      get;
      set;
    }
    public string Info
    {
      get;
      set;
    }
  }
}
