using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaubDetails")]
  public partial class MitarbeiterUrlaubDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubDetailsID
    {
      get;
      set;
    }
    public int MitarbeiterUrlaubID
    {
      get;
      set;
    }
    public MitarbeiterUrlaub MitarbeiterUrlaub { get; set; }
    public string Art
    {
      get;
      set;
    }
    public DateTime Von
    {
      get;
      set;
    }
    public DateTime Bis
    {
      get;
      set;
    }
    public int Tage
    {
      get;
      set;
    }
    public double StundenDetail
    {
      get;
      set;
    }
    public double StundenNormalarbeitszeit
    {
      get;
      set;
    }
    public int Wochentage
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
