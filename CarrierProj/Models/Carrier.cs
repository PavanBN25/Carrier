//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarrierProj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carrier
    {
        public int CarrierID { get; set; }
        public string MCNumber { get; set; }
        public Nullable<int> DOTNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string WebURL { get; set; }
        public Nullable<bool> Active { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
    
        public virtual State State { get; set; }
    }
}
