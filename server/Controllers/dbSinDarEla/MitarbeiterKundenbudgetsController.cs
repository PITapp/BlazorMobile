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

  [Route("odata/dbSinDarEla/MitarbeiterKundenbudgets")]
  public partial class MitarbeiterKundenbudgetsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterKundenbudgetsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterKundenbudgets
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterKundenbudget> GetMitarbeiterKundenbudgets()
    {
      var items = this.context.MitarbeiterKundenbudgets.AsQueryable<Models.DbSinDarEla.MitarbeiterKundenbudget>();
      this.OnMitarbeiterKundenbudgetsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterKundenbudgetsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudget> items);

    partial void OnMitarbeiterKundenbudgetGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterKundenbudget> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterKundenbudgets(MitarbeiterKundenbudgetID={MitarbeiterKundenbudgetID})")]
    public SingleResult<MitarbeiterKundenbudget> GetMitarbeiterKundenbudget(int key)
    {
        var items = this.context.MitarbeiterKundenbudgets.Where(i=>i.MitarbeiterKundenbudgetID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterKundenbudgetGet(ref result);

        return result;
    }
    partial void OnMitarbeiterKundenbudgetDeleted(Models.DbSinDarEla.MitarbeiterKundenbudget item);
    partial void OnAfterMitarbeiterKundenbudgetDeleted(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterKundenbudgets(MitarbeiterKundenbudgetID={MitarbeiterKundenbudgetID})")]
    public IActionResult DeleteMitarbeiterKundenbudget(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterKundenbudgets
                .Where(i => i.MitarbeiterKundenbudgetID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetDeleted(item);
            this.context.MitarbeiterKundenbudgets.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterKundenbudgetDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetUpdated(Models.DbSinDarEla.MitarbeiterKundenbudget item);
    partial void OnAfterMitarbeiterKundenbudgetUpdated(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterKundenbudgets(MitarbeiterKundenbudgetID={MitarbeiterKundenbudgetID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterKundenbudget(int key, [FromBody]Models.DbSinDarEla.MitarbeiterKundenbudget newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterKundenbudgetID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetUpdated(newItem);
            this.context.MitarbeiterKundenbudgets.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");
            this.OnAfterMitarbeiterKundenbudgetUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterKundenbudgets(MitarbeiterKundenbudgetID={MitarbeiterKundenbudgetID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterKundenbudget(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterKundenbudget> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterKundenbudgetUpdated(item);
            this.context.MitarbeiterKundenbudgets.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetCreated(Models.DbSinDarEla.MitarbeiterKundenbudget item);
    partial void OnAfterMitarbeiterKundenbudgetCreated(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterKundenbudget item)
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

            this.OnMitarbeiterKundenbudgetCreated(item);
            this.context.MitarbeiterKundenbudgets.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterKundenbudgetID;

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");

            this.OnAfterMitarbeiterKundenbudgetCreated(item);

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
