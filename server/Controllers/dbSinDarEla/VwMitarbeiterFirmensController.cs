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

  [Route("odata/dbSinDarEla/VwMitarbeiterFirmens")]
  public partial class VwMitarbeiterFirmensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeiterFirmensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFirmens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFirmen> GetVwMitarbeiterFirmens()
    {
      var items = this.context.VwMitarbeiterFirmens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFirmen>();
      this.OnVwMitarbeiterFirmensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFirmensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFirmen> items);

    partial void OnVwMitarbeiterFirmenGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiterFirmen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiterFirmens(BaseID={BaseID})")]
    public SingleResult<VwMitarbeiterFirmen> GetVwMitarbeiterFirmen(int key)
    {
        var items = this.context.VwMitarbeiterFirmens.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterFirmenGet(ref result);

        return result;
    }
  }
}
