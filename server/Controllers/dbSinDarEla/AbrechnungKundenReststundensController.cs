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

  [Route("odata/dbSinDarEla/AbrechnungKundenReststundens")]
  public partial class AbrechnungKundenReststundensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public AbrechnungKundenReststundensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AbrechnungKundenReststundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AbrechnungKundenReststunden> GetAbrechnungKundenReststundens()
    {
      var items = this.context.AbrechnungKundenReststundens.AsQueryable<Models.DbSinDarEla.AbrechnungKundenReststunden>();
      this.OnAbrechnungKundenReststundensRead(ref items);

      return items;
    }

    partial void OnAbrechnungKundenReststundensRead(ref IQueryable<Models.DbSinDarEla.AbrechnungKundenReststunden> items);

    partial void OnAbrechnungKundenReststundenGet(ref SingleResult<Models.DbSinDarEla.AbrechnungKundenReststunden> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/AbrechnungKundenReststundens(AbrechnungKundenReststundenID={AbrechnungKundenReststundenID})")]
    public SingleResult<AbrechnungKundenReststunden> GetAbrechnungKundenReststunden(int key)
    {
        var items = this.context.AbrechnungKundenReststundens.Where(i=>i.AbrechnungKundenReststundenID == key);
        var result = SingleResult.Create(items);

        OnAbrechnungKundenReststundenGet(ref result);

        return result;
    }
    partial void OnAbrechnungKundenReststundenDeleted(Models.DbSinDarEla.AbrechnungKundenReststunden item);
    partial void OnAfterAbrechnungKundenReststundenDeleted(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpDelete("/odata/dbSinDarEla/AbrechnungKundenReststundens(AbrechnungKundenReststundenID={AbrechnungKundenReststundenID})")]
    public IActionResult DeleteAbrechnungKundenReststunden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.AbrechnungKundenReststundens
                .Where(i => i.AbrechnungKundenReststundenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAbrechnungKundenReststundenDeleted(item);
            this.context.AbrechnungKundenReststundens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAbrechnungKundenReststundenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungKundenReststundenUpdated(Models.DbSinDarEla.AbrechnungKundenReststunden item);
    partial void OnAfterAbrechnungKundenReststundenUpdated(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpPut("/odata/dbSinDarEla/AbrechnungKundenReststundens(AbrechnungKundenReststundenID={AbrechnungKundenReststundenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAbrechnungKundenReststunden(int key, [FromBody]Models.DbSinDarEla.AbrechnungKundenReststunden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AbrechnungKundenReststundenID != key))
            {
                return BadRequest();
            }

            this.OnAbrechnungKundenReststundenUpdated(newItem);
            this.context.AbrechnungKundenReststundens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            this.OnAfterAbrechnungKundenReststundenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/AbrechnungKundenReststundens(AbrechnungKundenReststundenID={AbrechnungKundenReststundenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAbrechnungKundenReststunden(int key, [FromBody]Delta<Models.DbSinDarEla.AbrechnungKundenReststunden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAbrechnungKundenReststundenUpdated(item);
            this.context.AbrechnungKundenReststundens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungKundenReststundenCreated(Models.DbSinDarEla.AbrechnungKundenReststunden item);
    partial void OnAfterAbrechnungKundenReststundenCreated(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AbrechnungKundenReststunden item)
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

            this.OnAbrechnungKundenReststundenCreated(item);
            this.context.AbrechnungKundenReststundens.Add(item);
            this.context.SaveChanges();

            var key = item.AbrechnungKundenReststundenID;

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");

            this.OnAfterAbrechnungKundenReststundenCreated(item);

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
