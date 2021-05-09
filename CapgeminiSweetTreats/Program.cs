using CapgeminiSweetTreats.Controllers;
using CapgeminiSweetTreats.Models;
using CapgeminiSweetTreats.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace CapgeminiSweetTreats
{
    class Program
    {
        /*
         * Entry point for SweetTreats application.  
         * 
         * Sweet Treats store is now open for deliveries direct to your door.  Sweet Treats has three contracted cycle-couriers who deliver products to customers. The couriers charge different rates, have different working hours and different facilities available.  Sweet Treats needs to select the most appropriate courier for the job:
         *
         *  Bobby works 9am to 1pm, will deliver up to 5 miles and has a refrigerated box on his bike. He charges $1.75 per mile
         *  Martin works 9am-5pm, will deliver up to 3 miles with no refrigerated box available. He charges $1.50 per mile
         *  Geoff works 10am – 4pm, will deliver up to 4 miles and has a refrigerated box on his bike.  He charges $2.00 per mile.
         *
         *
         *  Sweet Treats needs to select the cheapest courier based on:
         *
         *  Working hours of the courier
         *  The distance between the store and the customers location
         *  Is refrigeration is required
         *
         *
         *  Create an application to help Sweet Treats select the best courier. Inputs to the application are: 
         *
         *  time of day the order is ready to be shipped
         *  the distance of the required delivery 
         *  an indicator as to whether refrigeration is required
         * 
         * ASSUMPTIONS:
         * 1. We will allow time to be entered for any time of the day, even times when there are no transporters. If a time is enter for which we don't have a transporter, the program will report this after we attempt to find a transporter.
         * 2. We will not allow input of a distance less than 1
         * 3. The courier/transporter is able to process a delivery as long as the order sent within the time range that they work. So If their time range is between 9am-5pm it is assumed that if they receive an order at 5pm they can still deliver it.
         */
        static void Main(string[] args)
        {
            // load up app settings file and create a controller for a command line
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);

            Console.WriteLine("Hello World! This is SweetTreats");
            Console.WriteLine("Enter input or press CTRL-C to exit");
            Console.WriteLine();

            // loop until user types CTRL-C
            while (true)
            {

                // Collect input from the user
                BestTransporterView btv = new BestTransporterView();
                TransporterViewInput userInput = btv.GetInput();

                // Validate the user's input
                Tuple<TransporterQueryInput, string> tup = btv.ValidateAll(userInput);
                if (tup.Item2.Length == 0) //check for errors returned in the string of the Tuple
                {
                    // Take the data that was converted into a binary from from the user input and find the best transporter
                    BestTransporter bestTrans = btc.GetBestTransporter(tup.Item1);
                    if (bestTrans.FoundTransporterToUse) {
                        //report the best transporter
                        Console.WriteLine("The best transporter to use is " + bestTrans.Name + " for a cost of $" + bestTrans.Cost);
                    } 
                    else
                    {
                        //show error with the results -- IE no transporter is available for the time selected.
                        Console.WriteLine(bestTrans.Error);
                    }
                }
                else
                {
                    //show the error for the input data -- IE invalid data entry for TIME, DISTANCE or REFRIDGE REQ.
                    Console.WriteLine(tup.Item2);
                }
                Console.WriteLine();
            }

        }
    }
}
