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
    
    public partial class users_symptoms
    {
        public int Id { get; set; }
        public string IDU { get; set; }
        public int IDs { get; set; }
        public Nullable<System.DateTime> observation_date { get; set; }
        public Nullable<System.TimeSpan> observation_time { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Symptom symptom { get; set; }
    }
}
