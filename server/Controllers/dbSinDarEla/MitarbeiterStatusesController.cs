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

  [Route("odata/dbSinDarEla/MitarbeiterStatuses")]
  public partial class MitarbeiterStatusesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterStatusesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterStatus> GetMitarbeiterStatuses()
    {
      var items = this.context.MitarbeiterStatuses.AsQueryable<Models.DbSinDarEla.MitarbeiterStatus>();
      this.OnMitarbeiterStatusesRead(ref items);

      return items;
    }

    partial void OnMitarbeiterStatusesRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterStatus> items);

    partial void OnMitarbeiterStatusGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterStatus> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterStatuses(MitarbeiterStatusID={MitarbeiterStatusID})")]
    public SingleResult<MitarbeiterStatus> GetMitarbeiterStatus(int key)
    {
        var items = this.context.MitarbeiterStatuses.Where(i=>i.MitarbeiterStatusID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterStatusGet(ref result);

        return result;
    }
    partial void OnMitarbeiterStatusDeleted(Models.DbSinDarEla.MitarbeiterStatus item);
    partial void OnAfterMitarbeiterStatusDeleted(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterStatuses(MitarbeiterStatusID={MitarbeiterStatusID})")]
    public IActionResult DeleteMitarbeiterStatus(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterStatuses
                .Where(i => i.MitarbeiterStatusID == key)
                .Include(i => i.MitarbeiterFirmens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterStatusDeleted(item);
            this.context.MitarbeiterStatuses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterStatusDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterStatusUpdated(Models.DbSinDarEla.MitarbeiterStatus item);
    partial void OnAfterMitarbeiterStatusUpdated(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterStatuses(MitarbeiterStatusID={MitarbeiterStatusID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterStatus(int key, [FromBody]Models.DbSinDarEla.MitarbeiterStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterStatusID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterStatusUpdated(newItem);
            this.context.MitarbeiterStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key);
            this.OnAfterMitarbeiterStatusUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterStatuses(MitarbeiterStatusID={MitarbeiterStatusID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterStatus(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterStatusUpdated(item);
            this.context.MitarbeiterStatuses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterStatusCreated(Models.DbSinDarEla.MitarbeiterStatus item);
    partial void OnAfterMitarbeiterStatusCreated(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterStatus item)
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

            this.OnMitarbeiterStatusCreated(item);
            this.context.MitarbeiterStatuses.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterMitarbeiterStatusCreated(item);
            
            return Created($"odata/DbSinDarEla/MitarbeiterStatuses/{item.MitarbeiterStatusID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
