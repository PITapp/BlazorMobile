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

  [Route("odata/dbSinDarEla/Kundens")]
  public partial class KundensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Kundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Kunden> GetKundens()
    {
      var items = this.context.Kundens.AsQueryable<Models.DbSinDarEla.Kunden>();
      this.OnKundensRead(ref items);

      return items;
    }

    partial void OnKundensRead(ref IQueryable<Models.DbSinDarEla.Kunden> items);

    partial void OnKundenGet(ref SingleResult<Models.DbSinDarEla.Kunden> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Kundens(KundenID={KundenID})")]
    public SingleResult<Kunden> GetKunden(int key)
    {
        var items = this.context.Kundens.Where(i=>i.KundenID == key);
        var result = SingleResult.Create(items);

        OnKundenGet(ref result);

        return result;
    }
    partial void OnKundenDeleted(Models.DbSinDarEla.Kunden item);
    partial void OnAfterKundenDeleted(Models.DbSinDarEla.Kunden item);

    [HttpDelete("/odata/dbSinDarEla/Kundens(KundenID={KundenID})")]
    public IActionResult DeleteKunden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Kundens
                .Where(i => i.KundenID == key)
                .Include(i => i.AbrechnungKundenReststundens)
                .Include(i => i.Ereignisses)
                .Include(i => i.KundenKontaktes)
                .Include(i => i.KundenLeistungens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenDeleted(item);
            this.context.Kundens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenUpdated(Models.DbSinDarEla.Kunden item);
    partial void OnAfterKundenUpdated(Models.DbSinDarEla.Kunden item);

    [HttpPut("/odata/dbSinDarEla/Kundens(KundenID={KundenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKunden(int key, [FromBody]Models.DbSinDarEla.Kunden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenID != key))
            {
                return BadRequest();
            }

            this.OnKundenUpdated(newItem);
            this.context.Kundens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");
            this.OnAfterKundenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Kundens(KundenID={KundenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKunden(int key, [FromBody]Delta<Models.DbSinDarEla.Kunden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Kundens.Where(i => i.KundenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenUpdated(item);
            this.context.Kundens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenCreated(Models.DbSinDarEla.Kunden item);
    partial void OnAfterKundenCreated(Models.DbSinDarEla.Kunden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Kunden item)
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

            this.OnKundenCreated(item);
            this.context.Kundens.Add(item);
            this.context.SaveChanges();

            var key = item.KundenID;

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");

            this.OnAfterKundenCreated(item);

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
