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

  [Route("odata/dbSinDarEla/BaseKontaktes")]
  public partial class BaseKontaktesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BaseKontaktesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BaseKontakte> GetBaseKontaktes()
    {
      var items = this.context.BaseKontaktes.AsQueryable<Models.DbSinDarEla.BaseKontakte>();
      this.OnBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnBaseKontaktesRead(ref IQueryable<Models.DbSinDarEla.BaseKontakte> items);

    partial void OnBaseKontakteGet(ref SingleResult<Models.DbSinDarEla.BaseKontakte> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/BaseKontaktes(KontaktID={KontaktID})")]
    public SingleResult<BaseKontakte> GetBaseKontakte(int key)
    {
        var items = this.context.BaseKontaktes.Where(i=>i.KontaktID == key);
        var result = SingleResult.Create(items);

        OnBaseKontakteGet(ref result);

        return result;
    }
    partial void OnBaseKontakteDeleted(Models.DbSinDarEla.BaseKontakte item);
    partial void OnAfterBaseKontakteDeleted(Models.DbSinDarEla.BaseKontakte item);

    [HttpDelete("/odata/dbSinDarEla/BaseKontaktes(KontaktID={KontaktID})")]
    public IActionResult DeleteBaseKontakte(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.BaseKontaktes
                .Where(i => i.KontaktID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBaseKontakteDeleted(item);
            this.context.BaseKontaktes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBaseKontakteDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteUpdated(Models.DbSinDarEla.BaseKontakte item);
    partial void OnAfterBaseKontakteUpdated(Models.DbSinDarEla.BaseKontakte item);

    [HttpPut("/odata/dbSinDarEla/BaseKontaktes(KontaktID={KontaktID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseKontakte(int key, [FromBody]Models.DbSinDarEla.BaseKontakte newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KontaktID != key))
            {
                return BadRequest();
            }

            this.OnBaseKontakteUpdated(newItem);
            this.context.BaseKontaktes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            this.OnAfterBaseKontakteUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/BaseKontaktes(KontaktID={KontaktID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseKontakte(int key, [FromBody]Delta<Models.DbSinDarEla.BaseKontakte> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.BaseKontaktes.Where(i => i.KontaktID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBaseKontakteUpdated(item);
            this.context.BaseKontaktes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteCreated(Models.DbSinDarEla.BaseKontakte item);
    partial void OnAfterBaseKontakteCreated(Models.DbSinDarEla.BaseKontakte item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BaseKontakte item)
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

            this.OnBaseKontakteCreated(item);
            this.context.BaseKontaktes.Add(item);
            this.context.SaveChanges();

            var key = item.KontaktID;

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

            this.OnAfterBaseKontakteCreated(item);

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
