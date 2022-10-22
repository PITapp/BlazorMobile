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

  [Route("odata/dbSinDarEla/DokumenteKategoriens")]
  public partial class DokumenteKategoriensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public DokumenteKategoriensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/DokumenteKategoriens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.DokumenteKategorien> GetDokumenteKategoriens()
    {
      var items = this.context.DokumenteKategoriens.AsQueryable<Models.DbSinDarEla.DokumenteKategorien>();
      this.OnDokumenteKategoriensRead(ref items);

      return items;
    }

    partial void OnDokumenteKategoriensRead(ref IQueryable<Models.DbSinDarEla.DokumenteKategorien> items);

    partial void OnDokumenteKategorienGet(ref SingleResult<Models.DbSinDarEla.DokumenteKategorien> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/DokumenteKategoriens(DokumenteKategorieID={DokumenteKategorieID})")]
    public SingleResult<DokumenteKategorien> GetDokumenteKategorien(int key)
    {
        var items = this.context.DokumenteKategoriens.Where(i=>i.DokumenteKategorieID == key);
        var result = SingleResult.Create(items);

        OnDokumenteKategorienGet(ref result);

        return result;
    }
    partial void OnDokumenteKategorienDeleted(Models.DbSinDarEla.DokumenteKategorien item);
    partial void OnAfterDokumenteKategorienDeleted(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpDelete("/odata/dbSinDarEla/DokumenteKategoriens(DokumenteKategorieID={DokumenteKategorieID})")]
    public IActionResult DeleteDokumenteKategorien(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.DokumenteKategoriens
                .Where(i => i.DokumenteKategorieID == key)
                .Include(i => i.Dokumentes)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDokumenteKategorienDeleted(item);
            this.context.DokumenteKategoriens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDokumenteKategorienDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteKategorienUpdated(Models.DbSinDarEla.DokumenteKategorien item);
    partial void OnAfterDokumenteKategorienUpdated(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpPut("/odata/dbSinDarEla/DokumenteKategoriens(DokumenteKategorieID={DokumenteKategorieID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDokumenteKategorien(int key, [FromBody]Models.DbSinDarEla.DokumenteKategorien newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DokumenteKategorieID != key))
            {
                return BadRequest();
            }

            this.OnDokumenteKategorienUpdated(newItem);
            this.context.DokumenteKategoriens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key);
            this.OnAfterDokumenteKategorienUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/DokumenteKategoriens(DokumenteKategorieID={DokumenteKategorieID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDokumenteKategorien(int key, [FromBody]Delta<Models.DbSinDarEla.DokumenteKategorien> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDokumenteKategorienUpdated(item);
            this.context.DokumenteKategoriens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteKategorienCreated(Models.DbSinDarEla.DokumenteKategorien item);
    partial void OnAfterDokumenteKategorienCreated(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.DokumenteKategorien item)
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

            this.OnDokumenteKategorienCreated(item);
            this.context.DokumenteKategoriens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterDokumenteKategorienCreated(item);
            
            return Created($"odata/DbSinDarEla/DokumenteKategoriens/{item.DokumenteKategorieID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
