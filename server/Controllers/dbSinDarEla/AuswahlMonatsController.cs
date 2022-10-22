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

  [Route("odata/dbSinDarEla/AuswahlMonats")]
  public partial class AuswahlMonatsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public AuswahlMonatsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AuswahlMonats
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AuswahlMonat> GetAuswahlMonats()
    {
      var items = this.context.AuswahlMonats.AsQueryable<Models.DbSinDarEla.AuswahlMonat>();
      this.OnAuswahlMonatsRead(ref items);

      return items;
    }

    partial void OnAuswahlMonatsRead(ref IQueryable<Models.DbSinDarEla.AuswahlMonat> items);

    partial void OnAuswahlMonatGet(ref SingleResult<Models.DbSinDarEla.AuswahlMonat> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/AuswahlMonats(AuswahlMonatID={AuswahlMonatID})")]
    public SingleResult<AuswahlMonat> GetAuswahlMonat(int key)
    {
        var items = this.context.AuswahlMonats.Where(i=>i.AuswahlMonatID == key);
        var result = SingleResult.Create(items);

        OnAuswahlMonatGet(ref result);

        return result;
    }
    partial void OnAuswahlMonatDeleted(Models.DbSinDarEla.AuswahlMonat item);
    partial void OnAfterAuswahlMonatDeleted(Models.DbSinDarEla.AuswahlMonat item);

    [HttpDelete("/odata/dbSinDarEla/AuswahlMonats(AuswahlMonatID={AuswahlMonatID})")]
    public IActionResult DeleteAuswahlMonat(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.AuswahlMonats
                .Where(i => i.AuswahlMonatID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAuswahlMonatDeleted(item);
            this.context.AuswahlMonats.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAuswahlMonatDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlMonatUpdated(Models.DbSinDarEla.AuswahlMonat item);
    partial void OnAfterAuswahlMonatUpdated(Models.DbSinDarEla.AuswahlMonat item);

    [HttpPut("/odata/dbSinDarEla/AuswahlMonats(AuswahlMonatID={AuswahlMonatID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAuswahlMonat(int key, [FromBody]Models.DbSinDarEla.AuswahlMonat newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AuswahlMonatID != key))
            {
                return BadRequest();
            }

            this.OnAuswahlMonatUpdated(newItem);
            this.context.AuswahlMonats.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key);
            this.OnAfterAuswahlMonatUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/AuswahlMonats(AuswahlMonatID={AuswahlMonatID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAuswahlMonat(int key, [FromBody]Delta<Models.DbSinDarEla.AuswahlMonat> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAuswahlMonatUpdated(item);
            this.context.AuswahlMonats.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlMonatCreated(Models.DbSinDarEla.AuswahlMonat item);
    partial void OnAfterAuswahlMonatCreated(Models.DbSinDarEla.AuswahlMonat item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AuswahlMonat item)
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

            this.OnAuswahlMonatCreated(item);
            this.context.AuswahlMonats.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterAuswahlMonatCreated(item);
            
            return Created($"odata/DbSinDarEla/AuswahlMonats/{item.AuswahlMonatID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
