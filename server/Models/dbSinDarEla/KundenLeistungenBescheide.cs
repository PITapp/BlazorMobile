using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungenBescheide")]
  public partial class KundenLeistungenBescheide
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungenBescheidID
    {
      get;
      set;
    }

    public IEnumerable<KundenLeistungenBescheideKontingente> KundenLeistungenBescheideKontingentes { get; set; }
    public int? KundenKontaktID
    {
      get;
      set;
    }
    public KundenKontakte KundenKontakte { get; set; }
    public int KundenLeistungID
    {
      get;
      set;
    }
    public KundenLeistungen KundenLeistungen { get; set; }
    public string StatusCode
    {
      get;
      set;
    }
    public KundenLeistungenBescheideStatus KundenLeistungenBescheideStatus { get; set; }
    public DateTime? Von
    {
      get;
      set;
    }
    public DateTime? Bis
    {
      get;
      set;
    }
    public int? Stunden
    {
      get;
      set;
    }
    public string StundenArt
    {
      get;
      set;
    }
    public string Geschaeftszahl
    {
      get;
      set;
    }
    public bool? Selbstkostenbefreiung
    {
      get;
      set;
    }
    public DateTime? BeantragtAm
    {
      get;
      set;
    }
    public bool? Ergaenzungsbescheid
    {
      get;
      set;
    }
    public string ErgaenzungsbescheidInfo
    {
      get;
      set;
    }
    public DateTime? Ablaufdatum
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
