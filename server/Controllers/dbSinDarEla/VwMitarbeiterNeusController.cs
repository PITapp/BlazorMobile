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

  [Route("odata/dbSinDarEla/VwMitarbeiterNeus")]
  public partial class VwMitarbeiterNeusController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeiterNeusController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterNeus
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterNeu> GetVwMitarbeiterNeus()
    {
      var items = this.context.VwMitarbeiterNeus.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterNeu>();
      this.OnVwMitarbeiterNeusRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterNeusRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterNeu> items);

    partial void OnVwMitarbeiterNeuGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiterNeu> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiterNeus(BaseID={BaseID})")]
    public SingleResult<VwMitarbeiterNeu> GetVwMitarbeiterNeu(int key)
    {
        var items = this.context.VwMitarbeiterNeus.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterNeuGet(ref result);

        return result;
    }
  }
}
