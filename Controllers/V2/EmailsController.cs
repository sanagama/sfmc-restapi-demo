using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Specialized;
using SfmcRestApiDemo.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SfmcRestApiDemo.Controllers.V2
{
    // This Controller implements routes for 3 different API versions
    [ApiVersion( "1.0", Deprecated = true)]
    [ApiVersion( "2.0" )]
    [ApiVersion( "3.0" )]
    [Route( "api/v{version:apiVersion}/[controller]" )]  
    public class EmailsController : Controller
    {
        private readonly SfmcContext _context;
    
        public EmailsController(SfmcContext context)
        {
            this._context = context;
        }
    
        // GET ~/v2/emails/
        // This route is available in API v2 and API v3
        [HttpGet]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("3.0")]
        public IActionResult GetAllEmails()
        {
            Log.Information("GetEmails called - API is available in V2 and V3");
            var results = this._context.Emails
                            .Include(email => email.Contents)
                            .Include(email => email.BusinessUnit)
                            .ToList();
            return Ok(results);
        }

        // GET ~/v3/emails/messageKey
        // This route is only available in API v3
        [HttpGet( "{messageKey}" )]
        [MapToApiVersion("3.0")]
        public IActionResult GetEmailByKey(int messageKey)
        {
            Log.Information("V3 API - GetEmailByKey called for messageKey: {0}", messageKey);

            // Retrieve an Email object by messageKey
            var q = this._context.Emails
                    .Include(email => email.Contents)
                    .ToList()
                    .AsQueryable();

            var result = q.Where(e => e.MessageKey == messageKey).FirstOrDefault();
            if(result == null)
            {
                Log.Information("Email with messageKey {0} not found", messageKey);
                return NotFound();
            }
            else
            {
                Log.Warning("Email with messageKey {0} found", messageKey);
                var retval = new
                {
                    messageKey = result.MessageKey,
                    mid = result.MID,
                    contents = result.Contents
                };
                return Ok(retval);
            }
        }
    }
}