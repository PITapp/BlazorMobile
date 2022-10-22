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

  [Route("odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens")]
  public partial class MitarbeiterUrlaubKumuliertDienstzeitensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubKumuliertDienstzeitensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> GetMitarbeiterUrlaubKumuliertDienstzeitens()
    {
      var items = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>();
      this.OnMitarbeiterUrlaubKumuliertDienstzeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> items);

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens(MitarbeiterUrlaubKumuliertDienstzeitenID={MitarbeiterUrlaubKumuliertDienstzeitenID})")]
    public SingleResult<MitarbeiterUrlaubKumuliertDienstzeiten> GetMitarbeiterUrlaubKumuliertDienstzeiten(int key)
    {
        var items = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i=>i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterUrlaubKumuliertDienstzeitenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);
    partial void OnAfterMitarbeiterUrlaubKumuliertDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens(MitarbeiterUrlaubKumuliertDienstzeitenID={MitarbeiterUrlaubKumuliertDienstzeitenID})")]
    public IActionResult DeleteMitarbeiterUrlaubKumuliertDienstzeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterUrlaubKumuliertDienstzeitens
                .Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenDeleted(item);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterUrlaubKumuliertDienstzeitenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);
    partial void OnAfterMitarbeiterUrlaubKumuliertDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens(MitarbeiterUrlaubKumuliertDienstzeitenID={MitarbeiterUrlaubKumuliertDienstzeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubKumuliertDienstzeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubKumuliertDienstzeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(newItem);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            this.OnAfterMitarbeiterUrlaubKumuliertDienstzeitenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens(MitarbeiterUrlaubKumuliertDienstzeitenID={MitarbeiterUrlaubKumuliertDienstzeitenID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubKumuliertDienstzeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(item);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);
    partial void OnAfterMitarbeiterUrlaubKumuliertDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item)
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

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenCreated(item);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubKumuliertDienstzeitenID;

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterFirmen");

            this.OnAfterMitarbeiterUrlaubKumuliertDienstzeitenCreated(item);

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
