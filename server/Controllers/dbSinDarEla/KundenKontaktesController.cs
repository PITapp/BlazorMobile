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

  [Route("odata/dbSinDarEla/KundenKontaktes")]
  public partial class KundenKontaktesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenKontaktesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenKontakte> GetKundenKontaktes()
    {
      var items = this.context.KundenKontaktes.AsQueryable<Models.DbSinDarEla.KundenKontakte>();
      this.OnKundenKontaktesRead(ref items);

      return items;
    }

    partial void OnKundenKontaktesRead(ref IQueryable<Models.DbSinDarEla.KundenKontakte> items);

    partial void OnKundenKontakteGet(ref SingleResult<Models.DbSinDarEla.KundenKontakte> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenKontaktes(KundenKontaktID={KundenKontaktID})")]
    public SingleResult<KundenKontakte> GetKundenKontakte(int key)
    {
        var items = this.context.KundenKontaktes.Where(i=>i.KundenKontaktID == key);
        var result = SingleResult.Create(items);

        OnKundenKontakteGet(ref result);

        return result;
    }
    partial void OnKundenKontakteDeleted(Models.DbSinDarEla.KundenKontakte item);
    partial void OnAfterKundenKontakteDeleted(Models.DbSinDarEla.KundenKontakte item);

    [HttpDelete("/odata/dbSinDarEla/KundenKontaktes(KundenKontaktID={KundenKontaktID})")]
    public IActionResult DeleteKundenKontakte(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenKontaktes
                .Where(i => i.KundenKontaktID == key)
                .Include(i => i.KundenLeistungenBescheides)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenKontakteDeleted(item);
            this.context.KundenKontaktes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenKontakteDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteUpdated(Models.DbSinDarEla.KundenKontakte item);
    partial void OnAfterKundenKontakteUpdated(Models.DbSinDarEla.KundenKontakte item);

    [HttpPut("/odata/dbSinDarEla/KundenKontaktes(KundenKontaktID={KundenKontaktID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenKontakte(int key, [FromBody]Models.DbSinDarEla.KundenKontakte newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenKontaktID != key))
            {
                return BadRequest();
            }

            this.OnKundenKontakteUpdated(newItem);
            this.context.KundenKontaktes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenKontakteArten");
            this.OnAfterKundenKontakteUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenKontaktes(KundenKontaktID={KundenKontaktID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenKontakte(int key, [FromBody]Delta<Models.DbSinDarEla.KundenKontakte> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenKontakteUpdated(item);
            this.context.KundenKontaktes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenKontakteArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteCreated(Models.DbSinDarEla.KundenKontakte item);
    partial void OnAfterKundenKontakteCreated(Models.DbSinDarEla.KundenKontakte item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenKontakte item)
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

            this.OnKundenKontakteCreated(item);
            this.context.KundenKontaktes.Add(item);
            this.context.SaveChanges();

            var key = item.KundenKontaktID;

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenKontakteArten");

            this.OnAfterKundenKontakteCreated(item);

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
