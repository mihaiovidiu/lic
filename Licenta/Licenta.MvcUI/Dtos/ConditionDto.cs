using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Licenta.MvcUI.Dtos
{
    public class ConditionDto
    {
        public int ID { get; set; }
        public string medical_name { get; set; }
        public string popular_name { get; set; }
        public string desc { get; set; }
        public string other_details { get; set; }
        public string advice { get; set; }
        public int level { get; set; }
        public string comments { get; set; }
        public List<SymptomDto> symptoms { get; set; }
    }
}