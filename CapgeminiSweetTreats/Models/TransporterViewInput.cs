using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiSweetTreats.Models
{
    /* 
     *  This class holds the raw string data from the user input for the Time, Distance and Refrig required data.
     */
    public class TransporterViewInput
    {
        public string Time { get; set; }     //raw string input of time in HH:MM format
        public string Distance { get; set; } //raw string input of distance in miles
        public string RefrigerationRequired { get; set; }  //raw input Y or N
    }
}

