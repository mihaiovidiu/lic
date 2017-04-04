using Licenta.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Licenta.MvcUI.ViewModels
{
    public class CategoryOfSymptoms
    {
        public IEnumerable<Symptom> Symptoms;
        public String CategoryName { get; set; }

        public CategoryOfSymptoms(string categoryName, IEnumerable<Symptom> symptoms)
        {
            this.Symptoms = symptoms;
            this.CategoryName = categoryName;
        }
    }
}