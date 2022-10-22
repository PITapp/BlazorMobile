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

  [Route("odata/dbSinDarEla/KundenLeistungens")]
  public partial class KundenLeistungensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungen> GetKundenLeistungens()
    {
      var items = this.context.KundenLeistungens.AsQueryable<Models.DbSinDarEla.KundenLeistungen>();
      this.OnKundenLeistungensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungen> items);

    partial void OnKundenLeistungenGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungens(KundenLeistungID={KundenLeistungID})")]
    public SingleResult<KundenLeistungen> GetKundenLeistungen(int key)
    {
        var items = this.context.KundenLeistungens.Where(i=>i.KundenLeistungID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungenGet(ref result);

        return result;
    }
    partial void OnKundenLeistungenDeleted(Models.DbSinDarEla.KundenLeistungen item);
    partial void OnAfterKundenLeistungenDeleted(Models.DbSinDarEla.KundenLeistungen item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungens(KundenLeistungID={KundenLeistungID})")]
    public IActionResult DeleteKundenLeistungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungens
                .Where(i => i.KundenLeistungID == key)
                .Include(i => i.KundenLeistungenBescheides)
                .Include(i => i.KundenLeistungenBetreuers)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungenDeleted(item);
            this.context.KundenLeistungens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenUpdated(Models.DbSinDarEla.KundenLeistungen item);
    partial void OnAfterKundenLeistungenUpdated(Models.DbSinDarEla.KundenLeistungen item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungens(KundenLeistungID={KundenLeistungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungen(int key, [FromBody]Models.DbSinDarEla.KundenLeistungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenUpdated(newItem);
            this.context.KundenLeistungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            this.OnAfterKundenLeistungenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungens(KundenLeistungID={KundenLeistungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungen(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungenUpdated(item);
            this.context.KundenLeistungens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenCreated(Models.DbSinDarEla.KundenLeistungen item);
    partial void OnAfterKundenLeistungenCreated(Models.DbSinDarEla.KundenLeistungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungen item)
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

            this.OnKundenLeistungenCreated(item);
            this.context.KundenLeistungens.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungID;

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");

            this.OnAfterKundenLeistungenCreated(item);

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
