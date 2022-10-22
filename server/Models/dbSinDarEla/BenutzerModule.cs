using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("BenutzerModule")]
  public partial class BenutzerModule
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BenutzerModuleID
    {
      get;
      set;
    }
    public int BenutzerID
    {
      get;
      set;
    }
    public Benutzer Benutzer { get; set; }
    public int ModulID
    {
      get;
      set;
    }
    public Module Module { get; set; }
    public bool? ErlaubtNeu
    {
      get;
      set;
    }
    public bool? ErlaubtAendern
    {
      get;
      set;
    }
    public bool? ErlaubtLoeschen
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
