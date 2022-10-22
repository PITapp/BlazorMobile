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

  [Route("odata/dbSinDarEla/BaseAnredens")]
  public partial class BaseAnredensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BaseAnredensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BaseAnredens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BaseAnreden> GetBaseAnredens()
    {
      var items = this.context.BaseAnredens.AsQueryable<Models.DbSinDarEla.BaseAnreden>();
      this.OnBaseAnredensRead(ref items);

      return items;
    }

    partial void OnBaseAnredensRead(ref IQueryable<Models.DbSinDarEla.BaseAnreden> items);

    partial void OnBaseAnredenGet(ref SingleResult<Models.DbSinDarEla.BaseAnreden> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/BaseAnredens(AnredeID={AnredeID})")]
    public SingleResult<BaseAnreden> GetBaseAnreden(int key)
    {
        var items = this.context.BaseAnredens.Where(i=>i.AnredeID == key);
        var result = SingleResult.Create(items);

        OnBaseAnredenGet(ref result);

        return result;
    }
    partial void OnBaseAnredenDeleted(Models.DbSinDarEla.BaseAnreden item);
    partial void OnAfterBaseAnredenDeleted(Models.DbSinDarEla.BaseAnreden item);

    [HttpDelete("/odata/dbSinDarEla/BaseAnredens(AnredeID={AnredeID})")]
    public IActionResult DeleteBaseAnreden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.BaseAnredens
                .Where(i => i.AnredeID == key)
                .Include(i => i.Bases)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBaseAnredenDeleted(item);
            this.context.BaseAnredens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBaseAnredenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseAnredenUpdated(Models.DbSinDarEla.BaseAnreden item);
    partial void OnAfterBaseAnredenUpdated(Models.DbSinDarEla.BaseAnreden item);

    [HttpPut("/odata/dbSinDarEla/BaseAnredens(AnredeID={AnredeID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseAnreden(int key, [FromBody]Models.DbSinDarEla.BaseAnreden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AnredeID != key))
            {
                return BadRequest();
            }

            this.OnBaseAnredenUpdated(newItem);
            this.context.BaseAnredens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseAnredens.Where(i => i.AnredeID == key);
            this.OnAfterBaseAnredenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/BaseAnredens(AnredeID={AnredeID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseAnreden(int key, [FromBody]Delta<Models.DbSinDarEla.BaseAnreden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.BaseAnredens.Where(i => i.AnredeID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBaseAnredenUpdated(item);
            this.context.BaseAnredens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseAnredens.Where(i => i.AnredeID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseAnredenCreated(Models.DbSinDarEla.BaseAnreden item);
    partial void OnAfterBaseAnredenCreated(Models.DbSinDarEla.BaseAnreden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BaseAnreden item)
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

            this.OnBaseAnredenCreated(item);
            this.context.BaseAnredens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterBaseAnredenCreated(item);
            
            return Created($"odata/DbSinDarEla/BaseAnredens/{item.AnredeID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
