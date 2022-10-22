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

  [Route("odata/dbSinDarEla/VwBaseOrtes")]
  public partial class VwBaseOrtesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwBaseOrtesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseOrtes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseOrte> GetVwBaseOrtes()
    {
      var items = this.context.VwBaseOrtes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseOrte>();
      this.OnVwBaseOrtesRead(ref items);

      return items;
    }

    partial void OnVwBaseOrtesRead(ref IQueryable<Models.DbSinDarEla.VwBaseOrte> items);

    partial void OnVwBaseOrteGet(ref SingleResult<Models.DbSinDarEla.VwBaseOrte> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwBaseOrtes(Ort={Ort})")]
    public SingleResult<VwBaseOrte> GetVwBaseOrte(string key)
    {
        var items = this.context.VwBaseOrtes.AsNoTracking().Where(i=>i.Ort == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnVwBaseOrteGet(ref result);

        return result;
    }
  }
}
