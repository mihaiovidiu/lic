using AutoMapper;
using Licenta.DAL;
using Licenta.MvcUI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Licenta.MvcUI.Controllers.Api
{
    public class ConditionsController : ApiController
    {
        LicentaEntities dbContext = null;

        public ConditionsController()
        {
            this.dbContext = new LicentaEntities();
        }

        protected override void Dispose(bool disposing)
        {
            this.dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET /api/conditions/conditionsByName?query=%QUERY
        [Route("api/conditions/conditionsByName")]
        public IHttpActionResult GetConditionsByName(string query = null)
        {
            var conditionsQuery = this.dbContext.Conditions.AsQueryable();
            if (!string.IsNullOrEmpty(query))
                conditionsQuery = conditionsQuery
                    .Where(c => c.medical_name.Contains(query));
            var listToReturn = conditionsQuery.Select(cond => new { Id = cond.ID, MedicalName = cond.medical_name }).ToList().
                Select(item => new ConditionShortDto { ID = item.Id, medical_name = item.MedicalName });
            return Ok(listToReturn);
        }

        [Route("api/conditions/conditionById/{id}")]
        public IHttpActionResult GetConditionById(int id)
        {
            var condition = this.dbContext.Conditions.Find(id);
            if (condition == null)
                return NotFound();
            return Ok(Mapper.Map<ConditionDto>(condition));
        }

        [Route("api/conditions/conditionsBySymptoms/{*symptomIds}")]
        public IHttpActionResult GetConditionsForSymptoms([FromUri] int[] symptomsIds)
        {
            var conditions = this.dbContext.Conditions.Where(condition =>
                   symptomsIds.All(sId => condition.symptoms_conditions.Select(sc => sc.symptom.Id).Contains(sId)))
                   .Select(cond => new { Id = cond.ID, MedicalName = cond.medical_name });
            var listToReturn = conditions.ToList().Select(item => new ConditionShortDto { ID = item.Id, medical_name = item.MedicalName });
            return Ok(listToReturn);

        }
    }
}
