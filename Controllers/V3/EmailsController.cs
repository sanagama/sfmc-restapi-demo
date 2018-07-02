using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Specialized;
using SfmcRestApiDemo.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SfmcRestApiDemo.Controllers.V3
{
    // This Controller implements support only for API v3
    [ApiVersion( "3.0" )]
    [Route( "api/v{version:apiVersion}/[controller]" )]  
    public class EmailsController : Controller
    {
        private readonly SfmcContext _context;
    
        public EmailsController(SfmcContext context)
        {
            this._context = context;
        }
    
        // GET ~/v3/emails/mid
        // This route is only available in API v3
        [HttpGet( "{mid}" )]
        [MapToApiVersion("3.0")]
        public IActionResult GetEmailByMID(int mid)
        {
            Log.Information("V3 API - GetEmailByMID called for MID: {0}", mid);

            // Retrieve an Email object by messageKey
            var result = this._context.Emails.Where(e => e.MID == mid).FirstOrDefault();
            if(result == null)
            {
                Log.Information("Email with MID {0} not found", mid);
                return NotFound();
            }
            else
            {
                Log.Warning("Email with MID {0} found", mid);
                return Ok(result);
            }
        }
    }
}