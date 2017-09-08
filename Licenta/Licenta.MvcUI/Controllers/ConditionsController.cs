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

        // GET: Conditions/Condition/1
        public ActionResult Condition(int id = -1)
        {
            Condition condition = null;
            if (id != -1)
            {
                condition = _dbContext.Conditions.Find(id);
                if (condition == null)
                    return HttpNotFound();
            }
            return View(condition);
        }
    }
}