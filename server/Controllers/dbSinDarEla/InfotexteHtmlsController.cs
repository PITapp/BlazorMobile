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

  [Route("odata/dbSinDarEla/InfotexteHtmls")]
  public partial class InfotexteHtmlsController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public InfotexteHtmlsController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/InfotexteHtmls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.InfotexteHtml> GetInfotexteHtmls()
    {
      var items = this.context.InfotexteHtmls.AsQueryable<Models.DbSinDarEla.InfotexteHtml>();
      this.OnInfotexteHtmlsRead(ref items);

      return items;
    }

    partial void OnInfotexteHtmlsRead(ref IQueryable<Models.DbSinDarEla.InfotexteHtml> items);

    partial void OnInfotexteHtmlGet(ref SingleResult<Models.DbSinDarEla.InfotexteHtml> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/InfotexteHtmls(InfotextID={InfotextID})")]
    public SingleResult<InfotexteHtml> GetInfotexteHtml(int key)
    {
        var items = this.context.InfotexteHtmls.Where(i=>i.InfotextID == key);
        var result = SingleResult.Create(items);

        OnInfotexteHtmlGet(ref result);

        return result;
    }
    partial void OnInfotexteHtmlDeleted(Models.DbSinDarEla.InfotexteHtml item);
    partial void OnAfterInfotexteHtmlDeleted(Models.DbSinDarEla.InfotexteHtml item);

    [HttpDelete("/odata/dbSinDarEla/InfotexteHtmls(InfotextID={InfotextID})")]
    public IActionResult DeleteInfotexteHtml(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.InfotexteHtmls
                .Where(i => i.InfotextID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnInfotexteHtmlDeleted(item);
            this.context.InfotexteHtmls.Remove(item);
            this.context.SaveChanges();
            this.OnAfterInfotexteHtmlDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInfotexteHtmlUpdated(Models.DbSinDarEla.InfotexteHtml item);
    partial void OnAfterInfotexteHtmlUpdated(Models.DbSinDarEla.InfotexteHtml item);

    [HttpPut("/odata/dbSinDarEla/InfotexteHtmls(InfotextID={InfotextID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInfotexteHtml(int key, [FromBody]Models.DbSinDarEla.InfotexteHtml newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.InfotextID != key))
            {
                return BadRequest();
            }

            this.OnInfotexteHtmlUpdated(newItem);
            this.context.InfotexteHtmls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InfotexteHtmls.Where(i => i.InfotextID == key);
            this.OnAfterInfotexteHtmlUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/InfotexteHtmls(InfotextID={InfotextID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInfotexteHtml(int key, [FromBody]Delta<Models.DbSinDarEla.InfotexteHtml> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.InfotexteHtmls.Where(i => i.InfotextID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnInfotexteHtmlUpdated(item);
            this.context.InfotexteHtmls.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.InfotexteHtmls.Where(i => i.InfotextID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInfotexteHtmlCreated(Models.DbSinDarEla.InfotexteHtml item);
    partial void OnAfterInfotexteHtmlCreated(Models.DbSinDarEla.InfotexteHtml item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.InfotexteHtml item)
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

            this.OnInfotexteHtmlCreated(item);
            this.context.InfotexteHtmls.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterInfotexteHtmlCreated(item);
            
            return Created($"odata/DbSinDarEla/InfotexteHtmls/{item.InfotextID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
