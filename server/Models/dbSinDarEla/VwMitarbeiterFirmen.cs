using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwMitarbeiterFirmen")]
  public partial class VwMitarbeiterFirmen
  {
    public int MitarbeiterID
    {
      get;
      set;
    }
    [Key]
    public int BaseID
    {
      get;
      set;
    }
    public int FirmaID
    {
      get;
      set;
    }
    public string FirmaName
    {
      get;
      set;
    }
    public string MitarbeiterName
    {
      get;
      set;
    }
    public string Position
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public DateTime? ArbeitsrechtEintritt
    {
      get;
      set;
    }
    public DateTime? ArbeitsrechtAustritt
    {
      get;
      set;
    }
    public DateTime? LetzterEintritt
    {
      get;
      set;
    }
    public DateTime? LetzterAustritt
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
  }
}
