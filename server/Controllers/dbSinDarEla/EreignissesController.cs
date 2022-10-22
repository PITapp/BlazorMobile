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

  [Route("odata/dbSinDarEla/Ereignisses")]
  public partial class EreignissesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public EreignissesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Ereignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Ereignisse> GetEreignisses()
    {
      var items = this.context.Ereignisses.AsQueryable<Models.DbSinDarEla.Ereignisse>();
      this.OnEreignissesRead(ref items);

      return items;
    }

    partial void OnEreignissesRead(ref IQueryable<Models.DbSinDarEla.Ereignisse> items);

    partial void OnEreignisseGet(ref SingleResult<Models.DbSinDarEla.Ereignisse> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Ereignisses(EreignisID={EreignisID})")]
    public SingleResult<Ereignisse> GetEreignisse(int key)
    {
        var items = this.context.Ereignisses.Where(i=>i.EreignisID == key);
        var result = SingleResult.Create(items);

        OnEreignisseGet(ref result);

        return result;
    }
    partial void OnEreignisseDeleted(Models.DbSinDarEla.Ereignisse item);
    partial void OnAfterEreignisseDeleted(Models.DbSinDarEla.Ereignisse item);

    [HttpDelete("/odata/dbSinDarEla/Ereignisses(EreignisID={EreignisID})")]
    public IActionResult DeleteEreignisse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Ereignisses
                .Where(i => i.EreignisID == key)
                .Include(i => i.EreignisseTeilnehmers)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEreignisseDeleted(item);
            this.context.Ereignisses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEreignisseDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseUpdated(Models.DbSinDarEla.Ereignisse item);
    partial void OnAfterEreignisseUpdated(Models.DbSinDarEla.Ereignisse item);

    [HttpPut("/odata/dbSinDarEla/Ereignisses(EreignisID={EreignisID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisse(int key, [FromBody]Models.DbSinDarEla.Ereignisse newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseUpdated(newItem);
            this.context.Ereignisses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");
            this.OnAfterEreignisseUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Ereignisses(EreignisID={EreignisID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisse(int key, [FromBody]Delta<Models.DbSinDarEla.Ereignisse> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Ereignisses.Where(i => i.EreignisID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEreignisseUpdated(item);
            this.context.Ereignisses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseCreated(Models.DbSinDarEla.Ereignisse item);
    partial void OnAfterEreignisseCreated(Models.DbSinDarEla.Ereignisse item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Ereignisse item)
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

            this.OnEreignisseCreated(item);
            this.context.Ereignisses.Add(item);
            this.context.SaveChanges();

            var key = item.EreignisID;

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");

            this.OnAfterEreignisseCreated(item);

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
