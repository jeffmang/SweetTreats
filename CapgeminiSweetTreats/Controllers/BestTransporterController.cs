using CapgeminiSweetTreats.Models;
using CapgeminiSweetTreats.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiSweetTreats.Controllers
{
    public class BestTransporterController
    {
        IConfigurationRoot _config;

        /*
         * Constructor to save the config file with the appsettins.json file.
         */ 
        public BestTransporterController(IConfigurationRoot config)
        {
            _config = config;
        }

        /*
         *  Get the Best Transporter to use for the given input data.
         */
        public BestTransporter GetBestTransporter(TransporterQueryInput userData)
        {
            // Get the transporters from the repository - This data could be cached for better performance if we had thousands of transporters
            string transportersFilename = _config.GetSection("AppSettings")["TransportRepositoryFilename"];
            TransporterRepository repo = new TransporterRepository(transportersFilename);
            List<Transporter> transporters = repo.GetTransporters();

            // Find the Best Transporter and the cost to transport.
            double? cost = null;
            string transporterName = "";
            foreach(Transporter t in transporters)
            {
                // first see if you can use current transporter
                if (userData.Time >= t.StartTime && userData.Time <= t.EndTime)
                {
                    // check for refrigeration not needed (all transporters allowed) or if Refridge needed only use transporters with Refridge cablable transports
                    if (userData.RefrigerationRequired == false || userData.RefrigerationRequired == t.RefridgeratedBox)
                    {
                        // calc cost and see if this is the lowest cost transporter
                        double currCost = userData.Distance * t.CostPerMile;
                        if (cost == null || currCost < cost)
                        {
                            cost = currCost;
                            transporterName = t.Name;
                        }

                    }
                }
            }

            // check if we found a transporter
            BestTransporter bestTrans = new BestTransporter();
            if (cost == null || transporterName.Length == 0)
            {
                // no transporters available for this time.
                bestTrans.Error = "No Transporter is available";
                bestTrans.FoundTransporterToUse = false;
            }
            else {
                // Found a transporter to use
                bestTrans.Error = "";
                bestTrans.FoundTransporterToUse = true;
            }
            // return Name and Cost if data is available.
            bestTrans.Name = transporterName;
            bestTrans.Cost = cost;
            return bestTrans;
        }
    }
}
