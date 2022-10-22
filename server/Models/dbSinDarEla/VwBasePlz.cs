using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("vwBasePlz")]
  public partial class VwBasePlz
  {
    [Key]
    public string PLZ
    {
      get;
      set;
    }
  }
}
