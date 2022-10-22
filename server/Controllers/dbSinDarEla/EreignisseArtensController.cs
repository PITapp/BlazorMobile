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

  [Route("odata/dbSinDarEla/EreignisseArtens")]
  public partial class EreignisseArtensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public EreignisseArtensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseArten> GetEreignisseArtens()
    {
      var items = this.context.EreignisseArtens.AsQueryable<Models.DbSinDarEla.EreignisseArten>();
      this.OnEreignisseArtensRead(ref items);

      return items;
    }

    partial void OnEreignisseArtensRead(ref IQueryable<Models.DbSinDarEla.EreignisseArten> items);

    partial void OnEreignisseArtenGet(ref SingleResult<Models.DbSinDarEla.EreignisseArten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/EreignisseArtens(EreignisArtCode={EreignisArtCode})")]
    public SingleResult<EreignisseArten> GetEreignisseArten(string key)
    {
        var items = this.context.EreignisseArtens.Where(i=>i.EreignisArtCode == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnEreignisseArtenGet(ref result);

        return result;
    }
    partial void OnEreignisseArtenDeleted(Models.DbSinDarEla.EreignisseArten item);
    partial void OnAfterEreignisseArtenDeleted(Models.DbSinDarEla.EreignisseArten item);

    [HttpDelete("/odata/dbSinDarEla/EreignisseArtens(EreignisArtCode={EreignisArtCode})")]
    public IActionResult DeleteEreignisseArten(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.EreignisseArtens
                .Where(i => i.EreignisArtCode == Uri.UnescapeDataString(key))
                .Include(i => i.Ereignisses)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEreignisseArtenDeleted(item);
            this.context.EreignisseArtens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEreignisseArtenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseArtenUpdated(Models.DbSinDarEla.EreignisseArten item);
    partial void OnAfterEreignisseArtenUpdated(Models.DbSinDarEla.EreignisseArten item);

    [HttpPut("/odata/dbSinDarEla/EreignisseArtens(EreignisArtCode={EreignisArtCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseArten(string key, [FromBody]Models.DbSinDarEla.EreignisseArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisArtCode != Uri.UnescapeDataString(key)))
            {
                return BadRequest();
            }

            this.OnEreignisseArtenUpdated(newItem);
            this.context.EreignisseArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == Uri.UnescapeDataString(key));
            this.OnAfterEreignisseArtenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/EreignisseArtens(EreignisArtCode={EreignisArtCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseArten(string key, [FromBody]Delta<Models.DbSinDarEla.EreignisseArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == Uri.UnescapeDataString(key)).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEreignisseArtenUpdated(item);
            this.context.EreignisseArtens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseArtenCreated(Models.DbSinDarEla.EreignisseArten item);
    partial void OnAfterEreignisseArtenCreated(Models.DbSinDarEla.EreignisseArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseArten item)
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

            this.OnEreignisseArtenCreated(item);
            this.context.EreignisseArtens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterEreignisseArtenCreated(item);
            
            return Created($"odata/DbSinDarEla/EreignisseArtens/{item.EreignisArtCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
