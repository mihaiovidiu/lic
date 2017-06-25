using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Licenta.MvcUI.Dtos
{
    public class SymptomDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string desc { get; set; }
        public string comments { get; set; }
        public string bodyPart { get; set; }
    }
}