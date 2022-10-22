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

  [Route("odata/dbSinDarEla/KundenKontakteArtens")]
  public partial class KundenKontakteArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenKontakteArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenKontakteArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenKontakteArten> GetKundenKontakteArtens()
    {
      var items = this.context.KundenKontakteArtens.AsQueryable<Models.DbSinDarEla.KundenKontakteArten>();
      this.OnKundenKontakteArtensRead(ref items);

      return items;
    }

    partial void OnKundenKontakteArtensRead(ref IQueryable<Models.DbSinDarEla.KundenKontakteArten> items);

    partial void OnKundenKontakteArtenGet(ref SingleResult<Models.DbSinDarEla.KundenKontakteArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenKontakteArtens(KundenKontaktArtID={KundenKontaktArtID})")]
    public SingleResult<KundenKontakteArten> GetKundenKontakteArten(int key)
    {
        var items = this.context.KundenKontakteArtens.Where(i=>i.KundenKontaktArtID == key);
        var result = SingleResult.Create(items);

        OnKundenKontakteArtenGet(ref result);

        return result;
    }
    partial void OnKundenKontakteArtenDeleted(Models.DbSinDarEla.KundenKontakteArten item);
    partial void OnAfterKundenKontakteArtenDeleted(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpDelete("/odata/dbSinDarEla/KundenKontakteArtens(KundenKontaktArtID={KundenKontaktArtID})")]
    public IActionResult DeleteKundenKontakteArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenKontakteArtens
                .Where(i => i.KundenKontaktArtID == key)
                .Include(i => i.KundenKontaktes)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenKontakteArtenDeleted(item);
            this.context.KundenKontakteArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenKontakteArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteArtenUpdated(Models.DbSinDarEla.KundenKontakteArten item);
    partial void OnAfterKundenKontakteArtenUpdated(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpPut("/odata/dbSinDarEla/KundenKontakteArtens(KundenKontaktArtID={KundenKontaktArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenKontakteArten(int key, [FromBody]Models.DbSinDarEla.KundenKontakteArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenKontaktArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenKontakteArtenUpdated(newItem);
            this.context.KundenKontakteArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key);
            this.OnAfterKundenKontakteArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenKontakteArtens(KundenKontaktArtID={KundenKontaktArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenKontakteArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenKontakteArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenKontakteArtenUpdated(item);
            this.context.KundenKontakteArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteArtenCreated(Models.DbSinDarEla.KundenKontakteArten item);
    partial void OnAfterKundenKontakteArtenCreated(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenKontakteArten item)
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

            this.OnKundenKontakteArtenCreated(item);
            this.context.KundenKontakteArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterKundenKontakteArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/KundenKontakteArtens/{item.KundenKontaktArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
