using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Base")]
  public partial class Base
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BaseID
    {
      get;
      set;
    }

    public IEnumerable<Aufgaben> Aufgabens { get; set; }
    public IEnumerable<Aufgaben> Aufgabens1 { get; set; }
    public IEnumerable<BaseKontakte> BaseKontaktes { get; set; }
    public IEnumerable<Benutzer> Benutzers { get; set; }
    public IEnumerable<Ereignisse> Ereignisses { get; set; }
    public IEnumerable<EreignisseTeilnehmer> EreignisseTeilnehmers { get; set; }
    public IEnumerable<Feedback> Feedbacks { get; set; }
    public IEnumerable<Kunden> Kundens { get; set; }
    public IEnumerable<KundenLeistungenBetreuer> KundenLeistungenBetreuers { get; set; }
    public IEnumerable<Mitarbeiter> Mitarbeiters { get; set; }
    public IEnumerable<Mitteilungen> Mitteilungens { get; set; }
    public IEnumerable<MitteilungenVerteiler> MitteilungenVerteilers { get; set; }
    public IEnumerable<Protokoll> Protokolls { get; set; }
    public int? AnredeID
    {
      get;
      set;
    }
    public BaseAnreden BaseAnreden { get; set; }
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
    public string InfoMitarbeiter
    {
      get;
      set;
    }
  }
}
