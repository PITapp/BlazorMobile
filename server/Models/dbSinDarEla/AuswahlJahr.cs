using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("AuswahlJahr")]
  public partial class AuswahlJahr
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuswahlJahrID
    {
      get;
      set;
    }
    public int Jahr
    {
      get;
      set;
    }
  }
}
