using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("BaseAnreden")]
  public partial class BaseAnreden
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnredeID
    {
      get;
      set;
    }

    public IEnumerable<Base> Bases { get; set; }
    public string Anrede
    {
      get;
      set;
    }
  }
}
