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

  [Route("odata/dbSinDarEla/KundenLeistungenBetreuers")]
  public partial class KundenLeistungenBetreuersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungenBetreuersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBetreuer> GetKundenLeistungenBetreuers()
    {
      var items = this.context.KundenLeistungenBetreuers.AsQueryable<Models.DbSinDarEla.KundenLeistungenBetreuer>();
      this.OnKundenLeistungenBetreuersRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBetreuersRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuer> items);

    partial void OnKundenLeistungenBetreuerGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungenBetreuer> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungenBetreuers(KundenLeistungenBetreuerID={KundenLeistungenBetreuerID})")]
    public SingleResult<KundenLeistungenBetreuer> GetKundenLeistungenBetreuer(int key)
    {
        var items = this.context.KundenLeistungenBetreuers.Where(i=>i.KundenLeistungenBetreuerID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungenBetreuerGet(ref result);

        return result;
    }
    partial void OnKundenLeistungenBetreuerDeleted(Models.DbSinDarEla.KundenLeistungenBetreuer item);
    partial void OnAfterKundenLeistungenBetreuerDeleted(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungenBetreuers(KundenLeistungenBetreuerID={KundenLeistungenBetreuerID})")]
    public IActionResult DeleteKundenLeistungenBetreuer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungenBetreuers
                .Where(i => i.KundenLeistungenBetreuerID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerDeleted(item);
            this.context.KundenLeistungenBetreuers.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungenBetreuerDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerUpdated(Models.DbSinDarEla.KundenLeistungenBetreuer item);
    partial void OnAfterKundenLeistungenBetreuerUpdated(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungenBetreuers(KundenLeistungenBetreuerID={KundenLeistungenBetreuerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBetreuer(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBetreuer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBetreuerID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerUpdated(newItem);
            this.context.KundenLeistungenBetreuers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");
            this.OnAfterKundenLeistungenBetreuerUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungenBetreuers(KundenLeistungenBetreuerID={KundenLeistungenBetreuerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBetreuer(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBetreuer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungenBetreuerUpdated(item);
            this.context.KundenLeistungenBetreuers.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerCreated(Models.DbSinDarEla.KundenLeistungenBetreuer item);
    partial void OnAfterKundenLeistungenBetreuerCreated(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBetreuer item)
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

            this.OnKundenLeistungenBetreuerCreated(item);
            this.context.KundenLeistungenBetreuers.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBetreuerID;

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");

            this.OnAfterKundenLeistungenBetreuerCreated(item);

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
