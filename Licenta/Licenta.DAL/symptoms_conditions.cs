//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licenta.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class symptoms_conditions
    {
        public int Id { get; set; }
        public int IDc { get; set; }
        public int IDs { get; set; }
        public string probability { get; set; }
        public string comments { get; set; }
    
        public virtual Condition condition { get; set; }
        public virtual Symptom symptom { get; set; }
    }
}