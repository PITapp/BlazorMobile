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

  [Route("odata/dbSinDarEla/MitarbeiterTaetigkeitens")]
  public partial class MitarbeiterTaetigkeitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterTaetigkeitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterTaetigkeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterTaetigkeiten> GetMitarbeiterTaetigkeitens()
    {
      var items = this.context.MitarbeiterTaetigkeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeiten>();
      this.OnMitarbeiterTaetigkeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterTaetigkeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeiten> items);

    partial void OnMitarbeiterTaetigkeitenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterTaetigkeiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterTaetigkeitens(MitarbeiterTaetigkeitenID={MitarbeiterTaetigkeitenID})")]
    public SingleResult<MitarbeiterTaetigkeiten> GetMitarbeiterTaetigkeiten(int key)
    {
        var items = this.context.MitarbeiterTaetigkeitens.Where(i=>i.MitarbeiterTaetigkeitenID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterTaetigkeitenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterTaetigkeitenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);
    partial void OnAfterMitarbeiterTaetigkeitenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterTaetigkeitens(MitarbeiterTaetigkeitenID={MitarbeiterTaetigkeitenID})")]
    public IActionResult DeleteMitarbeiterTaetigkeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterTaetigkeitens
                .Where(i => i.MitarbeiterTaetigkeitenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenDeleted(item);
            this.context.MitarbeiterTaetigkeitens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterTaetigkeitenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);
    partial void OnAfterMitarbeiterTaetigkeitenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterTaetigkeitens(MitarbeiterTaetigkeitenID={MitarbeiterTaetigkeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterTaetigkeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterTaetigkeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterTaetigkeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenUpdated(newItem);
            this.context.MitarbeiterTaetigkeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");
            this.OnAfterMitarbeiterTaetigkeitenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterTaetigkeitens(MitarbeiterTaetigkeitenID={MitarbeiterTaetigkeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterTaetigkeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterTaetigkeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterTaetigkeitenUpdated(item);
            this.context.MitarbeiterTaetigkeitens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);
    partial void OnAfterMitarbeiterTaetigkeitenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterTaetigkeiten item)
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

            this.OnMitarbeiterTaetigkeitenCreated(item);
            this.context.MitarbeiterTaetigkeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterTaetigkeitenID;

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");

            this.OnAfterMitarbeiterTaetigkeitenCreated(item);

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
