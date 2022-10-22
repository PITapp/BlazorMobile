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

  [Route("odata/dbSinDarEla/Feedbacks")]
  public partial class FeedbacksController : ODataController
  {
    private SinDarElaMobile.Data.DbSinDarElaContext context;

    public FeedbacksController(SinDarElaMobile.Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Feedbacks
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Feedback> GetFeedbacks()
    {
      var items = this.context.Feedbacks.AsQueryable<Models.DbSinDarEla.Feedback>();
      this.OnFeedbacksRead(ref items);

      return items;
    }

    partial void OnFeedbacksRead(ref IQueryable<Models.DbSinDarEla.Feedback> items);

    partial void OnFeedbackGet(ref SingleResult<Models.DbSinDarEla.Feedback> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/dbSinDarEla/Feedbacks(FeedbackID={FeedbackID})")]
    public SingleResult<Feedback> GetFeedback(int key)
    {
        var items = this.context.Feedbacks.Where(i=>i.FeedbackID == key);
        var result = SingleResult.Create(items);

        OnFeedbackGet(ref result);

        return result;
    }
    partial void OnFeedbackDeleted(Models.DbSinDarEla.Feedback item);
    partial void OnAfterFeedbackDeleted(Models.DbSinDarEla.Feedback item);

    [HttpDelete("/odata/dbSinDarEla/Feedbacks(FeedbackID={FeedbackID})")]
    public IActionResult DeleteFeedback(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Feedbacks
                .Where(i => i.FeedbackID == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnFeedbackDeleted(item);
            this.context.Feedbacks.Remove(item);
            this.context.SaveChanges();
            this.OnAfterFeedbackDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFeedbackUpdated(Models.DbSinDarEla.Feedback item);
    partial void OnAfterFeedbackUpdated(Models.DbSinDarEla.Feedback item);

    [HttpPut("/odata/dbSinDarEla/Feedbacks(FeedbackID={FeedbackID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutFeedback(int key, [FromBody]Models.DbSinDarEla.Feedback newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FeedbackID != key))
            {
                return BadRequest();
            }

            this.OnFeedbackUpdated(newItem);
            this.context.Feedbacks.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            this.OnAfterFeedbackUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/dbSinDarEla/Feedbacks(FeedbackID={FeedbackID})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchFeedback(int key, [FromBody]Delta<Models.DbSinDarEla.Feedback> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Feedbacks.Where(i => i.FeedbackID == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnFeedbackUpdated(item);
            this.context.Feedbacks.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFeedbackCreated(Models.DbSinDarEla.Feedback item);
    partial void OnAfterFeedbackCreated(Models.DbSinDarEla.Feedback item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Feedback item)
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

            this.OnFeedbackCreated(item);
            this.context.Feedbacks.Add(item);
            this.context.SaveChanges();

            var key = item.FeedbackID;

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

            this.OnAfterFeedbackCreated(item);

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
