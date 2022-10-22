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

  [Route("odata/dbSinDarEla/Bases")]
  public partial class BasesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public BasesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Bases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Base> GetBases()
    {
      var items = this.context.Bases.AsQueryable<Models.DbSinDarEla.Base>();
      this.OnBasesRead(ref items);

      return items;
    }

    partial void OnBasesRead(ref IQueryable<Models.DbSinDarEla.Base> items);

    partial void OnBaseGet(ref SingleResult<Models.DbSinDarEla.Base> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Bases(BaseID={BaseID})")]
    public SingleResult<Base> GetBase(int key)
    {
        var items = this.context.Bases.Where(i=>i.BaseID == key);
        var result = SingleResult.Create(items);

        OnBaseGet(ref result);

        return result;
    }
    partial void OnBaseDeleted(Models.DbSinDarEla.Base item);
    partial void OnAfterBaseDeleted(Models.DbSinDarEla.Base item);

    [HttpDelete("/odata/dbSinDarEla/Bases(BaseID={BaseID})")]
    public IActionResult DeleteBase(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Bases
                .Where(i => i.BaseID == key)
                .Include(i => i.Aufgabens)
                .Include(i => i.Aufgabens1)
                .Include(i => i.BaseKontaktes)
                .Include(i => i.Benutzers)
                .Include(i => i.Ereignisses)
                .Include(i => i.EreignisseTeilnehmers)
                .Include(i => i.Feedbacks)
                .Include(i => i.Kundens)
                .Include(i => i.KundenLeistungenBetreuers)
                .Include(i => i.Mitarbeiters)
                .Include(i => i.Mitteilungens)
                .Include(i => i.MitteilungenVerteilers)
                .Include(i => i.Protokolls)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBaseDeleted(item);
            this.context.Bases.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBaseDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseUpdated(Models.DbSinDarEla.Base item);
    partial void OnAfterBaseUpdated(Models.DbSinDarEla.Base item);

    [HttpPut("/odata/dbSinDarEla/Bases(BaseID={BaseID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBase(int key, [FromBody]Models.DbSinDarEla.Base newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BaseID != key))
            {
                return BadRequest();
            }

            this.OnBaseUpdated(newItem);
            this.context.Bases.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Bases.Where(i => i.BaseID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "BaseAnreden");
            this.OnAfterBaseUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Bases(BaseID={BaseID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBase(int key, [FromBody]Delta<Models.DbSinDarEla.Base> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Bases.Where(i => i.BaseID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBaseUpdated(item);
            this.context.Bases.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Bases.Where(i => i.BaseID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "BaseAnreden");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseCreated(Models.DbSinDarEla.Base item);
    partial void OnAfterBaseCreated(Models.DbSinDarEla.Base item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Base item)
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

            this.OnBaseCreated(item);
            this.context.Bases.Add(item);
            this.context.SaveChanges();

            var key = item.BaseID;

            var itemToReturn = this.context.Bases.Where(i => i.BaseID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "BaseAnreden");

            this.OnAfterBaseCreated(item);

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
