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

  [Route("odata/dbSinDarEla/MitarbeiterVerlaufGehalts")]
  public partial class MitarbeiterVerlaufGehaltsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufGehaltsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufGehalts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> GetMitarbeiterVerlaufGehalts()
    {
      var items = this.context.MitarbeiterVerlaufGehalts.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt>();
      this.OnMitarbeiterVerlaufGehaltsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufGehaltsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> items);

    partial void OnMitarbeiterVerlaufGehaltGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterVerlaufGehalts(MitarbeiterVerlaufGehaltID={MitarbeiterVerlaufGehaltID})")]
    public SingleResult<MitarbeiterVerlaufGehalt> GetMitarbeiterVerlaufGehalt(int key)
    {
        var items = this.context.MitarbeiterVerlaufGehalts.Where(i=>i.MitarbeiterVerlaufGehaltID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterVerlaufGehaltGet(ref result);

        return result;
    }
    partial void OnMitarbeiterVerlaufGehaltDeleted(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);
    partial void OnAfterMitarbeiterVerlaufGehaltDeleted(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterVerlaufGehalts(MitarbeiterVerlaufGehaltID={MitarbeiterVerlaufGehaltID})")]
    public IActionResult DeleteMitarbeiterVerlaufGehalt(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterVerlaufGehalts
                .Where(i => i.MitarbeiterVerlaufGehaltID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufGehaltDeleted(item);
            this.context.MitarbeiterVerlaufGehalts.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterVerlaufGehaltDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufGehaltUpdated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);
    partial void OnAfterMitarbeiterVerlaufGehaltUpdated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterVerlaufGehalts(MitarbeiterVerlaufGehaltID={MitarbeiterVerlaufGehaltID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufGehalt(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufGehalt newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufGehaltID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufGehaltUpdated(newItem);
            this.context.MitarbeiterVerlaufGehalts.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            this.OnAfterMitarbeiterVerlaufGehaltUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterVerlaufGehalts(MitarbeiterVerlaufGehaltID={MitarbeiterVerlaufGehaltID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufGehalt(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterVerlaufGehaltUpdated(item);
            this.context.MitarbeiterVerlaufGehalts.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufGehaltCreated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);
    partial void OnAfterMitarbeiterVerlaufGehaltCreated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufGehalt item)
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

            this.OnMitarbeiterVerlaufGehaltCreated(item);
            this.context.MitarbeiterVerlaufGehalts.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufGehaltID;

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");

            this.OnAfterMitarbeiterVerlaufGehaltCreated(item);

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
