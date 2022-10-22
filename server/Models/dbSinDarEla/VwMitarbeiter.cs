using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwMitarbeiter")]
  public partial class VwMitarbeiter
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
    public int MitarbeiterArtID
    {
      get;
      set;
    }
    public string NameGesamt
    {
      get;
      set;
    }
    public string MitarbeiterArt
    {
      get;
      set;
    }
    public string Anrede
    {
      get;
      set;
    }
    public string Name1
    {
      get;
      set;
    }
    public string Name2
    {
      get;
      set;
    }
    public string NameKuerzel
    {
      get;
      set;
    }
    public string TitelVorne
    {
      get;
      set;
    }
    public string TitelHinten
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
    public DateTime? Geburtsdatum
    {
      get;
      set;
    }
    public string Versicherungsnummer
    {
      get;
      set;
    }
    public string Staatsangehoerigkeit
    {
      get;
      set;
    }
    public string Telefon1
    {
      get;
      set;
    }
    public string Telefon2
    {
      get;
      set;
    }
    public string EMail1
    {
      get;
      set;
    }
    public string EMail2
    {
      get;
      set;
    }
    public string Notiz
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
    public string KontoInfo
    {
      get;
      set;
    }
    public string Notfallkontakt
    {
      get;
      set;
    }
    public string NotfallkontaktTelefon
    {
      get;
      set;
    }
  }
}
