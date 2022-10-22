using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Firmen")]
  public partial class Firmen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FirmaID
    {
      get;
      set;
    }

    public IEnumerable<FirmenMitarbeiterTaetigkeiten> FirmenMitarbeiterTaetigkeitens { get; set; }
    public IEnumerable<MitarbeiterFirmen> MitarbeiterFirmens { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string Strasse
    {
      get;
      set;
    }
    public string PLZ
    {
      get;
      set;
    }
    public string Ort
    {
      get;
      set;
    }
    public string Telefon
    {
      get;
      set;
    }
    public string EMail
    {
      get;
      set;
    }
    public string UID
    {
      get;
      set;
    }
    public string FirmenbuchNummer
    {
      get;
      set;
    }
    public string Gerichtsstand
    {
      get;
      set;
    }
    public string KontoName
    {
      get;
      set;
    }
    public string KontoNummer
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
