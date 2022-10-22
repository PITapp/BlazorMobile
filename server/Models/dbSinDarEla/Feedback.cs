using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Feedback")]
  public partial class Feedback
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackID
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
    public string Modul
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
  }
}
