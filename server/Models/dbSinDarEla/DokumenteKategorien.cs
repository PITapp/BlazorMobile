using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("DokumenteKategorien")]
  public partial class DokumenteKategorien
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DokumenteKategorieID
    {
      get;
      set;
    }

    public IEnumerable<Dokumente> Dokumentes { get; set; }
    public string Titel
    {
      get;
      set;
    }
  }
}
