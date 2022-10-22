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

  [Route("odata/dbSinDarEla/Mitarbeiters")]
  public partial class MitarbeitersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeitersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Mitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Mitarbeiter> GetMitarbeiters()
    {
      var items = this.context.Mitarbeiters.AsQueryable<Models.DbSinDarEla.Mitarbeiter>();
      this.OnMitarbeitersRead(ref items);

      return items;
    }

    partial void OnMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.Mitarbeiter> items);

    partial void OnMitarbeiterGet(ref SingleResult<Models.DbSinDarEla.Mitarbeiter> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Mitarbeiters(MitarbeiterID={MitarbeiterID})")]
    public SingleResult<Mitarbeiter> GetMitarbeiter(int key)
    {
        var items = this.context.Mitarbeiters.Where(i=>i.MitarbeiterID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterGet(ref result);

        return result;
    }
    partial void OnMitarbeiterDeleted(Models.DbSinDarEla.Mitarbeiter item);
    partial void OnAfterMitarbeiterDeleted(Models.DbSinDarEla.Mitarbeiter item);

    [HttpDelete("/odata/dbSinDarEla/Mitarbeiters(MitarbeiterID={MitarbeiterID})")]
    public IActionResult DeleteMitarbeiter(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Mitarbeiters
                .Where(i => i.MitarbeiterID == key)
                .Include(i => i.MitarbeiterFirmens)
                .Include(i => i.MitarbeiterFortbildungens)
                .Include(i => i.MitarbeiterKundenbudgets)
                .Include(i => i.MitarbeiterTaetigkeitens)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterDeleted(item);
            this.context.Mitarbeiters.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUpdated(Models.DbSinDarEla.Mitarbeiter item);
    partial void OnAfterMitarbeiterUpdated(Models.DbSinDarEla.Mitarbeiter item);

    [HttpPut("/odata/dbSinDarEla/Mitarbeiters(MitarbeiterID={MitarbeiterID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiter(int key, [FromBody]Models.DbSinDarEla.Mitarbeiter newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUpdated(newItem);
            this.context.Mitarbeiters.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten");
            this.OnAfterMitarbeiterUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Mitarbeiters(MitarbeiterID={MitarbeiterID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiter(int key, [FromBody]Delta<Models.DbSinDarEla.Mitarbeiter> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterUpdated(item);
            this.context.Mitarbeiters.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterCreated(Models.DbSinDarEla.Mitarbeiter item);
    partial void OnAfterMitarbeiterCreated(Models.DbSinDarEla.Mitarbeiter item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Mitarbeiter item)
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

            this.OnMitarbeiterCreated(item);
            this.context.Mitarbeiters.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterID;

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten");

            this.OnAfterMitarbeiterCreated(item);

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
