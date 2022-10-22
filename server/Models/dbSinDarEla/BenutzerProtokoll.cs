using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("BenutzerProtokoll")]
  public partial class BenutzerProtokoll
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BenutzerProtokollID
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
    public string Art
    {
      get;
      set;
    }
    public DateTime TimeStamp
    {
      get;
      set;
    }
  }
}
