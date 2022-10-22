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

  [Route("odata/dbSinDarEla/VwBaseAlles")]
  public partial class VwBaseAllesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwBaseAllesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseAlle> GetVwBaseAlles()
    {
      var items = this.context.VwBaseAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseAlle>();
      this.OnVwBaseAllesRead(ref items);

      return items;
    }

    partial void OnVwBaseAllesRead(ref IQueryable<Models.DbSinDarEla.VwBaseAlle> items);

    partial void OnVwBaseAlleGet(ref SingleResult<Models.DbSinDarEla.VwBaseAlle> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwBaseAlles(Name1={Name1})")]
    public SingleResult<VwBaseAlle> GetVwBaseAlle(string key)
    {
        var items = this.context.VwBaseAlles.AsNoTracking().Where(i=>i.Name1 == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnVwBaseAlleGet(ref result);

        return result;
    }
  }
}
