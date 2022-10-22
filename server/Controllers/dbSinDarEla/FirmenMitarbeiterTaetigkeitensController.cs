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

  [Route("odata/dbSinDarEla/FirmenMitarbeiterTaetigkeitens")]
  public partial class FirmenMitarbeiterTaetigkeitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public FirmenMitarbeiterTaetigkeitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/FirmenMitarbeiterTaetigkeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> GetFirmenMitarbeiterTaetigkeitens()
    {
      var items = this.context.FirmenMitarbeiterTaetigkeitens.AsQueryable<Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten>();
      this.OnFirmenMitarbeiterTaetigkeitensRead(ref items);

      return items;
    }

    partial void OnFirmenMitarbeiterTaetigkeitensRead(ref IQueryable<Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> items);

    partial void OnFirmenMitarbeiterTaetigkeitenGet(ref SingleResult<Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/FirmenMitarbeiterTaetigkeitens(FirmenMitarbeiterTaetigkeitenID={FirmenMitarbeiterTaetigkeitenID})")]
    public SingleResult<FirmenMitarbeiterTaetigkeiten> GetFirmenMitarbeiterTaetigkeiten(int key)
    {
        var items = this.context.FirmenMitarbeiterTaetigkeitens.Where(i=>i.FirmenMitarbeiterTaetigkeitenID == key);
        var result = SingleResult.Create(items);

        OnFirmenMitarbeiterTaetigkeitenGet(ref result);

        return result;
    }
    partial void OnFirmenMitarbeiterTaetigkeitenDeleted(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);
    partial void OnAfterFirmenMitarbeiterTaetigkeitenDeleted(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);

    [HttpDelete("/odata/dbSinDarEla/FirmenMitarbeiterTaetigkeitens(FirmenMitarbeiterTaetigkeitenID={FirmenMitarbeiterTaetigkeitenID})")]
    public IActionResult DeleteFirmenMitarbeiterTaetigkeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.FirmenMitarbeiterTaetigkeitens
                .Where(i => i.FirmenMitarbeiterTaetigkeitenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnFirmenMitarbeiterTaetigkeitenDeleted(item);
            this.context.FirmenMitarbeiterTaetigkeitens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterFirmenMitarbeiterTaetigkeitenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFirmenMitarbeiterTaetigkeitenUpdated(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);
    partial void OnAfterFirmenMitarbeiterTaetigkeitenUpdated(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);

    [HttpPut("/odata/dbSinDarEla/FirmenMitarbeiterTaetigkeitens(FirmenMitarbeiterTaetigkeitenID={FirmenMitarbeiterTaetigkeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutFirmenMitarbeiterTaetigkeiten(int key, [FromBody]Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FirmenMitarbeiterTaetigkeitenID != key))
            {
                return BadRequest();
            }

            this.OnFirmenMitarbeiterTaetigkeitenUpdated(newItem);
            this.context.FirmenMitarbeiterTaetigkeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.FirmenMitarbeiterTaetigkeitens.Where(i => i.FirmenMitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,MitarbeiterTaetigkeitenArten");
            this.OnAfterFirmenMitarbeiterTaetigkeitenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/FirmenMitarbeiterTaetigkeitens(FirmenMitarbeiterTaetigkeitenID={FirmenMitarbeiterTaetigkeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchFirmenMitarbeiterTaetigkeiten(int key, [FromBody]Delta<Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.FirmenMitarbeiterTaetigkeitens.Where(i => i.FirmenMitarbeiterTaetigkeitenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnFirmenMitarbeiterTaetigkeitenUpdated(item);
            this.context.FirmenMitarbeiterTaetigkeitens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.FirmenMitarbeiterTaetigkeitens.Where(i => i.FirmenMitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,MitarbeiterTaetigkeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFirmenMitarbeiterTaetigkeitenCreated(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);
    partial void OnAfterFirmenMitarbeiterTaetigkeitenCreated(Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.FirmenMitarbeiterTaetigkeiten item)
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

            this.OnFirmenMitarbeiterTaetigkeitenCreated(item);
            this.context.FirmenMitarbeiterTaetigkeitens.Add(item);
            this.context.SaveChanges();

            var key = item.FirmenMitarbeiterTaetigkeitenID;

            var itemToReturn = this.context.FirmenMitarbeiterTaetigkeitens.Where(i => i.FirmenMitarbeiterTaetigkeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,MitarbeiterTaetigkeitenArten");

            this.OnAfterFirmenMitarbeiterTaetigkeitenCreated(item);

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
