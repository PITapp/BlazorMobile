using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungenBescheideKontingente")]
  public partial class KundenLeistungenBescheideKontingente
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungenBescheideKontingentID
    {
      get;
      set;
    }
    public int KundenLeistungenBescheidID
    {
      get;
      set;
    }
    public KundenLeistungenBescheide KundenLeistungenBescheide { get; set; }
    public DateTime KontingentVon
    {
      get;
      set;
    }
    public DateTime KontingentBis
    {
      get;
      set;
    }
    public double? Anspruch
    {
      get;
      set;
    }
    public double? Verbrauch
    {
      get;
      set;
    }
    public double? Rest
    {
      get;
      set;
    }
  }
}
