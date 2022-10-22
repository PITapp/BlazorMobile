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

  [Route("odata/dbSinDarEla/VwMitarbeiters")]
  public partial class VwMitarbeitersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeitersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiter> GetVwMitarbeiters()
    {
      var items = this.context.VwMitarbeiters.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiter>();
      this.OnVwMitarbeitersRead(ref items);

      return items;
    }

    partial void OnVwMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiter> items);

    partial void OnVwMitarbeiterGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiter> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiters(BaseID={BaseID})")]
    public SingleResult<VwMitarbeiter> GetVwMitarbeiter(int key)
    {
        var items = this.context.VwMitarbeiters.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterGet(ref result);

        return result;
    }
  }
}
