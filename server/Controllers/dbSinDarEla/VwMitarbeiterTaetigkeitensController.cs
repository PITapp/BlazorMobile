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

  [Route("odata/dbSinDarEla/VwMitarbeiterTaetigkeitens")]
  public partial class VwMitarbeiterTaetigkeitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeiterTaetigkeitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTaetigkeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> GetVwMitarbeiterTaetigkeitens()
    {
      var items = this.context.VwMitarbeiterTaetigkeitens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>();
      this.OnVwMitarbeiterTaetigkeitensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTaetigkeitensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> items);

    partial void OnVwMitarbeiterTaetigkeitenGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiterTaetigkeitens(BaseID={BaseID})")]
    public SingleResult<VwMitarbeiterTaetigkeiten> GetVwMitarbeiterTaetigkeiten(int key)
    {
        var items = this.context.VwMitarbeiterTaetigkeitens.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterTaetigkeitenGet(ref result);

        return result;
    }
  }
}
