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

  [Route("odata/dbSinDarEla/MitarbeiterFortbildungens")]
  public partial class MitarbeiterFortbildungensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitarbeiterFortbildungensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterFortbildungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterFortbildungen> GetMitarbeiterFortbildungens()
    {
      var items = this.context.MitarbeiterFortbildungens.AsQueryable<Models.DbSinDarEla.MitarbeiterFortbildungen>();
      this.OnMitarbeiterFortbildungensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterFortbildungensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungen> items);

    partial void OnMitarbeiterFortbildungenGet(ref SingleResult<Models.DbSinDarEla.MitarbeiterFortbildungen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitarbeiterFortbildungens(MitarbeiterFortbildungID={MitarbeiterFortbildungID})")]
    public SingleResult<MitarbeiterFortbildungen> GetMitarbeiterFortbildungen(int key)
    {
        var items = this.context.MitarbeiterFortbildungens.Where(i=>i.MitarbeiterFortbildungID == key);
        var result = SingleResult.Create(items);

        OnMitarbeiterFortbildungenGet(ref result);

        return result;
    }
    partial void OnMitarbeiterFortbildungenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungen item);
    partial void OnAfterMitarbeiterFortbildungenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpDelete("/odata/dbSinDarEla/MitarbeiterFortbildungens(MitarbeiterFortbildungID={MitarbeiterFortbildungID})")]
    public IActionResult DeleteMitarbeiterFortbildungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitarbeiterFortbildungens
                .Where(i => i.MitarbeiterFortbildungID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenDeleted(item);
            this.context.MitarbeiterFortbildungens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitarbeiterFortbildungenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungen item);
    partial void OnAfterMitarbeiterFortbildungenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpPut("/odata/dbSinDarEla/MitarbeiterFortbildungens(MitarbeiterFortbildungID={MitarbeiterFortbildungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterFortbildungen(int key, [FromBody]Models.DbSinDarEla.MitarbeiterFortbildungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterFortbildungID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenUpdated(newItem);
            this.context.MitarbeiterFortbildungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");
            this.OnAfterMitarbeiterFortbildungenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitarbeiterFortbildungens(MitarbeiterFortbildungID={MitarbeiterFortbildungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterFortbildungen(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterFortbildungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitarbeiterFortbildungenUpdated(item);
            this.context.MitarbeiterFortbildungens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenCreated(Models.DbSinDarEla.MitarbeiterFortbildungen item);
    partial void OnAfterMitarbeiterFortbildungenCreated(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterFortbildungen item)
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

            this.OnMitarbeiterFortbildungenCreated(item);
            this.context.MitarbeiterFortbildungens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterFortbildungID;

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");

            this.OnAfterMitarbeiterFortbildungenCreated(item);

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
