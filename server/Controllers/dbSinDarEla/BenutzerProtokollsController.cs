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

  [Route("odata/dbSinDarEla/BenutzerProtokolls")]
  public partial class BenutzerProtokollsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BenutzerProtokollsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BenutzerProtokolls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BenutzerProtokoll> GetBenutzerProtokolls()
    {
      var items = this.context.BenutzerProtokolls.AsQueryable<Models.DbSinDarEla.BenutzerProtokoll>();
      this.OnBenutzerProtokollsRead(ref items);

      return items;
    }

    partial void OnBenutzerProtokollsRead(ref IQueryable<Models.DbSinDarEla.BenutzerProtokoll> items);

    partial void OnBenutzerProtokollGet(ref SingleResult<Models.DbSinDarEla.BenutzerProtokoll> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/BenutzerProtokolls(BenutzerProtokollID={BenutzerProtokollID})")]
    public SingleResult<BenutzerProtokoll> GetBenutzerProtokoll(int key)
    {
        var items = this.context.BenutzerProtokolls.Where(i=>i.BenutzerProtokollID == key);
        var result = SingleResult.Create(items);

        OnBenutzerProtokollGet(ref result);

        return result;
    }
    partial void OnBenutzerProtokollDeleted(Models.DbSinDarEla.BenutzerProtokoll item);
    partial void OnAfterBenutzerProtokollDeleted(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpDelete("/odata/dbSinDarEla/BenutzerProtokolls(BenutzerProtokollID={BenutzerProtokollID})")]
    public IActionResult DeleteBenutzerProtokoll(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.BenutzerProtokolls
                .Where(i => i.BenutzerProtokollID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBenutzerProtokollDeleted(item);
            this.context.BenutzerProtokolls.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBenutzerProtokollDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerProtokollUpdated(Models.DbSinDarEla.BenutzerProtokoll item);
    partial void OnAfterBenutzerProtokollUpdated(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpPut("/odata/dbSinDarEla/BenutzerProtokolls(BenutzerProtokollID={BenutzerProtokollID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzerProtokoll(int key, [FromBody]Models.DbSinDarEla.BenutzerProtokoll newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerProtokollID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerProtokollUpdated(newItem);
            this.context.BenutzerProtokolls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");
            this.OnAfterBenutzerProtokollUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/BenutzerProtokolls(BenutzerProtokollID={BenutzerProtokollID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzerProtokoll(int key, [FromBody]Delta<Models.DbSinDarEla.BenutzerProtokoll> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBenutzerProtokollUpdated(item);
            this.context.BenutzerProtokolls.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerProtokollCreated(Models.DbSinDarEla.BenutzerProtokoll item);
    partial void OnAfterBenutzerProtokollCreated(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BenutzerProtokoll item)
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

            this.OnBenutzerProtokollCreated(item);
            this.context.BenutzerProtokolls.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerProtokollID;

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");

            this.OnAfterBenutzerProtokollCreated(item);

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
