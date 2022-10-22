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

  [Route("odata/dbSinDarEla/KundenLeistungenBescheides")]
  public partial class KundenLeistungenBescheidesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungenBescheidesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBescheides
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBescheide> GetKundenLeistungenBescheides()
    {
      var items = this.context.KundenLeistungenBescheides.AsQueryable<Models.DbSinDarEla.KundenLeistungenBescheide>();
      this.OnKundenLeistungenBescheidesRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBescheidesRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheide> items);

    partial void OnKundenLeistungenBescheideGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungenBescheide> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungenBescheides(KundenLeistungenBescheidID={KundenLeistungenBescheidID})")]
    public SingleResult<KundenLeistungenBescheide> GetKundenLeistungenBescheide(int key)
    {
        var items = this.context.KundenLeistungenBescheides.Where(i=>i.KundenLeistungenBescheidID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungenBescheideGet(ref result);

        return result;
    }
    partial void OnKundenLeistungenBescheideDeleted(Models.DbSinDarEla.KundenLeistungenBescheide item);
    partial void OnAfterKundenLeistungenBescheideDeleted(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungenBescheides(KundenLeistungenBescheidID={KundenLeistungenBescheidID})")]
    public IActionResult DeleteKundenLeistungenBescheide(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungenBescheides
                .Where(i => i.KundenLeistungenBescheidID == key)
                .Include(i => i.KundenLeistungenBescheideKontingentes)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideDeleted(item);
            this.context.KundenLeistungenBescheides.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungenBescheideDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideUpdated(Models.DbSinDarEla.KundenLeistungenBescheide item);
    partial void OnAfterKundenLeistungenBescheideUpdated(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungenBescheides(KundenLeistungenBescheidID={KundenLeistungenBescheidID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBescheide(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBescheide newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBescheidID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideUpdated(newItem);
            this.context.KundenLeistungenBescheides.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");
            this.OnAfterKundenLeistungenBescheideUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungenBescheides(KundenLeistungenBescheidID={KundenLeistungenBescheidID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBescheide(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBescheide> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungenBescheideUpdated(item);
            this.context.KundenLeistungenBescheides.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideCreated(Models.DbSinDarEla.KundenLeistungenBescheide item);
    partial void OnAfterKundenLeistungenBescheideCreated(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBescheide item)
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

            this.OnKundenLeistungenBescheideCreated(item);
            this.context.KundenLeistungenBescheides.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBescheidID;

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");

            this.OnAfterKundenLeistungenBescheideCreated(item);

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
