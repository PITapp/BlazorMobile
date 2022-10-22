using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace SinDarElaMobile.Controllers.DbSinDarEla
{
  using Models;
  using Data;
  using Models.DbSinDarEla;

  [Route("odata/dbSinDarEla/VwBaseKontaktes")]
  public partial class VwBaseKontaktesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwBaseKontaktesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseKontakte> GetVwBaseKontaktes()
    {
      var items = this.context.VwBaseKontaktes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseKontakte>();
      this.OnVwBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnVwBaseKontaktesRead(ref IQueryable<Models.DbSinDarEla.VwBaseKontakte> items);

    partial void OnVwBaseKontakteGet(ref SingleResult<Models.DbSinDarEla.VwBaseKontakte> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwBaseKontaktes(Name1={Name1})")]
    public SingleResult<VwBaseKontakte> GetVwBaseKontakte(string key)
    {
        var items = this.context.VwBaseKontaktes.AsNoTracking().Where(i=>i.Name1 == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnVwBaseKontakteGet(ref result);

        return result;
    }
  }
}
