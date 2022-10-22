using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Protokoll")]
  public partial class Protokoll
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProtokollID
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
    public DateTime ErstelltAm
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public string Bereich
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
    public int? ManagementZeigen
    {
      get;
      set;
    }
    public int? LinkID
    {
      get;
      set;
    }
    public bool? Gelesen
    {
      get;
      set;
    }
    public DateTime? GelesenAm
    {
      get;
      set;
    }
  }
}
