using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Kunden")]
  public partial class Kunden
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenID
    {
      get;
      set;
    }

    public IEnumerable<AbrechnungKundenReststunden> AbrechnungKundenReststundens { get; set; }
    public IEnumerable<Ereignisse> Ereignisses { get; set; }
    public IEnumerable<KundenKontakte> KundenKontaktes { get; set; }
    public IEnumerable<KundenLeistungen> KundenLeistungens { get; set; }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public int KundenStatusID
    {
      get;
      set;
    }
    public KundenStatus KundenStatus { get; set; }
    public DateTime Betreuungsbeginn
    {
      get;
      set;
    }
    public string Vorbemerkungen
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
