using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenStatus")]
  public partial class KundenStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenStatusID
    {
      get;
      set;
    }

    public IEnumerable<Kunden> Kundens { get; set; }
    public string Status
    {
      get;
      set;
    }
  }
}
