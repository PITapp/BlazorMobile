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

  [Route("odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches")]
  public partial class MitarbeiterUrlaubKumuliertAnspruchesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubKumuliertAnspruchesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> GetMitarbeiterUrlaubKumuliertAnspruches()
    {
      var items = this.context.MitarbeiterUrlaubKumuliertAnspruches.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>();
      this.OnMitarbeiterUrlaubKumuliertAnspruchesRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchesRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> items);

    partial void OnMitarbeiterUrlaubKumuliertAnspruchGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches(MitarbeiterUrlaubKumuliertAnspruchID={MitarbeiterUrlaubKumuliertAnspruchID})")]
    public SingleResult<MitarbeiterUrlaubKumuliertAnspruch> GetMitarbeiterUrlaubKumuliertAnspruch(int key)
    {
        var items = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i=>i.MitarbeiterUrlaubKumuliertAnspruchID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterUrlaubKumuliertAnspruchGet(ref result);

        return result;
    }
    partial void OnMitarbeiterUrlaubKumuliertAnspruchDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);
    partial void OnAfterMitarbeiterUrlaubKumuliertAnspruchDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches(MitarbeiterUrlaubKumuliertAnspruchID={MitarbeiterUrlaubKumuliertAnspruchID})")]
    public IActionResult DeleteMitarbeiterUrlaubKumuliertAnspruch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterUrlaubKumuliertAnspruches
                .Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertAnspruchDeleted(item);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterUrlaubKumuliertAnspruchDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);
    partial void OnAfterMitarbeiterUrlaubKumuliertAnspruchUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches(MitarbeiterUrlaubKumuliertAnspruchID={MitarbeiterUrlaubKumuliertAnspruchID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubKumuliertAnspruch(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubKumuliertAnspruchID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertAnspruchUpdated(newItem);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            this.OnAfterMitarbeiterUrlaubKumuliertAnspruchUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches(MitarbeiterUrlaubKumuliertAnspruchID={MitarbeiterUrlaubKumuliertAnspruchID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubKumuliertAnspruch(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterUrlaubKumuliertAnspruchUpdated(item);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);
    partial void OnAfterMitarbeiterUrlaubKumuliertAnspruchCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item)
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

            this.OnMitarbeiterUrlaubKumuliertAnspruchCreated(item);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubKumuliertAnspruchID;

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");

            this.OnAfterMitarbeiterUrlaubKumuliertAnspruchCreated(item);

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
