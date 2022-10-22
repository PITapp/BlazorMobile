using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("AbrechnungKundenReststunden")]
  public partial class AbrechnungKundenReststunden
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AbrechnungKundenReststundenID
    {
      get;
      set;
    }
    public int KundenID
    {
      get;
      set;
    }
    public Kunden Kunden { get; set; }
    public int KundenLeistungArtID
    {
      get;
      set;
    }
    public KundenLeistungArten KundenLeistungArten { get; set; }
    public int AbrechnungBasisID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public int KundenLeistungID
    {
      get;
      set;
    }
    public string LeistungArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
    public int? KundenLeistungenBescheidID
    {
      get;
      set;
    }
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
    public bool? Selbstkostenbefreiung
    {
      get;
      set;
    }
    public int? KundenLeistungenBescheideKontingentID
    {
      get;
      set;
    }
    public DateTime? KontingentVon
    {
      get;
      set;
    }
    public DateTime? KontingentBis
    {
      get;
      set;
    }
    public double? Anspruch
    {
      get;
      set;
    }
    public double? Reststunden
    {
      get;
      set;
    }
    public double? NichtAbgerechnet
    {
      get;
      set;
    }
    public double? Offen
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
