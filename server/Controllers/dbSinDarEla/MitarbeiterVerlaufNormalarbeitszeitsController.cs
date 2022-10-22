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

  [Route("odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits")]
  public partial class MitarbeiterVerlaufNormalarbeitszeitsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufNormalarbeitszeitsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> GetMitarbeiterVerlaufNormalarbeitszeits()
    {
      var items = this.context.MitarbeiterVerlaufNormalarbeitszeits.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>();
      this.OnMitarbeiterVerlaufNormalarbeitszeitsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> items);

    partial void OnMitarbeiterVerlaufNormalarbeitszeitGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits(MitarbeiterVerlaufNormalarbeitszeitID={MitarbeiterVerlaufNormalarbeitszeitID})")]
    public SingleResult<MitarbeiterVerlaufNormalarbeitszeit> GetMitarbeiterVerlaufNormalarbeitszeit(int key)
    {
        var items = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i=>i.MitarbeiterVerlaufNormalarbeitszeitID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterVerlaufNormalarbeitszeitGet(ref result);

        return result;
    }
    partial void OnMitarbeiterVerlaufNormalarbeitszeitDeleted(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);
    partial void OnAfterMitarbeiterVerlaufNormalarbeitszeitDeleted(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits(MitarbeiterVerlaufNormalarbeitszeitID={MitarbeiterVerlaufNormalarbeitszeitID})")]
    public IActionResult DeleteMitarbeiterVerlaufNormalarbeitszeit(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterVerlaufNormalarbeitszeits
                .Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufNormalarbeitszeitDeleted(item);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterVerlaufNormalarbeitszeitDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitUpdated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);
    partial void OnAfterMitarbeiterVerlaufNormalarbeitszeitUpdated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits(MitarbeiterVerlaufNormalarbeitszeitID={MitarbeiterVerlaufNormalarbeitszeitID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufNormalarbeitszeit(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufNormalarbeitszeitID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufNormalarbeitszeitUpdated(newItem);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            this.OnAfterMitarbeiterVerlaufNormalarbeitszeitUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits(MitarbeiterVerlaufNormalarbeitszeitID={MitarbeiterVerlaufNormalarbeitszeitID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufNormalarbeitszeit(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterVerlaufNormalarbeitszeitUpdated(item);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitCreated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);
    partial void OnAfterMitarbeiterVerlaufNormalarbeitszeitCreated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item)
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

            this.OnMitarbeiterVerlaufNormalarbeitszeitCreated(item);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufNormalarbeitszeitID;

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");

            this.OnAfterMitarbeiterVerlaufNormalarbeitszeitCreated(item);

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
