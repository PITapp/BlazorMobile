using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("MitarbeiterUrlaub")]
  public partial class MitarbeiterUrlaub
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MitarbeiterUrlaubID
    {
      get;
      set;
    }

    public IEnumerable<MitarbeiterUrlaubDetail> MitarbeiterUrlaubDetails { get; set; }
    public int MitarbeiterFirmaID
    {
      get;
      set;
    }
    public MitarbeiterFirmen MitarbeiterFirmen { get; set; }
    public int Jahr
    {
      get;
      set;
    }
    public int AnspruchJahrTage
    {
      get;
      set;
    }
    public double AnspruchJahrWochen
    {
      get;
      set;
    }
    public double RestVorjahr
    {
      get;
      set;
    }
    public double AnspruchJahr
    {
      get;
      set;
    }
    public double AnspruchGesamt
    {
      get;
      set;
    }
    public double Verbraucht
    {
      get;
      set;
    }
    public double Geplant
    {
      get;
      set;
    }
    public double RestJahr
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
