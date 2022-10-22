using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungen")]
  public partial class KundenLeistungen
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungID
    {
      get;
      set;
    }

    public IEnumerable<KundenLeistungenBescheide> KundenLeistungenBescheides { get; set; }
    public IEnumerable<KundenLeistungenBetreuer> KundenLeistungenBetreuers { get; set; }
    public int KundenID
    {
      get;
      set;
    }
    public Kunden Kunden { get; set; }
    public int KundenLeistungArtID
    {
      get;
      set;
    }
    public KundenLeistungArten KundenLeistungArten { get; set; }
  }
}
