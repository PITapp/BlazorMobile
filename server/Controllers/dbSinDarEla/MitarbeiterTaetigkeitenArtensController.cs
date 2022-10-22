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

  [Route("odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens")]
  public partial class MitarbeiterTaetigkeitenArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterTaetigkeitenArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterTaetigkeitenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> GetMitarbeiterTaetigkeitenArtens()
    {
      var items = this.context.MitarbeiterTaetigkeitenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>();
      this.OnMitarbeiterTaetigkeitenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterTaetigkeitenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> items);

    partial void OnMitarbeiterTaetigkeitenArtenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens(MitarbeiterTaetigkeitenArtID={MitarbeiterTaetigkeitenArtID})")]
    public SingleResult<MitarbeiterTaetigkeitenArten> GetMitarbeiterTaetigkeitenArten(int key)
    {
        var items = this.context.MitarbeiterTaetigkeitenArtens.Where(i=>i.MitarbeiterTaetigkeitenArtID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterTaetigkeitenArtenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterTaetigkeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);
    partial void OnAfterMitarbeiterTaetigkeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens(MitarbeiterTaetigkeitenArtID={MitarbeiterTaetigkeitenArtID})")]
    public IActionResult DeleteMitarbeiterTaetigkeitenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterTaetigkeitenArtens
                .Where(i => i.MitarbeiterTaetigkeitenArtID == key)
                .Include(i => i.FirmenMitarbeiterTaetigkeitens)
                .Include(i => i.MitarbeiterTaetigkeitens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenArtenDeleted(item);
            this.context.MitarbeiterTaetigkeitenArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterTaetigkeitenArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);
    partial void OnAfterMitarbeiterTaetigkeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens(MitarbeiterTaetigkeitenArtID={MitarbeiterTaetigkeitenArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterTaetigkeitenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterTaetigkeitenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterTaetigkeitenArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenArtenUpdated(newItem);
            this.context.MitarbeiterTaetigkeitenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key);
            this.OnAfterMitarbeiterTaetigkeitenArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens(MitarbeiterTaetigkeitenArtID={MitarbeiterTaetigkeitenArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterTaetigkeitenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterTaetigkeitenArtenUpdated(item);
            this.context.MitarbeiterTaetigkeitenArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenArtenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);
    partial void OnAfterMitarbeiterTaetigkeitenArtenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item)
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

            this.OnMitarbeiterTaetigkeitenArtenCreated(item);
            this.context.MitarbeiterTaetigkeitenArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterTaetigkeitenArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterTaetigkeitenArtens/{item.MitarbeiterTaetigkeitenArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
