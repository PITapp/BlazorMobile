using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("EreignisseTeilnehmerStatus")]
  public partial class EreignisseTeilnehmerStatus
  {
    [Key]
    public string StatusCode
    {
      get;
      set;
    }

    public IEnumerable<EreignisseTeilnehmer> EreignisseTeilnehmers { get; set; }
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
    public string VerwendenFuer
    {
      get;
      set;
    }
  }
}
