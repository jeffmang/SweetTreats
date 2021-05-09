using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CapgeminiSweetTreats.Models;

namespace CapgeminiSweetTreats.Views
{

    /*
     * Class to collect input data from the user
     */
    public class BestTransporterView
    {
        /*
         * Read the input for Time, Distance and Required Refridgeration from the user
         */
        public TransporterViewInput GetInput()
        {
            TransporterViewInput data = new TransporterViewInput();

            Console.Write("Enter Time of Day HH:MM format :");
            data.Time = Console.ReadLine().Trim();
            Console.Write("Enter Distance in Miles :");
            data.Distance = Console.ReadLine().Trim();
            Console.Write("Require Refridgeration (Y=Yes, N=No) :");
            data.RefrigerationRequired = Console.ReadLine().Trim();

            return data;
        }

        /*
         * Validate the Time is value time in 00:00 to 23:59
         */
        public Tuple<int,string> ValidateTime(String strTime)
        {
            strTime = strTime.Trim();
            int time = -1;
            String error = "";
            String timePattern = "^([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";
            Regex rgx = new Regex(timePattern);
            Match match = rgx.Match(strTime);
            if (match.Success == false)
            {
                error = "Time format needs to be HH:MM for 1pm enter 13:00; ";
            }
            else
            {
                time = int.Parse(match.Groups[1].Value)*60 + int.Parse(match.Groups[2].Value);
            }
            return new Tuple<int,string>(time, error);
        }

        /*
         * Validate distance is a number
         */
        public Tuple<int,string> ValidateDistance(String dist)
        {
            String error = "";
            int distance = -1;
            if (! int.TryParse(dist, out distance))
            {
                error = "Distance needs needs to be an integer; ";
                distance = -1;
            } 
            else if (distance <= 0)
            {
                error = "Invalid Distance.  The Distance must be greater than 0.";
                distance = -1;
            }
            return new Tuple<int, string>(distance, error);
        }

        /*
         * Validate Refridgeration Required is True or False (Y or N)
         */
        public Tuple<bool, string> ValidateRefridgerationRequired(string refRequired)
        {
            string error = "";
            refRequired = refRequired.Trim().ToUpper();

            bool refridgerationRequired = false;
            if (refRequired == "Y" || refRequired == "N")
            {
                refridgerationRequired = refRequired == "Y";
            }
            else
            {
                error += "Refridgeration Required value needs to be Y or N; ";
            }

            return new Tuple<bool, string>(refridgerationRequired, error);
        }

        
        /*
         * Validate all the input (Time, Distance and Refridge Required)
         */
        public Tuple<TransporterQueryInput, string> ValidateAll(TransporterViewInput userInput)
        {
            string error = "";
            TransporterQueryInput tqi = new TransporterQueryInput();

            Tuple<int, string> tupTime = ValidateTime(userInput.Time);
            if (tupTime.Item2.Length > 0)
            {
                tqi.Time = -1;
                error += tupTime.Item2;
            }
            else
            {
                tqi.Time = tupTime.Item1;
            }

            Tuple<int, string> tupDist = ValidateDistance(userInput.Distance);
            if (tupDist.Item2.Length > 0)
            {
                tqi.Distance = -1;
                error += tupDist.Item2;
            }
            else
            {
                tqi.Distance = tupDist.Item1;
            }

            Tuple<bool, string> tupRefrig = ValidateRefridgerationRequired(userInput.RefrigerationRequired);
            if (tupRefrig.Item2.Length > 0)
            {
                tqi.RefrigerationRequired = false;
                error += tupRefrig.Item2;
            }
            else
            {
                tqi.RefrigerationRequired = tupRefrig.Item1;
            }

            return new Tuple<TransporterQueryInput, string>(tqi, error);
        }
    }
}
