using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiSweetTreats.Models
{
    /*
     * Class used to return the final results of which transporter to use from the Controller
     */
    public class BestTransporter
    {
        public String Name { get; set; }
        public double? Cost { get; set; }
        public String Error { get; set; }
        public bool FoundTransporterToUse { get; set; }
    }
}
