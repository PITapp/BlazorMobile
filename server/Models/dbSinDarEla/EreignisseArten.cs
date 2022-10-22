using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("EreignisseArten")]
  public partial class EreignisseArten
  {
    [Key]
    public string EreignisArtCode
    {
      get;
      set;
    }

    public IEnumerable<Ereignisse> Ereignisses { get; set; }
    public string Gruppe
    {
      get;
      set;
    }
    public string Ebene
    {
      get;
      set;
    }
    public string Bezeichnung
    {
      get;
      set;
    }
    public string Kurzzeichen
    {
      get;
      set;
    }
    public bool TerminGanzerTag
    {
      get;
      set;
    }
    public bool Beantragungspflicht
    {
      get;
      set;
    }
    public bool Begruendungspflicht
    {
      get;
      set;
    }
    public bool TeilnehmerErfassen
    {
      get;
      set;
    }
    public bool KundeErfassen
    {
      get;
      set;
    }
    public string FarbeName
    {
      get;
      set;
    }
    public string FarbeHintergrund
    {
      get;
      set;
    }
    public string FarbeText
    {
      get;
      set;
    }
    public string FarbeName2
    {
      get;
      set;
    }
    public string FarbeHintergrund2
    {
      get;
      set;
    }
    public string FarbeText2
    {
      get;
      set;
    }
    public string VerwendenFuer
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
    public bool? TermineDienstplan
    {
      get;
      set;
    }
    public bool? TermineManagement
    {
      get;
      set;
    }
    public int? SortierungTermineDienstplan
    {
      get;
      set;
    }
    public int? SortierungTermineManagement
    {
      get;
      set;
    }
  }
}
