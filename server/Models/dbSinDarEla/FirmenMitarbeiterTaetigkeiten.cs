using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("FirmenMitarbeiterTaetigkeiten")]
  public partial class FirmenMitarbeiterTaetigkeiten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FirmenMitarbeiterTaetigkeitenID
    {
      get;
      set;
    }
    public int FirmaID
    {
      get;
      set;
    }
    public Firmen Firmen { get; set; }
    public int MitarbeiterTaetigkeitenArtID
    {
      get;
      set;
    }
    public MitarbeiterTaetigkeitenArten MitarbeiterTaetigkeitenArten { get; set; }
  }
}
