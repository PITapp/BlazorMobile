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

  [Route("odata/dbSinDarEla/KundenLeistungArtens")]
  public partial class KundenLeistungArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungArten> GetKundenLeistungArtens()
    {
      var items = this.context.KundenLeistungArtens.AsQueryable<Models.DbSinDarEla.KundenLeistungArten>();
      this.OnKundenLeistungArtensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungArtensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungArten> items);

    partial void OnKundenLeistungArtenGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungArtens(KundenLeistungArtID={KundenLeistungArtID})")]
    public SingleResult<KundenLeistungArten> GetKundenLeistungArten(int key)
    {
        var items = this.context.KundenLeistungArtens.Where(i=>i.KundenLeistungArtID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungArtenGet(ref result);

        return result;
    }
    partial void OnKundenLeistungArtenDeleted(Models.DbSinDarEla.KundenLeistungArten item);
    partial void OnAfterKundenLeistungArtenDeleted(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungArtens(KundenLeistungArtID={KundenLeistungArtID})")]
    public IActionResult DeleteKundenLeistungArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungArtens
                .Where(i => i.KundenLeistungArtID == key)
                .Include(i => i.AbrechnungKundenReststundens)
                .Include(i => i.Ereignisses)
                .Include(i => i.KundenLeistungens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungArtenDeleted(item);
            this.context.KundenLeistungArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungArtenUpdated(Models.DbSinDarEla.KundenLeistungArten item);
    partial void OnAfterKundenLeistungArtenUpdated(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungArtens(KundenLeistungArtID={KundenLeistungArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungArten(int key, [FromBody]Models.DbSinDarEla.KundenLeistungArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungArtenUpdated(newItem);
            this.context.KundenLeistungArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key);
            this.OnAfterKundenLeistungArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungArtens(KundenLeistungArtID={KundenLeistungArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungArtenUpdated(item);
            this.context.KundenLeistungArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungArtenCreated(Models.DbSinDarEla.KundenLeistungArten item);
    partial void OnAfterKundenLeistungArtenCreated(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungArten item)
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

            this.OnKundenLeistungArtenCreated(item);
            this.context.KundenLeistungArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterKundenLeistungArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/KundenLeistungArtens/{item.KundenLeistungArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
