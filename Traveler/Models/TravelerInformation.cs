//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Traveler.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TravelerInformation
    {
        public int ID { get; set; }
        public Nullable<int> IDBooking { get; set; }
        public string CodeTicket { get; set; }
        public string Gender { get; set; }
        public Nullable<byte> PassengerAge { get; set; }
    
        public virtual Book Book { get; set; }
    }
}
