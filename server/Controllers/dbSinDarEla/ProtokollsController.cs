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

  [Route("odata/dbSinDarEla/Protokolls")]
  public partial class ProtokollsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public ProtokollsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Protokolls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Protokoll> GetProtokolls()
    {
      var items = this.context.Protokolls.AsQueryable<Models.DbSinDarEla.Protokoll>();
      this.OnProtokollsRead(ref items);

      return items;
    }

    partial void OnProtokollsRead(ref IQueryable<Models.DbSinDarEla.Protokoll> items);

    partial void OnProtokollGet(ref SingleResult<Models.DbSinDarEla.Protokoll> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Protokolls(ProtokollID={ProtokollID})")]
    public SingleResult<Protokoll> GetProtokoll(int key)
    {
        var items = this.context.Protokolls.Where(i=>i.ProtokollID == key);
        var result = SingleResult.Create(items);

        OnProtokollGet(ref result);

        return result;
    }
    partial void OnProtokollDeleted(Models.DbSinDarEla.Protokoll item);
    partial void OnAfterProtokollDeleted(Models.DbSinDarEla.Protokoll item);

    [HttpDelete("/odata/dbSinDarEla/Protokolls(ProtokollID={ProtokollID})")]
    public IActionResult DeleteProtokoll(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Protokolls
                .Where(i => i.ProtokollID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnProtokollDeleted(item);
            this.context.Protokolls.Remove(item);
            this.context.SaveChanges();
            this.OnAfterProtokollDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProtokollUpdated(Models.DbSinDarEla.Protokoll item);
    partial void OnAfterProtokollUpdated(Models.DbSinDarEla.Protokoll item);

    [HttpPut("/odata/dbSinDarEla/Protokolls(ProtokollID={ProtokollID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProtokoll(int key, [FromBody]Models.DbSinDarEla.Protokoll newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ProtokollID != key))
            {
                return BadRequest();
            }

            this.OnProtokollUpdated(newItem);
            this.context.Protokolls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            this.OnAfterProtokollUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Protokolls(ProtokollID={ProtokollID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchProtokoll(int key, [FromBody]Delta<Models.DbSinDarEla.Protokoll> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Protokolls.Where(i => i.ProtokollID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnProtokollUpdated(item);
            this.context.Protokolls.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProtokollCreated(Models.DbSinDarEla.Protokoll item);
    partial void OnAfterProtokollCreated(Models.DbSinDarEla.Protokoll item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Protokoll item)
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

            this.OnProtokollCreated(item);
            this.context.Protokolls.Add(item);
            this.context.SaveChanges();

            var key = item.ProtokollID;

            var itemToReturn = this.context.Protokolls.Where(i => i.ProtokollID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

            this.OnAfterProtokollCreated(item);

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
