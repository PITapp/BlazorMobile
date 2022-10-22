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

  [Route("odata/dbSinDarEla/AuswahlJahrs")]
  public partial class AuswahlJahrsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public AuswahlJahrsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AuswahlJahrs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AuswahlJahr> GetAuswahlJahrs()
    {
      var items = this.context.AuswahlJahrs.AsQueryable<Models.DbSinDarEla.AuswahlJahr>();
      this.OnAuswahlJahrsRead(ref items);

      return items;
    }

    partial void OnAuswahlJahrsRead(ref IQueryable<Models.DbSinDarEla.AuswahlJahr> items);

    partial void OnAuswahlJahrGet(ref SingleResult<Models.DbSinDarEla.AuswahlJahr> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/AuswahlJahrs(AuswahlJahrID={AuswahlJahrID})")]
    public SingleResult<AuswahlJahr> GetAuswahlJahr(int key)
    {
        var items = this.context.AuswahlJahrs.Where(i=>i.AuswahlJahrID == key);
        var result = SingleResult.Create(items);

        OnAuswahlJahrGet(ref result);

        return result;
    }
    partial void OnAuswahlJahrDeleted(Models.DbSinDarEla.AuswahlJahr item);
    partial void OnAfterAuswahlJahrDeleted(Models.DbSinDarEla.AuswahlJahr item);

    [HttpDelete("/odata/dbSinDarEla/AuswahlJahrs(AuswahlJahrID={AuswahlJahrID})")]
    public IActionResult DeleteAuswahlJahr(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.AuswahlJahrs
                .Where(i => i.AuswahlJahrID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAuswahlJahrDeleted(item);
            this.context.AuswahlJahrs.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAuswahlJahrDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlJahrUpdated(Models.DbSinDarEla.AuswahlJahr item);
    partial void OnAfterAuswahlJahrUpdated(Models.DbSinDarEla.AuswahlJahr item);

    [HttpPut("/odata/dbSinDarEla/AuswahlJahrs(AuswahlJahrID={AuswahlJahrID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAuswahlJahr(int key, [FromBody]Models.DbSinDarEla.AuswahlJahr newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AuswahlJahrID != key))
            {
                return BadRequest();
            }

            this.OnAuswahlJahrUpdated(newItem);
            this.context.AuswahlJahrs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key);
            this.OnAfterAuswahlJahrUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/AuswahlJahrs(AuswahlJahrID={AuswahlJahrID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAuswahlJahr(int key, [FromBody]Delta<Models.DbSinDarEla.AuswahlJahr> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAuswahlJahrUpdated(item);
            this.context.AuswahlJahrs.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlJahrCreated(Models.DbSinDarEla.AuswahlJahr item);
    partial void OnAfterAuswahlJahrCreated(Models.DbSinDarEla.AuswahlJahr item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AuswahlJahr item)
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

            this.OnAuswahlJahrCreated(item);
            this.context.AuswahlJahrs.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterAuswahlJahrCreated(item);
            
            return Created($"odata/DbSinDarEla/AuswahlJahrs/{item.AuswahlJahrID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
