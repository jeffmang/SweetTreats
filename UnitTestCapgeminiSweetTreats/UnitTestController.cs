using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using CapgeminiSweetTreats.Models;
using CapgeminiSweetTreats.Controllers;

namespace UnitTestCapgeminiSweetTreats
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestBestTransporterSucceed1()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 540; //9am
            tqi.Distance = 1;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Bobby", "Expected to find Bobby as transporter");
            Assert.IsTrue(bestTrans.Cost == 1.75, "Expected cost to be $1.75");
        }

        [TestMethod]
        public void TestBestTransporterSucceed2()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 960; //3pm
            tqi.Distance = 1;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Geoff", "Expected to find Geoff as transporter");
            Assert.IsTrue(bestTrans.Cost == 2.00, "Expected cost to be $2.00");
        }

        [TestMethod]
        public void TestBestTransporterSucceed3()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 960; //3pm
            tqi.Distance = 1;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Martin", "Expected to find Martin as transporter");
            Assert.IsTrue(bestTrans.Cost == 1.50, "Expected cost to be $1.50");
        }

        [TestMethod]
        public void TestBestTransporterSucceed4()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 780; //1pm
            tqi.Distance = 3;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Bobby", "Expected to find Bobby as transporter");
            Assert.IsTrue(bestTrans.Cost == 5.25, "Expected cost to be $5.25");
        }

        [TestMethod]
        public void TestBestTransporterSucceed5()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 781; //1:01pm
            tqi.Distance = 3;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Geoff", "Expected to find Geoff as transporter");
            Assert.IsTrue(bestTrans.Cost == 6.00, "Expected cost to be $6.00");
        }

        [TestMethod]
        public void TestBestTransporterSucceed6()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 780; //1pm
            tqi.Distance = 3;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Martin", "Expected to find Martin as transporter");
            Assert.IsTrue(bestTrans.Cost == 4.50, "Expected cost to be $4.50");
        }

        [TestMethod]
        public void TestBestTransporterSucceed7()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 781; //1:01pm
            tqi.Distance = 3;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Martin", "Expected to find Martin as transporter");
            Assert.IsTrue(bestTrans.Cost == 4.50, "Expected cost to be $4.50");
        }

        [TestMethod]
        public void TestBestTransporterSucceed8()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 960; //4pm
            tqi.Distance = 5;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(bestTrans.FoundTransporterToUse, "Expected to find transporter");
            Assert.IsTrue(bestTrans.Name == "Geoff", "Expected to find Geoffn as transporter");
            Assert.IsTrue(bestTrans.Cost == 10.00, "Expected cost to be $10.00");
        }

        [TestMethod]
        public void TestBestTransporterFail1()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 60; //1am
            tqi.Distance = 1;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(! bestTrans.FoundTransporterToUse, "Expected not to find transporter");
        }

        [TestMethod]
        public void TestBestTransporterFail2()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 539; //8:59am
            tqi.Distance = 1;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(!bestTrans.FoundTransporterToUse, "Expected not to find transporter");
        }

        [TestMethod]
        public void TestBestTransporterFail3()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 1021; //5:01pm
            tqi.Distance = 1;
            tqi.RefrigerationRequired = false;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(!bestTrans.FoundTransporterToUse, "Expected not to find transporter");
        }

        [TestMethod]
        public void TestBestTransporterFail4()
        {
            TransporterQueryInput tqi = new TransporterQueryInput();
            tqi.Time = 1019; //4:59pm
            tqi.Distance = 1;
            tqi.RefrigerationRequired = true;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            BestTransporterController btc = new BestTransporterController(config);
            BestTransporter bestTrans = btc.GetBestTransporter(tqi);
            Assert.IsTrue(!bestTrans.FoundTransporterToUse, "Expected not to find transporter");
        }
    }
}
