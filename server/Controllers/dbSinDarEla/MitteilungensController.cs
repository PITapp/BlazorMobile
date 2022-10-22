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

  [Route("odata/dbSinDarEla/Mitteilungens")]
  public partial class MitteilungensController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitteilungensController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Mitteilungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Mitteilungen> GetMitteilungens()
    {
      var items = this.context.Mitteilungens.AsQueryable<Models.DbSinDarEla.Mitteilungen>();
      this.OnMitteilungensRead(ref items);

      return items;
    }

    partial void OnMitteilungensRead(ref IQueryable<Models.DbSinDarEla.Mitteilungen> items);

    partial void OnMitteilungenGet(ref SingleResult<Models.DbSinDarEla.Mitteilungen> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Mitteilungens(MitteilungID={MitteilungID})")]
    public SingleResult<Mitteilungen> GetMitteilungen(int key)
    {
        var items = this.context.Mitteilungens.Where(i=>i.MitteilungID == key);
        var result = SingleResult.Create(items);

        OnMitteilungenGet(ref result);

        return result;
    }
    partial void OnMitteilungenDeleted(Models.DbSinDarEla.Mitteilungen item);
    partial void OnAfterMitteilungenDeleted(Models.DbSinDarEla.Mitteilungen item);

    [HttpDelete("/odata/dbSinDarEla/Mitteilungens(MitteilungID={MitteilungID})")]
    public IActionResult DeleteMitteilungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Mitteilungens
                .Where(i => i.MitteilungID == key)
                .Include(i => i.MitteilungenVerteilers)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitteilungenDeleted(item);
            this.context.Mitteilungens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitteilungenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenUpdated(Models.DbSinDarEla.Mitteilungen item);
    partial void OnAfterMitteilungenUpdated(Models.DbSinDarEla.Mitteilungen item);

    [HttpPut("/odata/dbSinDarEla/Mitteilungens(MitteilungID={MitteilungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitteilungen(int key, [FromBody]Models.DbSinDarEla.Mitteilungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitteilungID != key))
            {
                return BadRequest();
            }

            this.OnMitteilungenUpdated(newItem);
            this.context.Mitteilungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");
            this.OnAfterMitteilungenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Mitteilungens(MitteilungID={MitteilungID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitteilungen(int key, [FromBody]Delta<Models.DbSinDarEla.Mitteilungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Mitteilungens.Where(i => i.MitteilungID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitteilungenUpdated(item);
            this.context.Mitteilungens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenCreated(Models.DbSinDarEla.Mitteilungen item);
    partial void OnAfterMitteilungenCreated(Models.DbSinDarEla.Mitteilungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Mitteilungen item)
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

            this.OnMitteilungenCreated(item);
            this.context.Mitteilungens.Add(item);
            this.context.SaveChanges();

            var key = item.MitteilungID;

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");

            this.OnAfterMitteilungenCreated(item);

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
