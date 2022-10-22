using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Benutzer")]
  public partial class Benutzer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BenutzerID
    {
      get;
      set;
    }

    public IEnumerable<BenutzerModule> BenutzerModules { get; set; }
    public IEnumerable<BenutzerProtokoll> BenutzerProtokolls { get; set; }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public string Benutzername
    {
      get;
      set;
    }
    public string BenutzerIDCode
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
  }
}
