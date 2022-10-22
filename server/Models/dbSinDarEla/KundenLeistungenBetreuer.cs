using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungenBetreuer")]
  public partial class KundenLeistungenBetreuer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungenBetreuerID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public int KundenLeistungenBetreuerArtID
    {
      get;
      set;
    }
    public KundenLeistungenBetreuerArten KundenLeistungenBetreuerArten { get; set; }
    public int KundenLeistungID
    {
      get;
      set;
    }
    public KundenLeistungen KundenLeistungen { get; set; }
    public DateTime? BetreuungVon
    {
      get;
      set;
    }
    public DateTime? BetreuungBis
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
