using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarElaMobile.Models.DbSinDarEla
{
  [Table("DeviceCodes")]
  public partial class DeviceCode
  {
    [Key]
    public string UserCode
    {
      get;
      set;
    }

    [Column("DeviceCode")]
    public string DeviceCode1
    {
      get;
      set;
    }
    public string SubjectId
    {
      get;
      set;
    }
    public string SessionId
    {
      get;
      set;
    }
    public string ClientId
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public DateTime CreationTime
    {
      get;
      set;
    }
    public DateTime Expiration
    {
      get;
      set;
    }
    public string Data
    {
      get;
      set;
    }
  }
}
