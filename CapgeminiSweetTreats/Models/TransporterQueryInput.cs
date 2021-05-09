using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiSweetTreats.Models
{
    /*
     *  Class holds input data from the user after it has been converted to binary data from string input. This model is what is sent to the controller for processing.
     */
    public class TransporterQueryInput
    {
        public int Time {get; set;}                         // time in minutes I.E. 540 is 9am
        public int Distance { get; set; }                   // distance in miles to destination
        public bool RefrigerationRequired { get; set; }     // Is Refrigeration required for this transport job

    }
}
