using Licenta.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Licenta.MvcUI.Controllers
{
    public class ConditionsController : Controller
    {
        LicentaEntities _dbContext = null;

        public ConditionsController()
        {
            _dbContext = new LicentaEntities();        
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Conditions
        public ActionResult Index()
        {
            return View();
        }
    }
}