using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("KundenLeistungArten")]
  public partial class KundenLeistungArten
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KundenLeistungArtID
    {
      get;
      set;
    }

    public IEnumerable<AbrechnungKundenReststunden> AbrechnungKundenReststundens { get; set; }
    public IEnumerable<Ereignisse> Ereignisses { get; set; }
    public IEnumerable<KundenLeistungen> KundenLeistungens { get; set; }
    public string LeistungArt
    {
      get;
      set;
    }
    public string LeistungSchluessel
    {
      get;
      set;
    }
  }
}
