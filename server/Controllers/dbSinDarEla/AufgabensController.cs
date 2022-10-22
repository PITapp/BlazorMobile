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

  [Route("odata/dbSinDarEla/Aufgabens")]
  public partial class AufgabensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public AufgabensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Aufgabens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Aufgaben> GetAufgabens()
    {
      var items = this.context.Aufgabens.AsQueryable<Models.DbSinDarEla.Aufgaben>();
      this.OnAufgabensRead(ref items);

      return items;
    }

    partial void OnAufgabensRead(ref IQueryable<Models.DbSinDarEla.Aufgaben> items);

    partial void OnAufgabenGet(ref SingleResult<Models.DbSinDarEla.Aufgaben> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Aufgabens(AufgabeID={AufgabeID})")]
    public SingleResult<Aufgaben> GetAufgaben(int key)
    {
        var items = this.context.Aufgabens.Where(i=>i.AufgabeID == key);
        var result = SingleResult.Create(items);

        OnAufgabenGet(ref result);

        return result;
    }
    partial void OnAufgabenDeleted(Models.DbSinDarEla.Aufgaben item);
    partial void OnAfterAufgabenDeleted(Models.DbSinDarEla.Aufgaben item);

    [HttpDelete("/odata/dbSinDarEla/Aufgabens(AufgabeID={AufgabeID})")]
    public IActionResult DeleteAufgaben(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Aufgabens
                .Where(i => i.AufgabeID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAufgabenDeleted(item);
            this.context.Aufgabens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAufgabenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAufgabenUpdated(Models.DbSinDarEla.Aufgaben item);
    partial void OnAfterAufgabenUpdated(Models.DbSinDarEla.Aufgaben item);

    [HttpPut("/odata/dbSinDarEla/Aufgabens(AufgabeID={AufgabeID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAufgaben(int key, [FromBody]Models.DbSinDarEla.Aufgaben newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AufgabeID != key))
            {
                return BadRequest();
            }

            this.OnAufgabenUpdated(newItem);
            this.context.Aufgabens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");
            this.OnAfterAufgabenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Aufgabens(AufgabeID={AufgabeID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAufgaben(int key, [FromBody]Delta<Models.DbSinDarEla.Aufgaben> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Aufgabens.Where(i => i.AufgabeID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAufgabenUpdated(item);
            this.context.Aufgabens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAufgabenCreated(Models.DbSinDarEla.Aufgaben item);
    partial void OnAfterAufgabenCreated(Models.DbSinDarEla.Aufgaben item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Aufgaben item)
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

            this.OnAufgabenCreated(item);
            this.context.Aufgabens.Add(item);
            this.context.SaveChanges();

            var key = item.AufgabeID;

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");

            this.OnAfterAufgabenCreated(item);

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
