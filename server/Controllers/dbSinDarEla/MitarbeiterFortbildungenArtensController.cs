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

  [Route("odata/dbSinDarEla/MitarbeiterFortbildungenArtens")]
  public partial class MitarbeiterFortbildungenArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterFortbildungenArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterFortbildungenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterFortbildungenArten> GetMitarbeiterFortbildungenArtens()
    {
      var items = this.context.MitarbeiterFortbildungenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterFortbildungenArten>();
      this.OnMitarbeiterFortbildungenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterFortbildungenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungenArten> items);

    partial void OnMitarbeiterFortbildungenArtenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterFortbildungenArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterFortbildungenArtens(FortbildungArtID={FortbildungArtID})")]
    public SingleResult<MitarbeiterFortbildungenArten> GetMitarbeiterFortbildungenArten(int key)
    {
        var items = this.context.MitarbeiterFortbildungenArtens.Where(i=>i.FortbildungArtID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterFortbildungenArtenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterFortbildungenArtenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);
    partial void OnAfterMitarbeiterFortbildungenArtenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterFortbildungenArtens(FortbildungArtID={FortbildungArtID})")]
    public IActionResult DeleteMitarbeiterFortbildungenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterFortbildungenArtens
                .Where(i => i.FortbildungArtID == key)
                .Include(i => i.MitarbeiterFortbildungens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenArtenDeleted(item);
            this.context.MitarbeiterFortbildungenArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterFortbildungenArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenArtenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);
    partial void OnAfterMitarbeiterFortbildungenArtenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterFortbildungenArtens(FortbildungArtID={FortbildungArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterFortbildungenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterFortbildungenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FortbildungArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenArtenUpdated(newItem);
            this.context.MitarbeiterFortbildungenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key);
            this.OnAfterMitarbeiterFortbildungenArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterFortbildungenArtens(FortbildungArtID={FortbildungArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterFortbildungenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterFortbildungenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterFortbildungenArtenUpdated(item);
            this.context.MitarbeiterFortbildungenArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenArtenCreated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);
    partial void OnAfterMitarbeiterFortbildungenArtenCreated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterFortbildungenArten item)
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

            this.OnMitarbeiterFortbildungenArtenCreated(item);
            this.context.MitarbeiterFortbildungenArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterFortbildungenArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterFortbildungenArtens/{item.FortbildungArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
