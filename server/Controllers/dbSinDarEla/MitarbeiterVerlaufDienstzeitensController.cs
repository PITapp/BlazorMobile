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

  [Route("odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens")]
  public partial class MitarbeiterVerlaufDienstzeitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufDienstzeitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> GetMitarbeiterVerlaufDienstzeitens()
    {
      var items = this.context.MitarbeiterVerlaufDienstzeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>();
      this.OnMitarbeiterVerlaufDienstzeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufDienstzeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> items);

    partial void OnMitarbeiterVerlaufDienstzeitenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens(MitarbeiterVerlaufDienstzeitenID={MitarbeiterVerlaufDienstzeitenID})")]
    public SingleResult<MitarbeiterVerlaufDienstzeiten> GetMitarbeiterVerlaufDienstzeiten(int key)
    {
        var items = this.context.MitarbeiterVerlaufDienstzeitens.Where(i=>i.MitarbeiterVerlaufDienstzeitenID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterVerlaufDienstzeitenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterVerlaufDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens(MitarbeiterVerlaufDienstzeitenID={MitarbeiterVerlaufDienstzeitenID})")]
    public IActionResult DeleteMitarbeiterVerlaufDienstzeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterVerlaufDienstzeitens
                .Where(i => i.MitarbeiterVerlaufDienstzeitenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenDeleted(item);
            this.context.MitarbeiterVerlaufDienstzeitens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterVerlaufDienstzeitenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens(MitarbeiterVerlaufDienstzeitenID={MitarbeiterVerlaufDienstzeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufDienstzeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufDienstzeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenUpdated(newItem);
            this.context.MitarbeiterVerlaufDienstzeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen,MitarbeiterVerlaufDienstzeitenArten");
            this.OnAfterMitarbeiterVerlaufDienstzeitenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens(MitarbeiterVerlaufDienstzeitenID={MitarbeiterVerlaufDienstzeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufDienstzeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterVerlaufDienstzeitenUpdated(item);
            this.context.MitarbeiterVerlaufDienstzeitens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen,MitarbeiterVerlaufDienstzeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item)
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

            this.OnMitarbeiterVerlaufDienstzeitenCreated(item);
            this.context.MitarbeiterVerlaufDienstzeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufDienstzeitenID;

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen,MitarbeiterVerlaufDienstzeitenArten");

            this.OnAfterMitarbeiterVerlaufDienstzeitenCreated(item);

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
