using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Debugg")]
  public partial class Debugg
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DebuggID
    {
      get;
      set;
    }
    public string Variable
    {
      get;
      set;
    }
    public string VariableWert
    {
      get;
      set;
    }
    public int? Sortierung1
    {
      get;
      set;
    }
    public int? Sortierung2
    {
      get;
      set;
    }
  }
}
