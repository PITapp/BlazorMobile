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

  [Route("odata/dbSinDarEla/VwKundenBetreuers")]
  public partial class VwKundenBetreuersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwKundenBetreuersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenBetreuer> GetVwKundenBetreuers()
    {
      var items = this.context.VwKundenBetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenBetreuer>();
      this.OnVwKundenBetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenBetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenBetreuer> items);

    partial void OnVwKundenBetreuerGet(ref SingleResult<Models.DbSinDarEla.VwKundenBetreuer> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwKundenBetreuers(Betreuungsart={Betreuungsart})")]
    public SingleResult<VwKundenBetreuer> GetVwKundenBetreuer(string key)
    {
        var items = this.context.VwKundenBetreuers.AsNoTracking().Where(i=>i.Betreuungsart == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnVwKundenBetreuerGet(ref result);

        return result;
    }
  }
}
