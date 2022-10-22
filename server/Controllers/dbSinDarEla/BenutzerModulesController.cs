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

  [Route("odata/dbSinDarEla/BenutzerModules")]
  public partial class BenutzerModulesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BenutzerModulesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BenutzerModules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BenutzerModule> GetBenutzerModules()
    {
      var items = this.context.BenutzerModules.AsQueryable<Models.DbSinDarEla.BenutzerModule>();
      this.OnBenutzerModulesRead(ref items);

      return items;
    }

    partial void OnBenutzerModulesRead(ref IQueryable<Models.DbSinDarEla.BenutzerModule> items);

    partial void OnBenutzerModuleGet(ref SingleResult<Models.DbSinDarEla.BenutzerModule> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/BenutzerModules(BenutzerModuleID={BenutzerModuleID})")]
    public SingleResult<BenutzerModule> GetBenutzerModule(int key)
    {
        var items = this.context.BenutzerModules.Where(i=>i.BenutzerModuleID == key);
        var result = SingleResult.Create(items);

        OnBenutzerModuleGet(ref result);

        return result;
    }
    partial void OnBenutzerModuleDeleted(Models.DbSinDarEla.BenutzerModule item);
    partial void OnAfterBenutzerModuleDeleted(Models.DbSinDarEla.BenutzerModule item);

    [HttpDelete("/odata/dbSinDarEla/BenutzerModules(BenutzerModuleID={BenutzerModuleID})")]
    public IActionResult DeleteBenutzerModule(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.BenutzerModules
                .Where(i => i.BenutzerModuleID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBenutzerModuleDeleted(item);
            this.context.BenutzerModules.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBenutzerModuleDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerModuleUpdated(Models.DbSinDarEla.BenutzerModule item);
    partial void OnAfterBenutzerModuleUpdated(Models.DbSinDarEla.BenutzerModule item);

    [HttpPut("/odata/dbSinDarEla/BenutzerModules(BenutzerModuleID={BenutzerModuleID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzerModule(int key, [FromBody]Models.DbSinDarEla.BenutzerModule newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerModuleID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerModuleUpdated(newItem);
            this.context.BenutzerModules.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");
            this.OnAfterBenutzerModuleUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/BenutzerModules(BenutzerModuleID={BenutzerModuleID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzerModule(int key, [FromBody]Delta<Models.DbSinDarEla.BenutzerModule> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBenutzerModuleUpdated(item);
            this.context.BenutzerModules.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerModuleCreated(Models.DbSinDarEla.BenutzerModule item);
    partial void OnAfterBenutzerModuleCreated(Models.DbSinDarEla.BenutzerModule item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BenutzerModule item)
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

            this.OnBenutzerModuleCreated(item);
            this.context.BenutzerModules.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerModuleID;

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");

            this.OnAfterBenutzerModuleCreated(item);

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
