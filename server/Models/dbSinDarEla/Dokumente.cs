using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("Dokumente")]
  public partial class Dokumente
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DokumentID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterFortbildungen> MitarbeiterFortbildungens { get; set; }
    public IEnumerable<Mitteilungen> Mitteilungens { get; set; }
    public int DokumenteKategorieID
    {
      get;
      set;
    }
    public DokumenteKategorien DokumenteKategorien { get; set; }
    public int? LinkID
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
    public string DokumentURL
    {
      get;
      set;
    }
    public string DokumentName
    {
      get;
      set;
    }
    public string DokumentNameUrsprung
    {
      get;
      set;
    }
    public string DokumentTyp
    {
      get;
      set;
    }
    public string DokumentErstelltVon
    {
      get;
      set;
    }
    public DateTime DokumentErstelltAm
    {
      get;
      set;
    }
  }
}
