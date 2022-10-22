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

  [Route("odata/dbSinDarEla/VwBasePlzs")]
  public partial class VwBasePlzsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwBasePlzsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBasePlzs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBasePlz> GetVwBasePlzs()
    {
      var items = this.context.VwBasePlzs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBasePlz>();
      this.OnVwBasePlzsRead(ref items);

      return items;
    }

    partial void OnVwBasePlzsRead(ref IQueryable<Models.DbSinDarEla.VwBasePlz> items);

    partial void OnVwBasePlzGet(ref SingleResult<Models.DbSinDarEla.VwBasePlz> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwBasePlzs(PLZ={PLZ})")]
    public SingleResult<VwBasePlz> GetVwBasePlz(string key)
    {
        var items = this.context.VwBasePlzs.AsNoTracking().Where(i=>i.PLZ == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnVwBasePlzGet(ref result);

        return result;
    }
  }
}
