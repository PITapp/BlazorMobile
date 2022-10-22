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

  [Route("odata/dbSinDarEla/VwMitarbeiterKundens")]
  public partial class VwMitarbeiterKundensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public VwMitarbeiterKundensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKunden> GetVwMitarbeiterKundens()
    {
      var items = this.context.VwMitarbeiterKundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKunden>();
      this.OnVwMitarbeiterKundensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKunden> items);

    partial void OnVwMitarbeiterKundenGet(ref SingleResult<Models.DbSinDarEla.VwMitarbeiterKunden> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/VwMitarbeiterKundens(MitarbeiterBaseID={MitarbeiterBaseID})")]
    public SingleResult<VwMitarbeiterKunden> GetVwMitarbeiterKunden(int key)
    {
        var items = this.context.VwMitarbeiterKundens.AsNoTracking().Where(i=>i.MitarbeiterBaseID == key);
        var result = SingleResult.Create(items);

        OnVwMitarbeiterKundenGet(ref result);

        return result;
    }
  }
}
