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

  [Route("odata/dbSinDarEla/KundenLeistungenBescheideKontingentes")]
  public partial class KundenLeistungenBescheideKontingentesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public KundenLeistungenBescheideKontingentesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBescheideKontingentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> GetKundenLeistungenBescheideKontingentes()
    {
      var items = this.context.KundenLeistungenBescheideKontingentes.AsQueryable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente>();
      this.OnKundenLeistungenBescheideKontingentesRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBescheideKontingentesRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> items);

    partial void OnKundenLeistungenBescheideKontingenteGet(ref SingleResult<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/KundenLeistungenBescheideKontingentes(KundenLeistungenBescheideKontingentID={KundenLeistungenBescheideKontingentID})")]
    public SingleResult<KundenLeistungenBescheideKontingente> GetKundenLeistungenBescheideKontingente(int key)
    {
        var items = this.context.KundenLeistungenBescheideKontingentes.Where(i=>i.KundenLeistungenBescheideKontingentID == key);
        var result = SingleResult.Create(items);

        OnKundenLeistungenBescheideKontingenteGet(ref result);

        return result;
    }
    partial void OnKundenLeistungenBescheideKontingenteDeleted(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);
    partial void OnAfterKundenLeistungenBescheideKontingenteDeleted(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpDelete("/odata/dbSinDarEla/KundenLeistungenBescheideKontingentes(KundenLeistungenBescheideKontingentID={KundenLeistungenBescheideKontingentID})")]
    public IActionResult DeleteKundenLeistungenBescheideKontingente(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.KundenLeistungenBescheideKontingentes
                .Where(i => i.KundenLeistungenBescheideKontingentID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideKontingenteDeleted(item);
            this.context.KundenLeistungenBescheideKontingentes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKundenLeistungenBescheideKontingenteDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideKontingenteUpdated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);
    partial void OnAfterKundenLeistungenBescheideKontingenteUpdated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpPut("/odata/dbSinDarEla/KundenLeistungenBescheideKontingentes(KundenLeistungenBescheideKontingentID={KundenLeistungenBescheideKontingentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBescheideKontingente(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBescheideKontingente newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBescheideKontingentID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideKontingenteUpdated(newItem);
            this.context.KundenLeistungenBescheideKontingentes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");
            this.OnAfterKundenLeistungenBescheideKontingenteUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/KundenLeistungenBescheideKontingentes(KundenLeistungenBescheideKontingentID={KundenLeistungenBescheideKontingentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBescheideKontingente(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnKundenLeistungenBescheideKontingenteUpdated(item);
            this.context.KundenLeistungenBescheideKontingentes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideKontingenteCreated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);
    partial void OnAfterKundenLeistungenBescheideKontingenteCreated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBescheideKontingente item)
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

            this.OnKundenLeistungenBescheideKontingenteCreated(item);
            this.context.KundenLeistungenBescheideKontingentes.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBescheideKontingentID;

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");

            this.OnAfterKundenLeistungenBescheideKontingenteCreated(item);

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
