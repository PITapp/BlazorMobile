using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("InfotexteHTML")]
  public partial class InfotexteHtml
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InfotextID
    {
      get;
      set;
    }
    public string Code
    {
      get;
      set;
    }
    public string Titel
    {
      get;
      set;
    }
    public string Inhalt
    {
      get;
      set;
    }
    public int? Sortierung
    {
      get;
      set;
    }
  }
}
