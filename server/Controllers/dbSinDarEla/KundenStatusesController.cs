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

  [Route("odata/dbSinDarEla/KundenStatuses")]
  public partial class KundenStatusesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenStatusesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenStatus> GetKundenStatuses()
    {
      var items = this.context.KundenStatuses.AsQueryable<Models.DbSinDarEla.KundenStatus>();
      this.OnKundenStatusesRead(ref items);

      return items;
    }

    partial void OnKundenStatusesRead(ref IQueryable<Models.DbSinDarEla.KundenStatus> items);

    partial void OnKundenStatusGet(ref SingleResult<Models.DbSinDarEla.KundenStatus> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenStatuses(KundenStatusID={KundenStatusID})")]
    public SingleResult<KundenStatus> GetKundenStatus(int key)
    {
        var items = this.context.KundenStatuses.Where(i=>i.KundenStatusID == key);
        var result = SingleResult.Create(items);

        OnKundenStatusGet(ref result);

        return result;
    }
    partial void OnKundenStatusDeleted(Models.DbSinDarEla.KundenStatus item);
    partial void OnAfterKundenStatusDeleted(Models.DbSinDarEla.KundenStatus item);

    [HttpDelete("/odata/dbSinDarEla/KundenStatuses(KundenStatusID={KundenStatusID})")]
    public IActionResult DeleteKundenStatus(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenStatuses
                .Where(i => i.KundenStatusID == key)
                .Include(i => i.Kundens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenStatusDeleted(item);
            this.context.KundenStatuses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenStatusDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenStatusUpdated(Models.DbSinDarEla.KundenStatus item);
    partial void OnAfterKundenStatusUpdated(Models.DbSinDarEla.KundenStatus item);

    [HttpPut("/odata/dbSinDarEla/KundenStatuses(KundenStatusID={KundenStatusID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenStatus(int key, [FromBody]Models.DbSinDarEla.KundenStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenStatusID != key))
            {
                return BadRequest();
            }

            this.OnKundenStatusUpdated(newItem);
            this.context.KundenStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenStatuses.Where(i => i.KundenStatusID == key);
            this.OnAfterKundenStatusUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenStatuses(KundenStatusID={KundenStatusID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenStatus(int key, [FromBody]Delta<Models.DbSinDarEla.KundenStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenStatuses.Where(i => i.KundenStatusID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenStatusUpdated(item);
            this.context.KundenStatuses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenStatuses.Where(i => i.KundenStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenStatusCreated(Models.DbSinDarEla.KundenStatus item);
    partial void OnAfterKundenStatusCreated(Models.DbSinDarEla.KundenStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenStatus item)
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

            this.OnKundenStatusCreated(item);
            this.context.KundenStatuses.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterKundenStatusCreated(item);
            
            return Created($"odata/DbSinDarEla/KundenStatuses/{item.KundenStatusID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
