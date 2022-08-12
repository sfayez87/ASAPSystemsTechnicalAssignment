using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TechnicalAssignment.Models;

namespace TechnicalAssignment.Controllers
{
    public class AssetsController : ApiController
    {
        private AssetsModel db = new AssetsModel();

        // GET: api/Assets
        public IHttpActionResult GetAssets()
        {
            return Json(db.Assets.ToList());
        }
    }
}