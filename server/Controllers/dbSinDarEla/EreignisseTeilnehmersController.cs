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

  [Route("odata/dbSinDarEla/EreignisseTeilnehmers")]
  public partial class EreignisseTeilnehmersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public EreignisseTeilnehmersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseTeilnehmers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseTeilnehmer> GetEreignisseTeilnehmers()
    {
      var items = this.context.EreignisseTeilnehmers.AsQueryable<Models.DbSinDarEla.EreignisseTeilnehmer>();
      this.OnEreignisseTeilnehmersRead(ref items);

      return items;
    }

    partial void OnEreignisseTeilnehmersRead(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmer> items);

    partial void OnEreignisseTeilnehmerGet(ref SingleResult<Models.DbSinDarEla.EreignisseTeilnehmer> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/EreignisseTeilnehmers(EreignisseTeilnehmerID={EreignisseTeilnehmerID})")]
    public SingleResult<EreignisseTeilnehmer> GetEreignisseTeilnehmer(int key)
    {
        var items = this.context.EreignisseTeilnehmers.Where(i=>i.EreignisseTeilnehmerID == key);
        var result = SingleResult.Create(items);

        OnEreignisseTeilnehmerGet(ref result);

        return result;
    }
    partial void OnEreignisseTeilnehmerDeleted(Models.DbSinDarEla.EreignisseTeilnehmer item);
    partial void OnAfterEreignisseTeilnehmerDeleted(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpDelete("/odata/dbSinDarEla/EreignisseTeilnehmers(EreignisseTeilnehmerID={EreignisseTeilnehmerID})")]
    public IActionResult DeleteEreignisseTeilnehmer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.EreignisseTeilnehmers
                .Where(i => i.EreignisseTeilnehmerID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEreignisseTeilnehmerDeleted(item);
            this.context.EreignisseTeilnehmers.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEreignisseTeilnehmerDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerUpdated(Models.DbSinDarEla.EreignisseTeilnehmer item);
    partial void OnAfterEreignisseTeilnehmerUpdated(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpPut("/odata/dbSinDarEla/EreignisseTeilnehmers(EreignisseTeilnehmerID={EreignisseTeilnehmerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseTeilnehmer(int key, [FromBody]Models.DbSinDarEla.EreignisseTeilnehmer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisseTeilnehmerID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseTeilnehmerUpdated(newItem);
            this.context.EreignisseTeilnehmers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");
            this.OnAfterEreignisseTeilnehmerUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/EreignisseTeilnehmers(EreignisseTeilnehmerID={EreignisseTeilnehmerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseTeilnehmer(int key, [FromBody]Delta<Models.DbSinDarEla.EreignisseTeilnehmer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEreignisseTeilnehmerUpdated(item);
            this.context.EreignisseTeilnehmers.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerCreated(Models.DbSinDarEla.EreignisseTeilnehmer item);
    partial void OnAfterEreignisseTeilnehmerCreated(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseTeilnehmer item)
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

            this.OnEreignisseTeilnehmerCreated(item);
            this.context.EreignisseTeilnehmers.Add(item);
            this.context.SaveChanges();

            var key = item.EreignisseTeilnehmerID;

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");

            this.OnAfterEreignisseTeilnehmerCreated(item);

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
