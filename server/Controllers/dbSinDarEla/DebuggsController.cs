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

  [Route("odata/dbSinDarEla/Debuggs")]
  public partial class DebuggsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public DebuggsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Debuggs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Debugg> GetDebuggs()
    {
      var items = this.context.Debuggs.AsQueryable<Models.DbSinDarEla.Debugg>();
      this.OnDebuggsRead(ref items);

      return items;
    }

    partial void OnDebuggsRead(ref IQueryable<Models.DbSinDarEla.Debugg> items);

    partial void OnDebuggGet(ref SingleResult<Models.DbSinDarEla.Debugg> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Debuggs(DebuggID={DebuggID})")]
    public SingleResult<Debugg> GetDebugg(int key)
    {
        var items = this.context.Debuggs.Where(i=>i.DebuggID == key);
        var result = SingleResult.Create(items);

        OnDebuggGet(ref result);

        return result;
    }
    partial void OnDebuggDeleted(Models.DbSinDarEla.Debugg item);
    partial void OnAfterDebuggDeleted(Models.DbSinDarEla.Debugg item);

    [HttpDelete("/odata/dbSinDarEla/Debuggs(DebuggID={DebuggID})")]
    public IActionResult DeleteDebugg(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Debuggs
                .Where(i => i.DebuggID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDebuggDeleted(item);
            this.context.Debuggs.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDebuggDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDebuggUpdated(Models.DbSinDarEla.Debugg item);
    partial void OnAfterDebuggUpdated(Models.DbSinDarEla.Debugg item);

    [HttpPut("/odata/dbSinDarEla/Debuggs(DebuggID={DebuggID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDebugg(int key, [FromBody]Models.DbSinDarEla.Debugg newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DebuggID != key))
            {
                return BadRequest();
            }

            this.OnDebuggUpdated(newItem);
            this.context.Debuggs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Debuggs.Where(i => i.DebuggID == key);
            this.OnAfterDebuggUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Debuggs(DebuggID={DebuggID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDebugg(int key, [FromBody]Delta<Models.DbSinDarEla.Debugg> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Debuggs.Where(i => i.DebuggID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDebuggUpdated(item);
            this.context.Debuggs.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Debuggs.Where(i => i.DebuggID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDebuggCreated(Models.DbSinDarEla.Debugg item);
    partial void OnAfterDebuggCreated(Models.DbSinDarEla.Debugg item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Debugg item)
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

            this.OnDebuggCreated(item);
            this.context.Debuggs.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterDebuggCreated(item);
            
            return Created($"odata/DbSinDarEla/Debuggs/{item.DebuggID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
