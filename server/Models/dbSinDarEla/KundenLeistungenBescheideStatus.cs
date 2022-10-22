using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungenBescheideStatus")]
  public partial class KundenLeistungenBescheideStatus
  {
    [Key]
    public string StatusCode
    {
      get;
      set;
    }

    public IEnumerable<KundenLeistungenBescheide> KundenLeistungenBescheides { get; set; }
    public string Bezeichnung
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
