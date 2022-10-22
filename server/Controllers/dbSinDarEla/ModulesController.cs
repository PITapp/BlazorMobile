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

  [Route("odata/dbSinDarEla/Modules")]
  public partial class ModulesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public ModulesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Modules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Module> GetModules()
    {
      var items = this.context.Modules.AsQueryable<Models.DbSinDarEla.Module>();
      this.OnModulesRead(ref items);

      return items;
    }

    partial void OnModulesRead(ref IQueryable<Models.DbSinDarEla.Module> items);

    partial void OnModuleGet(ref SingleResult<Models.DbSinDarEla.Module> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Modules(ModulID={ModulID})")]
    public SingleResult<Module> GetModule(int key)
    {
        var items = this.context.Modules.Where(i=>i.ModulID == key);
        var result = SingleResult.Create(items);

        OnModuleGet(ref result);

        return result;
    }
    partial void OnModuleDeleted(Models.DbSinDarEla.Module item);
    partial void OnAfterModuleDeleted(Models.DbSinDarEla.Module item);

    [HttpDelete("/odata/dbSinDarEla/Modules(ModulID={ModulID})")]
    public IActionResult DeleteModule(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Modules
                .Where(i => i.ModulID == key)
                .Include(i => i.BenutzerModules)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnModuleDeleted(item);
            this.context.Modules.Remove(item);
            this.context.SaveChanges();
            this.OnAfterModuleDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnModuleUpdated(Models.DbSinDarEla.Module item);
    partial void OnAfterModuleUpdated(Models.DbSinDarEla.Module item);

    [HttpPut("/odata/dbSinDarEla/Modules(ModulID={ModulID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutModule(int key, [FromBody]Models.DbSinDarEla.Module newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ModulID != key))
            {
                return BadRequest();
            }

            this.OnModuleUpdated(newItem);
            this.context.Modules.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Modules.Where(i => i.ModulID == key);
            this.OnAfterModuleUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Modules(ModulID={ModulID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchModule(int key, [FromBody]Delta<Models.DbSinDarEla.Module> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Modules.Where(i => i.ModulID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnModuleUpdated(item);
            this.context.Modules.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Modules.Where(i => i.ModulID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnModuleCreated(Models.DbSinDarEla.Module item);
    partial void OnAfterModuleCreated(Models.DbSinDarEla.Module item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Module item)
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

            this.OnModuleCreated(item);
            this.context.Modules.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterModuleCreated(item);
            
            return Created($"odata/DbSinDarEla/Modules/{item.ModulID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
