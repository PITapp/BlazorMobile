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

  [Route("odata/dbSinDarEla/Notizens")]
  public partial class NotizensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public NotizensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Notizens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Notizen> GetNotizens()
    {
      var items = this.context.Notizens.AsQueryable<Models.DbSinDarEla.Notizen>();
      this.OnNotizensRead(ref items);

      return items;
    }

    partial void OnNotizensRead(ref IQueryable<Models.DbSinDarEla.Notizen> items);

    partial void OnNotizenGet(ref SingleResult<Models.DbSinDarEla.Notizen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Notizens(NotizID={NotizID})")]
    public SingleResult<Notizen> GetNotizen(int key)
    {
        var items = this.context.Notizens.Where(i=>i.NotizID == key);
        var result = SingleResult.Create(items);

        OnNotizenGet(ref result);

        return result;
    }
    partial void OnNotizenDeleted(Models.DbSinDarEla.Notizen item);
    partial void OnAfterNotizenDeleted(Models.DbSinDarEla.Notizen item);

    [HttpDelete("/odata/dbSinDarEla/Notizens(NotizID={NotizID})")]
    public IActionResult DeleteNotizen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Notizens
                .Where(i => i.NotizID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnNotizenDeleted(item);
            this.context.Notizens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterNotizenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnNotizenUpdated(Models.DbSinDarEla.Notizen item);
    partial void OnAfterNotizenUpdated(Models.DbSinDarEla.Notizen item);

    [HttpPut("/odata/dbSinDarEla/Notizens(NotizID={NotizID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutNotizen(int key, [FromBody]Models.DbSinDarEla.Notizen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.NotizID != key))
            {
                return BadRequest();
            }

            this.OnNotizenUpdated(newItem);
            this.context.Notizens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Notizens.Where(i => i.NotizID == key);
            this.OnAfterNotizenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Notizens(NotizID={NotizID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchNotizen(int key, [FromBody]Delta<Models.DbSinDarEla.Notizen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Notizens.Where(i => i.NotizID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnNotizenUpdated(item);
            this.context.Notizens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Notizens.Where(i => i.NotizID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnNotizenCreated(Models.DbSinDarEla.Notizen item);
    partial void OnAfterNotizenCreated(Models.DbSinDarEla.Notizen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Notizen item)
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

            this.OnNotizenCreated(item);
            this.context.Notizens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterNotizenCreated(item);
            
            return Created($"odata/DbSinDarEla/Notizens/{item.NotizID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
