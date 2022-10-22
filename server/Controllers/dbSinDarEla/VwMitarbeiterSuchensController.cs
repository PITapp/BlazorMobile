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

  [Route("odata/dbSinDarEla/VwMitarbeiterSuchens")]
  public partial class VwMitarbeiterSuchensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeiterSuchensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterSuchens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterSuchen> GetVwMitarbeiterSuchens()
    {
      var items = this.context.VwMitarbeiterSuchens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterSuchen>();
      this.OnVwMitarbeiterSuchensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterSuchensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterSuchen> items);

    partial void OnVwMitarbeiterSuchenGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiterSuchen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiterSuchens(BaseID={BaseID})")]
    public SingleResult<VwMitarbeiterSuchen> GetVwMitarbeiterSuchen(int key)
    {
        var items = this.context.VwMitarbeiterSuchens.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterSuchenGet(ref result);

        return result;
    }
  }
}
