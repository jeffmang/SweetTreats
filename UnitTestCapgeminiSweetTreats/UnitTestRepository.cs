using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapgeminiSweetTreats.Repository;

namespace UnitTestCapgeminiSweetTreats
{
    [TestClass]
    public class UnitTestRepository
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestReadTransporters()
        {
            string filename = @".\\Data\\test_transporter.json";
            TransporterRepository tr = new TransporterRepository(filename);
            var transporters = tr.GetTransporters();
            bool goodCount = transporters.Count == 3;
            Assert.IsTrue(goodCount);
            Assert.IsTrue(transporters[0].Name == "Bobby");
        }
    }
}
