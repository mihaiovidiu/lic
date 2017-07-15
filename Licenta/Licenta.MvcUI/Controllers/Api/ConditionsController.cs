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

        // GET /api/conditions?query=%QUERY
        public IHttpActionResult GetConditions(string query = null)
        {
            var conditionsQuery = this.dbContext.Conditions.AsQueryable();
            if (!string.IsNullOrEmpty(query))
                conditionsQuery = conditionsQuery
                    .Where(c => c.medical_name.Contains(query));
            var listToReturn = conditionsQuery.ToList().Select(Mapper.Map<Condition, ConditionDto>);
            return Ok(listToReturn);
        }
    }
}
