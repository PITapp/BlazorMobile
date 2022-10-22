using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Ereignisse")]
  public partial class Ereignisse
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EreignisID
    {
      get;
      set;
    }

    public IEnumerable<EreignisseTeilnehmer> EreignisseTeilnehmers { get; set; }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public string EreignisArtCode
    {
      get;
      set;
    }
    public EreignisseArten EreignisseArten { get; set; }
    public int? EreignisSonderurlaubArtID
    {
      get;
      set;
    }
    public EreignisseSonderurlaubArten EreignisseSonderurlaubArten { get; set; }
    public int? KundenID
    {
      get;
      set;
    }
    public Kunden Kunden { get; set; }
    public int? KundenLeistungArtID
    {
      get;
      set;
    }
    public KundenLeistungArten KundenLeistungArten { get; set; }
    public DateTime Start
    {
      get;
      set;
    }
    public DateTime Ende
    {
      get;
      set;
    }
    public int? GanzerTag
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public DateTime? BeantragtAm
    {
      get;
      set;
    }
    public int? BearbeiterBaseID
    {
      get;
      set;
    }
    public DateTime? GenehmigtAm
    {
      get;
      set;
    }
    public DateTime? AbgelehntAm
    {
      get;
      set;
    }
    public string Begruendung
    {
      get;
      set;
    }
    public string StatusAntrag
    {
      get;
      set;
    }
    public string Verwendung
    {
      get;
      set;
    }
    public int? Gesperrt
    {
      get;
      set;
    }
    public double? Wert01
    {
      get;
      set;
    }
    public string Bemerkungen
    {
      get;
      set;
    }
    public int? GefuehlSituation01
    {
      get;
      set;
    }
    public int? GefuehlSituation02
    {
      get;
      set;
    }
    public int? GefuehlSituation03
    {
      get;
      set;
    }
    public int? GefuehlSituation04
    {
      get;
      set;
    }
    public int? GefuehlSituation05
    {
      get;
      set;
    }
    public int? GefuehlSituation06
    {
      get;
      set;
    }
    public int? KundenFahrtMinuten
    {
      get;
      set;
    }
    public int? KundenFahrtKM
    {
      get;
      set;
    }
    public int? BetreuerAnAbReiseMinuten
    {
      get;
      set;
    }
    public int? BetreuerAnAbReiseKM
    {
      get;
      set;
    }
  }
}
