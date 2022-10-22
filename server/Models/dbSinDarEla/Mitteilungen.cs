using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Mitteilungen")]
  public partial class Mitteilungen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitteilungID
    {
      get;
      set;
    }

    public IEnumerable<MitteilungenVerteiler> MitteilungenVerteilers { get; set; }
    public int BaseID
    {
      get;
      set;
    }
    public Base Base { get; set; }
    public int? DokumentID
    {
      get;
      set;
    }
    public Dokumente Dokumente { get; set; }
    public DateTime Am
    {
      get;
      set;
    }
    public string Titel
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
