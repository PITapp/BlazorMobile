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

  [Route("odata/dbSinDarEla/DeviceCodes")]
  public partial class DeviceCodesController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public DeviceCodesController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/DeviceCodes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.DeviceCode> GetDeviceCodes()
    {
      var items = this.context.DeviceCodes.AsQueryable<Models.DbSinDarEla.DeviceCode>();
      this.OnDeviceCodesRead(ref items);

      return items;
    }

    partial void OnDeviceCodesRead(ref IQueryable<Models.DbSinDarEla.DeviceCode> items);

    partial void OnDeviceCodeGet(ref SingleResult<Models.DbSinDarEla.DeviceCode> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/DeviceCodes(UserCode={UserCode})")]
    public SingleResult<DeviceCode> GetDeviceCode(string key)
    {
        var items = this.context.DeviceCodes.Where(i=>i.UserCode == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnDeviceCodeGet(ref result);

        return result;
    }
    partial void OnDeviceCodeDeleted(Models.DbSinDarEla.DeviceCode item);
    partial void OnAfterDeviceCodeDeleted(Models.DbSinDarEla.DeviceCode item);

    [HttpDelete("/odata/dbSinDarEla/DeviceCodes(UserCode={UserCode})")]
    public IActionResult DeleteDeviceCode(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.DeviceCodes
                .Where(i => i.UserCode == Uri.UnescapeDataString(key))
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDeviceCodeDeleted(item);
            this.context.DeviceCodes.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDeviceCodeDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeviceCodeUpdated(Models.DbSinDarEla.DeviceCode item);
    partial void OnAfterDeviceCodeUpdated(Models.DbSinDarEla.DeviceCode item);

    [HttpPut("/odata/dbSinDarEla/DeviceCodes(UserCode={UserCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDeviceCode(string key, [FromBody]Models.DbSinDarEla.DeviceCode newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.UserCode != Uri.UnescapeDataString(key)))
            {
                return BadRequest();
            }

            this.OnDeviceCodeUpdated(newItem);
            this.context.DeviceCodes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key));
            this.OnAfterDeviceCodeUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/DeviceCodes(UserCode={UserCode})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDeviceCode(string key, [FromBody]Delta<Models.DbSinDarEla.DeviceCode> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key)).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDeviceCodeUpdated(item);
            this.context.DeviceCodes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeviceCodes.Where(i => i.UserCode == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeviceCodeCreated(Models.DbSinDarEla.DeviceCode item);
    partial void OnAfterDeviceCodeCreated(Models.DbSinDarEla.DeviceCode item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.DeviceCode item)
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

            this.OnDeviceCodeCreated(item);
            this.context.DeviceCodes.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterDeviceCodeCreated(item);
            
            return Created($"odata/DbSinDarEla/DeviceCodes/{item.UserCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
