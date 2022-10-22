using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("BaseKontakte")]
  public partial class BaseKontakte
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KontaktID
    {
      get;
      set;
    }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public string NameKontakt
    {
      get;
      set;
    }
    public string Handy
    {
      get;
      set;
    }
    public string Telefon
    {
      get;
      set;
    }
    public string EMail
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
