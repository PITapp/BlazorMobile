using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwBenutzerBase")]
  public partial class VwBenutzerBase
  {
    public int BenutzerID
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
    public string Benutzername
    {
      get;
      set;
    }
    public string Kennwort
    {
      get;
      set;
    }
    public string Initialen
    {
      get;
      set;
    }
    public bool? Sperren
    {
      get;
      set;
    }
    public DateTime? Angemeldet
    {
      get;
      set;
    }
    public DateTime? Abgemeldet
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
    public int LetzteKundenID
    {
      get;
      set;
    }
    public int LetzteMitarbeiterID
    {
      get;
      set;
    }
    public int LetzteBaseID
    {
      get;
      set;
    }
    public int LetzteBenutzerID
    {
      get;
      set;
    }
    public string FilterKontakteName
    {
      get;
      set;
    }
    public string FilterKontakteStrasse
    {
      get;
      set;
    }
    public string FilterKontaktePlz
    {
      get;
      set;
    }
    public string FilterKontakteOrt
    {
      get;
      set;
    }
    public string FilterKontakteNotiz
    {
      get;
      set;
    }
    public string FilterKontakteVerlinkt
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
    public string NameGesamt
    {
      get;
      set;
    }
    public string NameKuerzel
    {
      get;
      set;
    }
    public int? AnredeID
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
    public string Webseite
    {
      get;
      set;
    }
    public string BildURL
    {
      get;
      set;
    }
    public string BaseNotiz
    {
      get;
      set;
    }
  }
}
