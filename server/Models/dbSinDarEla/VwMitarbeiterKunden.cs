using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwMitarbeiterKunden")]
  public partial class VwMitarbeiterKunden
  {
    public int MitarbeiterID
    {
      get;
      set;
    }
    [Key]
    public int MitarbeiterBaseID
    {
      get;
      set;
    }
    public int KundenID
    {
      get;
      set;
    }
    public int KundenBaseID
    {
      get;
      set;
    }
    public string MitarbeiterName
    {
      get;
      set;
    }
    public string KundeName
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
    public string Betreuungsart
    {
      get;
      set;
    }
  }
}
