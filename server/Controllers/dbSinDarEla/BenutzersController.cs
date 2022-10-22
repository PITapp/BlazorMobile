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

  [Route("odata/dbSinDarEla/Benutzers")]
  public partial class BenutzersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BenutzersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Benutzers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Benutzer> GetBenutzers()
    {
      var items = this.context.Benutzers.AsQueryable<Models.DbSinDarEla.Benutzer>();
      this.OnBenutzersRead(ref items);

      return items;
    }

    partial void OnBenutzersRead(ref IQueryable<Models.DbSinDarEla.Benutzer> items);

    partial void OnBenutzerGet(ref SingleResult<Models.DbSinDarEla.Benutzer> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Benutzers(BenutzerID={BenutzerID})")]
    public SingleResult<Benutzer> GetBenutzer(int key)
    {
        var items = this.context.Benutzers.Where(i=>i.BenutzerID == key);
        var result = SingleResult.Create(items);

        OnBenutzerGet(ref result);

        return result;
    }
    partial void OnBenutzerDeleted(Models.DbSinDarEla.Benutzer item);
    partial void OnAfterBenutzerDeleted(Models.DbSinDarEla.Benutzer item);

    [HttpDelete("/odata/dbSinDarEla/Benutzers(BenutzerID={BenutzerID})")]
    public IActionResult DeleteBenutzer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Benutzers
                .Where(i => i.BenutzerID == key)
                .Include(i => i.BenutzerModules)
                .Include(i => i.BenutzerProtokolls)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBenutzerDeleted(item);
            this.context.Benutzers.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBenutzerDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerUpdated(Models.DbSinDarEla.Benutzer item);
    partial void OnAfterBenutzerUpdated(Models.DbSinDarEla.Benutzer item);

    [HttpPut("/odata/dbSinDarEla/Benutzers(BenutzerID={BenutzerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzer(int key, [FromBody]Models.DbSinDarEla.Benutzer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerUpdated(newItem);
            this.context.Benutzers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            this.OnAfterBenutzerUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Benutzers(BenutzerID={BenutzerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzer(int key, [FromBody]Delta<Models.DbSinDarEla.Benutzer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Benutzers.Where(i => i.BenutzerID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBenutzerUpdated(item);
            this.context.Benutzers.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerCreated(Models.DbSinDarEla.Benutzer item);
    partial void OnAfterBenutzerCreated(Models.DbSinDarEla.Benutzer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Benutzer item)
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

            this.OnBenutzerCreated(item);
            this.context.Benutzers.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerID;

            var itemToReturn = this.context.Benutzers.Where(i => i.BenutzerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

            this.OnAfterBenutzerCreated(item);

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
