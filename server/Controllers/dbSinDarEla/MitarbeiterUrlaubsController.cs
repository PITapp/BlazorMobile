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

  [Route("odata/dbSinDarEla/MitarbeiterUrlaubs")]
  public partial class MitarbeiterUrlaubsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaub> GetMitarbeiterUrlaubs()
    {
      var items = this.context.MitarbeiterUrlaubs.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaub>();
      this.OnMitarbeiterUrlaubsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaub> items);

    partial void OnMitarbeiterUrlaubGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterUrlaub> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterUrlaubs(MitarbeiterUrlaubID={MitarbeiterUrlaubID})")]
    public SingleResult<MitarbeiterUrlaub> GetMitarbeiterUrlaub(int key)
    {
        var items = this.context.MitarbeiterUrlaubs.Where(i=>i.MitarbeiterUrlaubID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterUrlaubGet(ref result);

        return result;
    }
    partial void OnMitarbeiterUrlaubDeleted(Models.DbSinDarEla.MitarbeiterUrlaub item);
    partial void OnAfterMitarbeiterUrlaubDeleted(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterUrlaubs(MitarbeiterUrlaubID={MitarbeiterUrlaubID})")]
    public IActionResult DeleteMitarbeiterUrlaub(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterUrlaubs
                .Where(i => i.MitarbeiterUrlaubID == key)
                .Include(i => i.MitarbeiterUrlaubDetails)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubDeleted(item);
            this.context.MitarbeiterUrlaubs.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterUrlaubDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubUpdated(Models.DbSinDarEla.MitarbeiterUrlaub item);
    partial void OnAfterMitarbeiterUrlaubUpdated(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterUrlaubs(MitarbeiterUrlaubID={MitarbeiterUrlaubID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaub(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaub newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubUpdated(newItem);
            this.context.MitarbeiterUrlaubs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            this.OnAfterMitarbeiterUrlaubUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterUrlaubs(MitarbeiterUrlaubID={MitarbeiterUrlaubID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaub(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaub> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterUrlaubUpdated(item);
            this.context.MitarbeiterUrlaubs.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubCreated(Models.DbSinDarEla.MitarbeiterUrlaub item);
    partial void OnAfterMitarbeiterUrlaubCreated(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaub item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubCreated(item);
            this.context.MitarbeiterUrlaubs.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubID;

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");

            this.OnAfterMitarbeiterUrlaubCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
