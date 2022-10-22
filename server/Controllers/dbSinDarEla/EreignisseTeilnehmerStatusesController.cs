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

  [Route("odata/dbSinDarEla/EreignisseTeilnehmerStatuses")]
  public partial class EreignisseTeilnehmerStatusesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public EreignisseTeilnehmerStatusesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseTeilnehmerStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseTeilnehmerStatus> GetEreignisseTeilnehmerStatuses()
    {
      var items = this.context.EreignisseTeilnehmerStatuses.AsQueryable<Models.DbSinDarEla.EreignisseTeilnehmerStatus>();
      this.OnEreignisseTeilnehmerStatusesRead(ref items);

      return items;
    }

    partial void OnEreignisseTeilnehmerStatusesRead(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmerStatus> items);

    partial void OnEreignisseTeilnehmerStatusGet(ref SingleResult<Models.DbSinDarEla.EreignisseTeilnehmerStatus> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/EreignisseTeilnehmerStatuses(StatusCode={StatusCode})")]
    public SingleResult<EreignisseTeilnehmerStatus> GetEreignisseTeilnehmerStatus(string key)
    {
        var items = this.context.EreignisseTeilnehmerStatuses.Where(i=>i.StatusCode == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnEreignisseTeilnehmerStatusGet(ref result);

        return result;
    }
    partial void OnEreignisseTeilnehmerStatusDeleted(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);
    partial void OnAfterEreignisseTeilnehmerStatusDeleted(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpDelete("/odata/dbSinDarEla/EreignisseTeilnehmerStatuses(StatusCode={StatusCode})")]
    public IActionResult DeleteEreignisseTeilnehmerStatus(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.EreignisseTeilnehmerStatuses
                .Where(i => i.StatusCode == Uri.UnescapeDataString(key))
                .Include(i => i.EreignisseTeilnehmers)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEreignisseTeilnehmerStatusDeleted(item);
            this.context.EreignisseTeilnehmerStatuses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEreignisseTeilnehmerStatusDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerStatusUpdated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);
    partial void OnAfterEreignisseTeilnehmerStatusUpdated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpPut("/odata/dbSinDarEla/EreignisseTeilnehmerStatuses(StatusCode={StatusCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseTeilnehmerStatus(string key, [FromBody]Models.DbSinDarEla.EreignisseTeilnehmerStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.StatusCode != Uri.UnescapeDataString(key)))
            {
                return BadRequest();
            }

            this.OnEreignisseTeilnehmerStatusUpdated(newItem);
            this.context.EreignisseTeilnehmerStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == Uri.UnescapeDataString(key));
            this.OnAfterEreignisseTeilnehmerStatusUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/EreignisseTeilnehmerStatuses(StatusCode={StatusCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseTeilnehmerStatus(string key, [FromBody]Delta<Models.DbSinDarEla.EreignisseTeilnehmerStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == Uri.UnescapeDataString(key)).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEreignisseTeilnehmerStatusUpdated(item);
            this.context.EreignisseTeilnehmerStatuses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerStatusCreated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);
    partial void OnAfterEreignisseTeilnehmerStatusCreated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseTeilnehmerStatus item)
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

            this.OnEreignisseTeilnehmerStatusCreated(item);
            this.context.EreignisseTeilnehmerStatuses.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterEreignisseTeilnehmerStatusCreated(item);
            
            return Created($"odata/DbSinDarEla/EreignisseTeilnehmerStatuses/{item.StatusCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
