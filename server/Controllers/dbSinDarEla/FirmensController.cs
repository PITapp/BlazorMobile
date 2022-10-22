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

  [Route("odata/dbSinDarEla/Firmens")]
  public partial class FirmensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public FirmensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Firmens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Firmen> GetFirmens()
    {
      var items = this.context.Firmens.AsQueryable<Models.DbSinDarEla.Firmen>();
      this.OnFirmensRead(ref items);

      return items;
    }

    partial void OnFirmensRead(ref IQueryable<Models.DbSinDarEla.Firmen> items);

    partial void OnFirmenGet(ref SingleResult<Models.DbSinDarEla.Firmen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Firmens(FirmaID={FirmaID})")]
    public SingleResult<Firmen> GetFirmen(int key)
    {
        var items = this.context.Firmens.Where(i=>i.FirmaID == key);
        var result = SingleResult.Create(items);

        OnFirmenGet(ref result);

        return result;
    }
    partial void OnFirmenDeleted(Models.DbSinDarEla.Firmen item);
    partial void OnAfterFirmenDeleted(Models.DbSinDarEla.Firmen item);

    [HttpDelete("/odata/dbSinDarEla/Firmens(FirmaID={FirmaID})")]
    public IActionResult DeleteFirmen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Firmens
                .Where(i => i.FirmaID == key)
                .Include(i => i.FirmenMitarbeiterTaetigkeitens)
                .Include(i => i.MitarbeiterFirmens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnFirmenDeleted(item);
            this.context.Firmens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterFirmenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFirmenUpdated(Models.DbSinDarEla.Firmen item);
    partial void OnAfterFirmenUpdated(Models.DbSinDarEla.Firmen item);

    [HttpPut("/odata/dbSinDarEla/Firmens(FirmaID={FirmaID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutFirmen(int key, [FromBody]Models.DbSinDarEla.Firmen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FirmaID != key))
            {
                return BadRequest();
            }

            this.OnFirmenUpdated(newItem);
            this.context.Firmens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Firmens.Where(i => i.FirmaID == key);
            this.OnAfterFirmenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Firmens(FirmaID={FirmaID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchFirmen(int key, [FromBody]Delta<Models.DbSinDarEla.Firmen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Firmens.Where(i => i.FirmaID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnFirmenUpdated(item);
            this.context.Firmens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Firmens.Where(i => i.FirmaID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFirmenCreated(Models.DbSinDarEla.Firmen item);
    partial void OnAfterFirmenCreated(Models.DbSinDarEla.Firmen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Firmen item)
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

            this.OnFirmenCreated(item);
            this.context.Firmens.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterFirmenCreated(item);
            
            return Created($"odata/DbSinDarEla/Firmens/{item.FirmaID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
