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

  [Route("odata/dbSinDarEla/MitarbeiterFirmens")]
  public partial class MitarbeiterFirmensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterFirmensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterFirmens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterFirmen> GetMitarbeiterFirmens()
    {
      var items = this.context.MitarbeiterFirmens.AsQueryable<Models.DbSinDarEla.MitarbeiterFirmen>();
      this.OnMitarbeiterFirmensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterFirmensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterFirmen> items);

    partial void OnMitarbeiterFirmenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterFirmen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterFirmens(MitarbeiterFirmaID={MitarbeiterFirmaID})")]
    public SingleResult<MitarbeiterFirmen> GetMitarbeiterFirmen(int key)
    {
        var items = this.context.MitarbeiterFirmens.Where(i=>i.MitarbeiterFirmaID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterFirmenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterFirmenDeleted(Models.DbSinDarEla.MitarbeiterFirmen item);
    partial void OnAfterMitarbeiterFirmenDeleted(Models.DbSinDarEla.MitarbeiterFirmen item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterFirmens(MitarbeiterFirmaID={MitarbeiterFirmaID})")]
    public IActionResult DeleteMitarbeiterFirmen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterFirmens
                .Where(i => i.MitarbeiterFirmaID == key)
                .Include(i => i.MitarbeiterUrlaubs)
                .Include(i => i.MitarbeiterUrlaubKumuliertAnspruches)
                .Include(i => i.MitarbeiterUrlaubKumuliertDienstzeitens)
                .Include(i => i.MitarbeiterVerlaufDienstzeitens)
                .Include(i => i.MitarbeiterVerlaufGehalts)
                .Include(i => i.MitarbeiterVerlaufNormalarbeitszeits)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterFirmenDeleted(item);
            this.context.MitarbeiterFirmens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterFirmenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFirmenUpdated(Models.DbSinDarEla.MitarbeiterFirmen item);
    partial void OnAfterMitarbeiterFirmenUpdated(Models.DbSinDarEla.MitarbeiterFirmen item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterFirmens(MitarbeiterFirmaID={MitarbeiterFirmaID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterFirmen(int key, [FromBody]Models.DbSinDarEla.MitarbeiterFirmen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterFirmaID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterFirmenUpdated(newItem);
            this.context.MitarbeiterFirmens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFirmens.Where(i => i.MitarbeiterFirmaID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,Mitarbeiter,MitarbeiterStatus");
            this.OnAfterMitarbeiterFirmenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterFirmens(MitarbeiterFirmaID={MitarbeiterFirmaID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterFirmen(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterFirmen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterFirmens.Where(i => i.MitarbeiterFirmaID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterFirmenUpdated(item);
            this.context.MitarbeiterFirmens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFirmens.Where(i => i.MitarbeiterFirmaID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,Mitarbeiter,MitarbeiterStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFirmenCreated(Models.DbSinDarEla.MitarbeiterFirmen item);
    partial void OnAfterMitarbeiterFirmenCreated(Models.DbSinDarEla.MitarbeiterFirmen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterFirmen item)
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

            this.OnMitarbeiterFirmenCreated(item);
            this.context.MitarbeiterFirmens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterFirmaID;

            var itemToReturn = this.context.MitarbeiterFirmens.Where(i => i.MitarbeiterFirmaID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Firmen,Mitarbeiter,MitarbeiterStatus");

            this.OnAfterMitarbeiterFirmenCreated(item);

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
