//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlatDiplom.Models.PlatModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccessLogWeb
    {
        public int id_inout { get; set; }
        public Nullable<System.DateTime> time_checkin { get; set; }
        public Nullable<System.DateTime> time_checkout { get; set; }
        public Nullable<int> user_id { get; set; }
        public string username { get; set; }
        public string pageurl { get; set; }
        public string ip_user { get; set; }
        public string comp_user { get; set; }
        public string comments { get; set; }
    
        public virtual Users Users { get; set; }
    }
}