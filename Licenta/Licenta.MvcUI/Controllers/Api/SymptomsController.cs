using AutoMapper;
using Licenta.DAL;
using Licenta.MvcUI.Dtos;
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
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            this.dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET /api/symptoms
        public IHttpActionResult GetSymptoms()
        {
            var allSymptoms = dbContext.Symptoms.ToList();
            if (allSymptoms == null)
                return NotFound();
            else
                return Ok(allSymptoms.Select(Mapper.Map<Symptom, SymptomDto>));
        }

        // GET /api/symptoms/id
        [System.Web.Http.Route("api/symptoms/{bodyPart}")]
        public IHttpActionResult GetSymptomsByBodyPart(string bodyPart)
        {
            List<Symptom> symptomsByBodyPart = dbContext.Symptoms.Where(s => s.bodyPart == bodyPart).ToList();
            if (symptomsByBodyPart == null)
                return NotFound();
            else
                return Ok(symptomsByBodyPart.Select(Mapper.Map<Symptom, SymptomDto>));
        }
    }
}
