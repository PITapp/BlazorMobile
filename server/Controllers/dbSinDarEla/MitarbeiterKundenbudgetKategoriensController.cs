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

  [Route("odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens")]
  public partial class MitarbeiterKundenbudgetKategoriensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterKundenbudgetKategoriensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterKundenbudgetKategoriens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> GetMitarbeiterKundenbudgetKategoriens()
    {
      var items = this.context.MitarbeiterKundenbudgetKategoriens.AsQueryable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>();
      this.OnMitarbeiterKundenbudgetKategoriensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterKundenbudgetKategoriensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> items);

    partial void OnMitarbeiterKundenbudgetKategorienGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens(KundenbudgetKategorieID={KundenbudgetKategorieID})")]
    public SingleResult<MitarbeiterKundenbudgetKategorien> GetMitarbeiterKundenbudgetKategorien(int key)
    {
        var items = this.context.MitarbeiterKundenbudgetKategoriens.Where(i=>i.KundenbudgetKategorieID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterKundenbudgetKategorienGet(ref result);

        return result;
    }
    partial void OnMitarbeiterKundenbudgetKategorienDeleted(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);
    partial void OnAfterMitarbeiterKundenbudgetKategorienDeleted(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens(KundenbudgetKategorieID={KundenbudgetKategorieID})")]
    public IActionResult DeleteMitarbeiterKundenbudgetKategorien(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterKundenbudgetKategoriens
                .Where(i => i.KundenbudgetKategorieID == key)
                .Include(i => i.MitarbeiterKundenbudgets)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetKategorienDeleted(item);
            this.context.MitarbeiterKundenbudgetKategoriens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterKundenbudgetKategorienDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetKategorienUpdated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);
    partial void OnAfterMitarbeiterKundenbudgetKategorienUpdated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens(KundenbudgetKategorieID={KundenbudgetKategorieID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterKundenbudgetKategorien(int key, [FromBody]Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenbudgetKategorieID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetKategorienUpdated(newItem);
            this.context.MitarbeiterKundenbudgetKategoriens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key);
            this.OnAfterMitarbeiterKundenbudgetKategorienUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens(KundenbudgetKategorieID={KundenbudgetKategorieID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterKundenbudgetKategorien(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterKundenbudgetKategorienUpdated(item);
            this.context.MitarbeiterKundenbudgetKategoriens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetKategorienCreated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);
    partial void OnAfterMitarbeiterKundenbudgetKategorienCreated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item)
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

            this.OnMitarbeiterKundenbudgetKategorienCreated(item);
            this.context.MitarbeiterKundenbudgetKategoriens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterKundenbudgetKategorienCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterKundenbudgetKategoriens/{item.KundenbudgetKategorieID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
