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

  [Route("odata/dbSinDarEla/MitarbeiterArtens")]
  public partial class MitarbeiterArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterArten> GetMitarbeiterArtens()
    {
      var items = this.context.MitarbeiterArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterArten>();
      this.OnMitarbeiterArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterArten> items);

    partial void OnMitarbeiterArtenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterArtens(MitarbeiterArtID={MitarbeiterArtID})")]
    public SingleResult<MitarbeiterArten> GetMitarbeiterArten(int key)
    {
        var items = this.context.MitarbeiterArtens.Where(i=>i.MitarbeiterArtID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterArtenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterArtenDeleted(Models.DbSinDarEla.MitarbeiterArten item);
    partial void OnAfterMitarbeiterArtenDeleted(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterArtens(MitarbeiterArtID={MitarbeiterArtID})")]
    public IActionResult DeleteMitarbeiterArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterArtens
                .Where(i => i.MitarbeiterArtID == key)
                .Include(i => i.Mitarbeiters)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterArtenDeleted(item);
            this.context.MitarbeiterArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterArtenUpdated(Models.DbSinDarEla.MitarbeiterArten item);
    partial void OnAfterMitarbeiterArtenUpdated(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterArtens(MitarbeiterArtID={MitarbeiterArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterArtenUpdated(newItem);
            this.context.MitarbeiterArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key);
            this.OnAfterMitarbeiterArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterArtens(MitarbeiterArtID={MitarbeiterArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterArtenUpdated(item);
            this.context.MitarbeiterArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterArtenCreated(Models.DbSinDarEla.MitarbeiterArten item);
    partial void OnAfterMitarbeiterArtenCreated(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterArten item)
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

            this.OnMitarbeiterArtenCreated(item);
            this.context.MitarbeiterArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterArtens/{item.MitarbeiterArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
