using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiSweetTreats.Models
{
    /*
     *  Class is model of a person that does transport for Sweet Treats that is read in from a JSON file that describes the capabilities of each transporter
     */
    public class Transporter
    {
        public string Name { get; set; }                // Name of person doing transport
        public int StartTime { get; set; }              // Start time for accepting deliveries in minutes. I.E.  60 would be 1am, 720 would be noon.
        public int EndTime { get; set; }                // End time for accepting deliveries in minutes. I.E.  60 would be 1am, 720 would be noon.
        public double CostPerMile { get; set; }         // Dollar cost per mile for this transporter
        public bool RefridgeratedBox { get; set; }      // True if transporter supports Refridgeration on their vehicle
    }
}
