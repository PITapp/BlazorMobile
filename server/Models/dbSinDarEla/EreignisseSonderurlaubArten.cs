using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("EreignisseSonderurlaubArten")]
  public partial class EreignisseSonderurlaubArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EreignisSonderurlaubArtID
    {
      get;
      set;
    }

    public IEnumerable<Ereignisse> Ereignisses { get; set; }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string FreieTage
    {
      get;
      set;
    }
    public string FreieTageZusatz
    {
      get;
      set;
    }
    public int? Sortierung
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
