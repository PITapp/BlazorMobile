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

  [Route("odata/dbSinDarEla/KundenLeistungenBetreuerArtens")]
  public partial class KundenLeistungenBetreuerArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungenBetreuerArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBetreuerArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBetreuerArten> GetKundenLeistungenBetreuerArtens()
    {
      var items = this.context.KundenLeistungenBetreuerArtens.AsQueryable<Models.DbSinDarEla.KundenLeistungenBetreuerArten>();
      this.OnKundenLeistungenBetreuerArtensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBetreuerArtensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuerArten> items);

    partial void OnKundenLeistungenBetreuerArtenGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungenBetreuerArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungenBetreuerArtens(KundenLeistungenBetreuerArtID={KundenLeistungenBetreuerArtID})")]
    public SingleResult<KundenLeistungenBetreuerArten> GetKundenLeistungenBetreuerArten(int key)
    {
        var items = this.context.KundenLeistungenBetreuerArtens.Where(i=>i.KundenLeistungenBetreuerArtID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungenBetreuerArtenGet(ref result);

        return result;
    }
    partial void OnKundenLeistungenBetreuerArtenDeleted(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);
    partial void OnAfterKundenLeistungenBetreuerArtenDeleted(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungenBetreuerArtens(KundenLeistungenBetreuerArtID={KundenLeistungenBetreuerArtID})")]
    public IActionResult DeleteKundenLeistungenBetreuerArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungenBetreuerArtens
                .Where(i => i.KundenLeistungenBetreuerArtID == key)
                .Include(i => i.KundenLeistungenBetreuers)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerArtenDeleted(item);
            this.context.KundenLeistungenBetreuerArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungenBetreuerArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerArtenUpdated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);
    partial void OnAfterKundenLeistungenBetreuerArtenUpdated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungenBetreuerArtens(KundenLeistungenBetreuerArtID={KundenLeistungenBetreuerArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBetreuerArten(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBetreuerArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBetreuerArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerArtenUpdated(newItem);
            this.context.KundenLeistungenBetreuerArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key);
            this.OnAfterKundenLeistungenBetreuerArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungenBetreuerArtens(KundenLeistungenBetreuerArtID={KundenLeistungenBetreuerArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBetreuerArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBetreuerArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungenBetreuerArtenUpdated(item);
            this.context.KundenLeistungenBetreuerArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerArtenCreated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);
    partial void OnAfterKundenLeistungenBetreuerArtenCreated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBetreuerArten item)
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

            this.OnKundenLeistungenBetreuerArtenCreated(item);
            this.context.KundenLeistungenBetreuerArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterKundenLeistungenBetreuerArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/KundenLeistungenBetreuerArtens/{item.KundenLeistungenBetreuerArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
