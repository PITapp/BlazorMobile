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

  [Route("odata/dbSinDarEla/AbrechnungBases")]
  public partial class AbrechnungBasesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public AbrechnungBasesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AbrechnungBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AbrechnungBasis> GetAbrechnungBases()
    {
      var items = this.context.AbrechnungBases.AsQueryable<Models.DbSinDarEla.AbrechnungBasis>();
      this.OnAbrechnungBasesRead(ref items);

      return items;
    }

    partial void OnAbrechnungBasesRead(ref IQueryable<Models.DbSinDarEla.AbrechnungBasis> items);

    partial void OnAbrechnungBasisGet(ref SingleResult<Models.DbSinDarEla.AbrechnungBasis> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/AbrechnungBases(AbrechnungBasisID={AbrechnungBasisID})")]
    public SingleResult<AbrechnungBasis> GetAbrechnungBasis(int key)
    {
        var items = this.context.AbrechnungBases.Where(i=>i.AbrechnungBasisID == key);
        var result = SingleResult.Create(items);

        OnAbrechnungBasisGet(ref result);

        return result;
    }
    partial void OnAbrechnungBasisDeleted(Models.DbSinDarEla.AbrechnungBasis item);
    partial void OnAfterAbrechnungBasisDeleted(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpDelete("/odata/dbSinDarEla/AbrechnungBases(AbrechnungBasisID={AbrechnungBasisID})")]
    public IActionResult DeleteAbrechnungBasis(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.AbrechnungBases
                .Where(i => i.AbrechnungBasisID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAbrechnungBasisDeleted(item);
            this.context.AbrechnungBases.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAbrechnungBasisDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungBasisUpdated(Models.DbSinDarEla.AbrechnungBasis item);
    partial void OnAfterAbrechnungBasisUpdated(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpPut("/odata/dbSinDarEla/AbrechnungBases(AbrechnungBasisID={AbrechnungBasisID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAbrechnungBasis(int key, [FromBody]Models.DbSinDarEla.AbrechnungBasis newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AbrechnungBasisID != key))
            {
                return BadRequest();
            }

            this.OnAbrechnungBasisUpdated(newItem);
            this.context.AbrechnungBases.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key);
            this.OnAfterAbrechnungBasisUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/AbrechnungBases(AbrechnungBasisID={AbrechnungBasisID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAbrechnungBasis(int key, [FromBody]Delta<Models.DbSinDarEla.AbrechnungBasis> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAbrechnungBasisUpdated(item);
            this.context.AbrechnungBases.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungBasisCreated(Models.DbSinDarEla.AbrechnungBasis item);
    partial void OnAfterAbrechnungBasisCreated(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AbrechnungBasis item)
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

            this.OnAbrechnungBasisCreated(item);
            this.context.AbrechnungBases.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterAbrechnungBasisCreated(item);
            
            return Created($"odata/DbSinDarEla/AbrechnungBases/{item.AbrechnungBasisID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
