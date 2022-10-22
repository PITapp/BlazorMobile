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

  [Route("odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens")]
  public partial class MitarbeiterVerlaufDienstzeitenArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufDienstzeitenArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> GetMitarbeiterVerlaufDienstzeitenArtens()
    {
      var items = this.context.MitarbeiterVerlaufDienstzeitenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>();
      this.OnMitarbeiterVerlaufDienstzeitenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> items);

    partial void OnMitarbeiterVerlaufDienstzeitenArtenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens(MitarbeiterVerlaufDienstzeitenArtID={MitarbeiterVerlaufDienstzeitenArtID})")]
    public SingleResult<MitarbeiterVerlaufDienstzeitenArten> GetMitarbeiterVerlaufDienstzeitenArten(int key)
    {
        var items = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i=>i.MitarbeiterVerlaufDienstzeitenArtID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterVerlaufDienstzeitenArtenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterVerlaufDienstzeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens(MitarbeiterVerlaufDienstzeitenArtID={MitarbeiterVerlaufDienstzeitenArtID})")]
    public IActionResult DeleteMitarbeiterVerlaufDienstzeitenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterVerlaufDienstzeitenArtens
                .Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key)
                .Include(i => i.MitarbeiterVerlaufDienstzeitens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenArtenDeleted(item);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterVerlaufDienstzeitenArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens(MitarbeiterVerlaufDienstzeitenArtID={MitarbeiterVerlaufDienstzeitenArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufDienstzeitenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufDienstzeitenArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenArtenUpdated(newItem);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key);
            this.OnAfterMitarbeiterVerlaufDienstzeitenArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens(MitarbeiterVerlaufDienstzeitenArtID={MitarbeiterVerlaufDienstzeitenArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufDienstzeitenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterVerlaufDienstzeitenArtenUpdated(item);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);
    partial void OnAfterMitarbeiterVerlaufDienstzeitenArtenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item)
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

            this.OnMitarbeiterVerlaufDienstzeitenArtenCreated(item);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterVerlaufDienstzeitenArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens/{item.MitarbeiterVerlaufDienstzeitenArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
