using Licenta.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Licenta.MvcUI.Controllers.Api
{
    public class SymptomsController : ApiController
    {
        LicentaEntities dbContext = null;

        public SymptomsController()
        {
            this.dbContext = new LicentaEntities();
        }

        protected override void Dispose(bool disposing)
        {
            this.dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET /api/symptoms
        public IHttpActionResult GetSymptoms()
        {
            List<Symptom> symptomsByBodyPart = dbContext.Symptoms.ToList();
            if (symptomsByBodyPart == null)
                return NotFound();
            else
                return Ok(symptomsByBodyPart);
        }

        // GET /api/symptoms/id
        public IHttpActionResult GetSymptomsByBodyPart(string id)
        {
            List<Symptom> symptomsByBodyPart = dbContext.Symptoms.Where(s => s.bodyPart == id).ToList();
            if (symptomsByBodyPart == null)
                return NotFound();
            else
                return Ok(symptomsByBodyPart);
        }
    }
}
