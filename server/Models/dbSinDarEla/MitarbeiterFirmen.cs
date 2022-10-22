using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterFirmen")]
  public partial class MitarbeiterFirmen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterFirmaID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterUrlaub> MitarbeiterUrlaubs { get; set; }
    public IEnumerable<MitarbeiterUrlaubKumuliertAnspruch> MitarbeiterUrlaubKumuliertAnspruches { get; set; }
    public IEnumerable<MitarbeiterUrlaubKumuliertDienstzeiten> MitarbeiterUrlaubKumuliertDienstzeitens { get; set; }
    public IEnumerable<MitarbeiterVerlaufDienstzeiten> MitarbeiterVerlaufDienstzeitens { get; set; }
    public IEnumerable<MitarbeiterVerlaufGehalt> MitarbeiterVerlaufGehalts { get; set; }
    public IEnumerable<MitarbeiterVerlaufNormalarbeitszeit> MitarbeiterVerlaufNormalarbeitszeits { get; set; }
    public int FirmaID
    {
      get;
      set;
    }
    public Firmen Firmen { get; set; }
    public int MitarbeiterID
    {
      get;
      set;
    }
    public Mitarbeiter Mitarbeiter { get; set; }
    public int MitarbeiterStatusID
    {
      get;
      set;
    }
    public MitarbeiterStatus MitarbeiterStatus { get; set; }
    public DateTime? ArbeitsrechtEintritt
    {
      get;
      set;
    }
    public DateTime? ArbeitsrechtAustritt
    {
      get;
      set;
    }
    public DateTime? LetzterEintritt
    {
      get;
      set;
    }
    public DateTime? LetzterAustritt
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
  }
}
