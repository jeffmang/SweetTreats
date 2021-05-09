using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using CapgeminiSweetTreats.Models;

namespace CapgeminiSweetTreats.Repository
{
    public class TransporterRepository
    {
        private readonly string _jsonTransportFilename;
        
       
        /*
         * Construction to be initilized with the JSON file.
         */
        public TransporterRepository(string jsonTransportFilename)
        {
            _jsonTransportFilename = jsonTransportFilename;
        }

        /*
         * This function gets all the transporters from JSON file and returns them in a list.
         */
        public List<Transporter> GetTransporters()
        {
            try
            {
                string fileText = System.IO.File.ReadAllText(_jsonTransportFilename);
                List<Transporter> transporters = JsonConvert.DeserializeObject<List<Transporter>>(fileText);
                return transporters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        
    }
}
