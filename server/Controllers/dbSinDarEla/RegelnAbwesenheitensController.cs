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

  [Route("odata/dbSinDarEla/RegelnAbwesenheitens")]
  public partial class RegelnAbwesenheitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public RegelnAbwesenheitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/RegelnAbwesenheitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.RegelnAbwesenheiten> GetRegelnAbwesenheitens()
    {
      var items = this.context.RegelnAbwesenheitens.AsQueryable<Models.DbSinDarEla.RegelnAbwesenheiten>();
      this.OnRegelnAbwesenheitensRead(ref items);

      return items;
    }

    partial void OnRegelnAbwesenheitensRead(ref IQueryable<Models.DbSinDarEla.RegelnAbwesenheiten> items);

    partial void OnRegelnAbwesenheitenGet(ref SingleResult<Models.DbSinDarEla.RegelnAbwesenheiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/RegelnAbwesenheitens(RegelnAbwesenheitenID={RegelnAbwesenheitenID})")]
    public SingleResult<RegelnAbwesenheiten> GetRegelnAbwesenheiten(int key)
    {
        var items = this.context.RegelnAbwesenheitens.Where(i=>i.RegelnAbwesenheitenID == key);
        var result = SingleResult.Create(items);

        OnRegelnAbwesenheitenGet(ref result);

        return result;
    }
    partial void OnRegelnAbwesenheitenDeleted(Models.DbSinDarEla.RegelnAbwesenheiten item);
    partial void OnAfterRegelnAbwesenheitenDeleted(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpDelete("/odata/dbSinDarEla/RegelnAbwesenheitens(RegelnAbwesenheitenID={RegelnAbwesenheitenID})")]
    public IActionResult DeleteRegelnAbwesenheiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.RegelnAbwesenheitens
                .Where(i => i.RegelnAbwesenheitenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnRegelnAbwesenheitenDeleted(item);
            this.context.RegelnAbwesenheitens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterRegelnAbwesenheitenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRegelnAbwesenheitenUpdated(Models.DbSinDarEla.RegelnAbwesenheiten item);
    partial void OnAfterRegelnAbwesenheitenUpdated(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpPut("/odata/dbSinDarEla/RegelnAbwesenheitens(RegelnAbwesenheitenID={RegelnAbwesenheitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutRegelnAbwesenheiten(int key, [FromBody]Models.DbSinDarEla.RegelnAbwesenheiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.RegelnAbwesenheitenID != key))
            {
                return BadRequest();
            }

            this.OnRegelnAbwesenheitenUpdated(newItem);
            this.context.RegelnAbwesenheitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key);
            this.OnAfterRegelnAbwesenheitenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/RegelnAbwesenheitens(RegelnAbwesenheitenID={RegelnAbwesenheitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchRegelnAbwesenheiten(int key, [FromBody]Delta<Models.DbSinDarEla.RegelnAbwesenheiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnRegelnAbwesenheitenUpdated(item);
            this.context.RegelnAbwesenheitens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRegelnAbwesenheitenCreated(Models.DbSinDarEla.RegelnAbwesenheiten item);
    partial void OnAfterRegelnAbwesenheitenCreated(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.RegelnAbwesenheiten item)
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

            this.OnRegelnAbwesenheitenCreated(item);
            this.context.RegelnAbwesenheitens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterRegelnAbwesenheitenCreated(item);
            
            return Created($"odata/DbSinDarEla/RegelnAbwesenheitens/{item.RegelnAbwesenheitenID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
