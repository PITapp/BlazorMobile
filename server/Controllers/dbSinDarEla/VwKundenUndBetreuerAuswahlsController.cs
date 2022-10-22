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

  [Route("odata/dbSinDarEla/VwKundenUndBetreuerAuswahls")]
  public partial class VwKundenUndBetreuerAuswahlsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwKundenUndBetreuerAuswahlsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenUndBetreuerAuswahls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> GetVwKundenUndBetreuerAuswahls()
    {
      var items = this.context.VwKundenUndBetreuerAuswahls.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>();
      this.OnVwKundenUndBetreuerAuswahlsRead(ref items);

      return items;
    }

    partial void OnVwKundenUndBetreuerAuswahlsRead(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> items);

    partial void OnVwKundenUndBetreuerAuswahlGet(ref SingleResult<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwKundenUndBetreuerAuswahls(BaseID={BaseID})")]
    public SingleResult<VwKundenUndBetreuerAuswahl> GetVwKundenUndBetreuerAuswahl(int key)
    {
        var items = this.context.VwKundenUndBetreuerAuswahls.AsNoTracking().Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnVwKundenUndBetreuerAuswahlGet(ref result);

        return result;
    }
  }
}
