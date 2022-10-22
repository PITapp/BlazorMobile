using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Notizen")]
  public partial class Notizen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NotizID
    {
      get;
      set;
    }
    public string Modul
    {
      get;
      set;
    }
    public int LinkID
    {
      get;
      set;
    }
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
    public string Notiz
    {
      get;
      set;
    }
  }
}
