using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("AbrechnungBasis")]
  public partial class AbrechnungBasis
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AbrechnungBasisID
    {
      get;
      set;
    }
    public string Art
    {
      get;
      set;
    }
    public int? Jahr
    {
      get;
      set;
    }
    public int? Monat
    {
      get;
      set;
    }
    public bool? Gesperrt
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
