using Licenta.DAL;
using Licenta.MvcUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Licenta.MvcUI.Controllers
{
    [Authorize]
    public class SymptomsController : Controller
    {
        LicentaEntities _dbContext = null;

        public SymptomsController()
        {
            _dbContext = new LicentaEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Symptoms
        public ActionResult Index()
        {
            // get all symptoms from database
            List<Symptom> symptoms = _dbContext.Symptoms.ToList();

            // get all distinct categories from the MEMORY list (not the database)
            List<string> symptomsCategory = symptoms.Select(s => s.category).Distinct().ToList();

            // create the list of CategoryOfSymptoms objects
            List<CategoryOfSymptoms> catOfSymptoms = new List<CategoryOfSymptoms>();
            // foreach category name, query the MEMORY list of symptoms for the appropriate symptoms
            foreach (string categoryName in symptomsCategory)
            {
                CategoryOfSymptoms cOfSymptoms = new CategoryOfSymptoms(
                    categoryName,
                    symptoms.Where(s => s.category == categoryName).ToList());
                catOfSymptoms.Add(cOfSymptoms);
            } 
            
            return View(catOfSymptoms);
        }
    }
}