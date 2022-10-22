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

  [Route("odata/dbSinDarEla/EreignisseSonderurlaubArtens")]
  public partial class EreignisseSonderurlaubArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public EreignisseSonderurlaubArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseSonderurlaubArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseSonderurlaubArten> GetEreignisseSonderurlaubArtens()
    {
      var items = this.context.EreignisseSonderurlaubArtens.AsQueryable<Models.DbSinDarEla.EreignisseSonderurlaubArten>();
      this.OnEreignisseSonderurlaubArtensRead(ref items);

      return items;
    }

    partial void OnEreignisseSonderurlaubArtensRead(ref IQueryable<Models.DbSinDarEla.EreignisseSonderurlaubArten> items);

    partial void OnEreignisseSonderurlaubArtenGet(ref SingleResult<Models.DbSinDarEla.EreignisseSonderurlaubArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/EreignisseSonderurlaubArtens(EreignisSonderurlaubArtID={EreignisSonderurlaubArtID})")]
    public SingleResult<EreignisseSonderurlaubArten> GetEreignisseSonderurlaubArten(int key)
    {
        var items = this.context.EreignisseSonderurlaubArtens.Where(i=>i.EreignisSonderurlaubArtID == key);
        var result = SingleResult.Create(items);

        OnEreignisseSonderurlaubArtenGet(ref result);

        return result;
    }
    partial void OnEreignisseSonderurlaubArtenDeleted(Models.DbSinDarEla.EreignisseSonderurlaubArten item);
    partial void OnAfterEreignisseSonderurlaubArtenDeleted(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpDelete("/odata/dbSinDarEla/EreignisseSonderurlaubArtens(EreignisSonderurlaubArtID={EreignisSonderurlaubArtID})")]
    public IActionResult DeleteEreignisseSonderurlaubArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.EreignisseSonderurlaubArtens
                .Where(i => i.EreignisSonderurlaubArtID == key)
                .Include(i => i.Ereignisses)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEreignisseSonderurlaubArtenDeleted(item);
            this.context.EreignisseSonderurlaubArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEreignisseSonderurlaubArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseSonderurlaubArtenUpdated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);
    partial void OnAfterEreignisseSonderurlaubArtenUpdated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpPut("/odata/dbSinDarEla/EreignisseSonderurlaubArtens(EreignisSonderurlaubArtID={EreignisSonderurlaubArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseSonderurlaubArten(int key, [FromBody]Models.DbSinDarEla.EreignisseSonderurlaubArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisSonderurlaubArtID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseSonderurlaubArtenUpdated(newItem);
            this.context.EreignisseSonderurlaubArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key);
            this.OnAfterEreignisseSonderurlaubArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/EreignisseSonderurlaubArtens(EreignisSonderurlaubArtID={EreignisSonderurlaubArtID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseSonderurlaubArten(int key, [FromBody]Delta<Models.DbSinDarEla.EreignisseSonderurlaubArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEreignisseSonderurlaubArtenUpdated(item);
            this.context.EreignisseSonderurlaubArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseSonderurlaubArtenCreated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);
    partial void OnAfterEreignisseSonderurlaubArtenCreated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseSonderurlaubArten item)
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

            this.OnEreignisseSonderurlaubArtenCreated(item);
            this.context.EreignisseSonderurlaubArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterEreignisseSonderurlaubArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/EreignisseSonderurlaubArtens/{item.EreignisSonderurlaubArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
