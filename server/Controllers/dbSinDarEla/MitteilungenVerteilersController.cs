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

  [Route("odata/dbSinDarEla/MitteilungenVerteilers")]
  public partial class MitteilungenVerteilersController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public MitteilungenVerteilersController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitteilungenVerteilers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitteilungenVerteiler> GetMitteilungenVerteilers()
    {
      var items = this.context.MitteilungenVerteilers.AsQueryable<Models.DbSinDarEla.MitteilungenVerteiler>();
      this.OnMitteilungenVerteilersRead(ref items);

      return items;
    }

    partial void OnMitteilungenVerteilersRead(ref IQueryable<Models.DbSinDarEla.MitteilungenVerteiler> items);

    partial void OnMitteilungenVerteilerGet(ref SingleResult<Models.DbSinDarEla.MitteilungenVerteiler> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/MitteilungenVerteilers(MitteilungVerteilerID={MitteilungVerteilerID})")]
    public SingleResult<MitteilungenVerteiler> GetMitteilungenVerteiler(int key)
    {
        var items = this.context.MitteilungenVerteilers.Where(i=>i.MitteilungVerteilerID == key);
        var result = SingleResult.Create(items);

        OnMitteilungenVerteilerGet(ref result);

        return result;
    }
    partial void OnMitteilungenVerteilerDeleted(Models.DbSinDarEla.MitteilungenVerteiler item);
    partial void OnAfterMitteilungenVerteilerDeleted(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpDelete("/odata/dbSinDarEla/MitteilungenVerteilers(MitteilungVerteilerID={MitteilungVerteilerID})")]
    public IActionResult DeleteMitteilungenVerteiler(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.MitteilungenVerteilers
                .Where(i => i.MitteilungVerteilerID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnMitteilungenVerteilerDeleted(item);
            this.context.MitteilungenVerteilers.Remove(item);
            this.context.SaveChanges();
            this.OnAfterMitteilungenVerteilerDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenVerteilerUpdated(Models.DbSinDarEla.MitteilungenVerteiler item);
    partial void OnAfterMitteilungenVerteilerUpdated(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpPut("/odata/dbSinDarEla/MitteilungenVerteilers(MitteilungVerteilerID={MitteilungVerteilerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitteilungenVerteiler(int key, [FromBody]Models.DbSinDarEla.MitteilungenVerteiler newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitteilungVerteilerID != key))
            {
                return BadRequest();
            }

            this.OnMitteilungenVerteilerUpdated(newItem);
            this.context.MitteilungenVerteilers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");
            this.OnAfterMitteilungenVerteilerUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/MitteilungenVerteilers(MitteilungVerteilerID={MitteilungVerteilerID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitteilungenVerteiler(int key, [FromBody]Delta<Models.DbSinDarEla.MitteilungenVerteiler> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnMitteilungenVerteilerUpdated(item);
            this.context.MitteilungenVerteilers.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenVerteilerCreated(Models.DbSinDarEla.MitteilungenVerteiler item);
    partial void OnAfterMitteilungenVerteilerCreated(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitteilungenVerteiler item)
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

            this.OnMitteilungenVerteilerCreated(item);
            this.context.MitteilungenVerteilers.Add(item);
            this.context.SaveChanges();

            var key = item.MitteilungVerteilerID;

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");

            this.OnAfterMitteilungenVerteilerCreated(item);

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
