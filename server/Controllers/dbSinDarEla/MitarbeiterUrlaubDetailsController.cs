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

  [Route("odata/dbSinDarEla/MitarbeiterUrlaubDetails")]
  public partial class MitarbeiterUrlaubDetailsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubDetailsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubDetails
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubDetail> GetMitarbeiterUrlaubDetails()
    {
      var items = this.context.MitarbeiterUrlaubDetails.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubDetail>();
      this.OnMitarbeiterUrlaubDetailsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubDetailsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubDetail> items);

    partial void OnMitarbeiterUrlaubDetailGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterUrlaubDetail> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterUrlaubDetails(MitarbeiterUrlaubDetailsID={MitarbeiterUrlaubDetailsID})")]
    public SingleResult<MitarbeiterUrlaubDetail> GetMitarbeiterUrlaubDetail(int key)
    {
        var items = this.context.MitarbeiterUrlaubDetails.Where(i=>i.MitarbeiterUrlaubDetailsID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterUrlaubDetailGet(ref result);

        return result;
    }
    partial void OnMitarbeiterUrlaubDetailDeleted(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);
    partial void OnAfterMitarbeiterUrlaubDetailDeleted(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterUrlaubDetails(MitarbeiterUrlaubDetailsID={MitarbeiterUrlaubDetailsID})")]
    public IActionResult DeleteMitarbeiterUrlaubDetail(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterUrlaubDetails
                .Where(i => i.MitarbeiterUrlaubDetailsID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubDetailDeleted(item);
            this.context.MitarbeiterUrlaubDetails.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterUrlaubDetailDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubDetailUpdated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);
    partial void OnAfterMitarbeiterUrlaubDetailUpdated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterUrlaubDetails(MitarbeiterUrlaubDetailsID={MitarbeiterUrlaubDetailsID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubDetail(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubDetail newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubDetailsID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubDetailUpdated(newItem);
            this.context.MitarbeiterUrlaubDetails.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");
            this.OnAfterMitarbeiterUrlaubDetailUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterUrlaubDetails(MitarbeiterUrlaubDetailsID={MitarbeiterUrlaubDetailsID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubDetail(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubDetail> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterUrlaubDetailUpdated(item);
            this.context.MitarbeiterUrlaubDetails.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubDetailCreated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);
    partial void OnAfterMitarbeiterUrlaubDetailCreated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubDetail item)
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

            this.OnMitarbeiterUrlaubDetailCreated(item);
            this.context.MitarbeiterUrlaubDetails.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubDetailsID;

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");

            this.OnAfterMitarbeiterUrlaubDetailCreated(item);

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
