using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("RegelnAbwesenheiten")]
  public partial class RegelnAbwesenheiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegelnAbwesenheitenID
    {
      get;
      set;
    }
    public string RegelBezeichnung
    {
      get;
      set;
    }
    public Int16 RegelWert
    {
      get;
      set;
    }
    public string RegelInfo
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
  }
}
