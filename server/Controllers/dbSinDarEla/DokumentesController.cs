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

  [Route("odata/dbSinDarEla/Dokumentes")]
  public partial class DokumentesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public DokumentesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Dokumentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Dokumente> GetDokumentes()
    {
      var items = this.context.Dokumentes.AsQueryable<Models.DbSinDarEla.Dokumente>();
      this.OnDokumentesRead(ref items);

      return items;
    }

    partial void OnDokumentesRead(ref IQueryable<Models.DbSinDarEla.Dokumente> items);

    partial void OnDokumenteGet(ref SingleResult<Models.DbSinDarEla.Dokumente> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Dokumentes(DokumentID={DokumentID})")]
    public SingleResult<Dokumente> GetDokumente(int key)
    {
        var items = this.context.Dokumentes.Where(i=>i.DokumentID == key);
        var result = SingleResult.Create(items);

        OnDokumenteGet(ref result);

        return result;
    }
    partial void OnDokumenteDeleted(Models.DbSinDarEla.Dokumente item);
    partial void OnAfterDokumenteDeleted(Models.DbSinDarEla.Dokumente item);

    [HttpDelete("/odata/dbSinDarEla/Dokumentes(DokumentID={DokumentID})")]
    public IActionResult DeleteDokumente(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Dokumentes
                .Where(i => i.DokumentID == key)
                .Include(i => i.MitarbeiterFortbildungens)
                .Include(i => i.Mitteilungens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDokumenteDeleted(item);
            this.context.Dokumentes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDokumenteDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteUpdated(Models.DbSinDarEla.Dokumente item);
    partial void OnAfterDokumenteUpdated(Models.DbSinDarEla.Dokumente item);

    [HttpPut("/odata/dbSinDarEla/Dokumentes(DokumentID={DokumentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDokumente(int key, [FromBody]Models.DbSinDarEla.Dokumente newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DokumentID != key))
            {
                return BadRequest();
            }

            this.OnDokumenteUpdated(newItem);
            this.context.Dokumentes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien");
            this.OnAfterDokumenteUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Dokumentes(DokumentID={DokumentID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDokumente(int key, [FromBody]Delta<Models.DbSinDarEla.Dokumente> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Dokumentes.Where(i => i.DokumentID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDokumenteUpdated(item);
            this.context.Dokumentes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteCreated(Models.DbSinDarEla.Dokumente item);
    partial void OnAfterDokumenteCreated(Models.DbSinDarEla.Dokumente item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Dokumente item)
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

            this.OnDokumenteCreated(item);
            this.context.Dokumentes.Add(item);
            this.context.SaveChanges();

            var key = item.DokumentID;

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien");

            this.OnAfterDokumenteCreated(item);

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
