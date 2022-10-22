using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterVerlaufNormalarbeitszeit")]
  public partial class MitarbeiterVerlaufNormalarbeitszeit
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterVerlaufNormalarbeitszeitID
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
    public double Stunden
    {
      get;
      set;
    }
    public int Wochentage
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
