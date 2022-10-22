using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Aufgaben")]
  public partial class Aufgaben
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AufgabeID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public int? ZustaendigBaseID
    {
      get;
      set;
    }
    public Base Base1 { get; set; }
    public DateTime Am
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
    public DateTime? FaelligBis
    {
      get;
      set;
    }
    public bool? Erledigt
    {
      get;
      set;
    }
    public DateTime? ErledigtAm
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
