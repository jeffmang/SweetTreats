using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapgeminiSweetTreats.Views;
using System;
using CapgeminiSweetTreats.Models;

namespace UnitTestCapgeminiSweetTreats
{
    [TestClass]
    public class UnitTestView
    {
        [TestMethod]
        public void TestReadTransportersTime() 
        { 
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("09:00");
            Assert.IsTrue(tupTime.Item1 == 540, "Time entered should be 9*60 = 540 mins = 9am");
            Assert.IsTrue(tupTime.Item2.Length == 0, "should be no error with zero length error msg");  
        }

        [TestMethod]
        public void TestReadTransportersTime2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("09:12");
            Assert.IsTrue(tupTime.Item1 == 552, "Time entered should be 9*60 + 12 = 552 mins = 9:12am");
            Assert.IsTrue(tupTime.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersTime3()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("00:00");
            Assert.IsTrue(tupTime.Item1 == 0, "Time entered should be 12 midnight or the start of a new day");
            Assert.IsTrue(tupTime.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersTime4()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("23:59");
            Assert.IsTrue(tupTime.Item1 == 1439, "Time entered should be 23*60 + 59 = 1439 mins = 23:59 or 11:59pm");
            Assert.IsTrue(tupTime.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersTimeWithNoLeadingZero()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("9:00");
            Assert.IsTrue(tupTime.Item1 == 540, "Time entered should be 9*60 = 540 mins = 9am");
            Assert.IsTrue(tupTime.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersTimeInvalid()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("35:00");
            Assert.IsTrue(tupTime.Item1 == -1, "Time entered is invalid");
            Assert.IsTrue(tupTime.Item2.Length > 0, "should be error msg");
        }

        [TestMethod]
        public void TestReadTransportersTimeInvalid2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupTime = btr.ValidateTime("15:60");
            Assert.IsTrue(tupTime.Item1 == -1, "Time entered is invalid");
            Assert.IsTrue(tupTime.Item2.Length > 0, "should be error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistance()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("19");
            Assert.IsTrue(tupDist.Item1 == 19, "Distance should be 19 miles");
            Assert.IsTrue(tupDist.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistance2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("03");
            Assert.IsTrue(tupDist.Item1 == 3, "Distance should be 3 miles");
            Assert.IsTrue(tupDist.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistance3()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("6");
            Assert.IsTrue(tupDist.Item1 == 6, "Distance should be 6 miles");
            Assert.IsTrue(tupDist.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistanceInvalid()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("a");
            Assert.IsTrue(tupDist.Item1 == -1, "Distance should be -1 miles");
            Assert.IsTrue(tupDist.Item2.Length > 0, "should be an error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistanceInvalid2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("");
            Assert.IsTrue(tupDist.Item1 == -1, "Distance should be -1 miles");
            Assert.IsTrue(tupDist.Item2.Length > 0, "should be an error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistanceInvalid3()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("3z");
            Assert.IsTrue(tupDist.Item1 == -1, "Distance should be -1 miles");
            Assert.IsTrue(tupDist.Item2.Length > 0, "should be an error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistanceNegativeTest()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("-3");
            Assert.IsTrue(tupDist.Item1 == -1, "Distance should be -1 miles");
            Assert.IsTrue(tupDist.Item2.Length > 0, "should be an error msg");
        }

        [TestMethod]
        public void TestReadTransportersDistanceZeroTest()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<int, string> tupDist = btr.ValidateDistance("-3");
            Assert.IsTrue(tupDist.Item1 == -1, "Distance should be -1 miles");
            Assert.IsTrue(tupDist.Item2.Length > 0, "should be an error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridge()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("Y");
            Assert.IsTrue(tupRef.Item1 == true, "Refridge Required should be true");
            Assert.IsTrue(tupRef.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridge2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("N");
            Assert.IsTrue(tupRef.Item1 == false, "Refridge Required should be false");
            Assert.IsTrue(tupRef.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridge3()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("y");
            Assert.IsTrue(tupRef.Item1 == true, "Refridge Required should be true");
            Assert.IsTrue(tupRef.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridge4()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("n");
            Assert.IsTrue(tupRef.Item1 == false, "Refridge Required should be false");
            Assert.IsTrue(tupRef.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridgeInvalid()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("asdfasfd");
            Assert.IsTrue(tupRef.Item1 == false, "Refridge Required should be false");
            Assert.IsTrue(tupRef.Item2.Length > 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersRefridgeInvalid2()
        {
            BestTransporterView btr = new BestTransporterView();
            Tuple<bool, string> tupRef = btr.ValidateRefridgerationRequired("");
            Assert.IsTrue(tupRef.Item1 == false, "Refridge Required should be false");
            Assert.IsTrue(tupRef.Item2.Length > 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersAll()
        {
            BestTransporterView btr = new BestTransporterView();
            TransporterViewInput tqi = new TransporterViewInput();
            tqi.Time = "14:01";
            tqi.Distance = "5";
            tqi.RefrigerationRequired = "Y";
            Tuple<TransporterQueryInput, string> tup = btr.ValidateAll(tqi);
            Assert.IsTrue(tup.Item1.Time == 841, "Time should be 841 or 2:01pm");
            Assert.IsTrue(tup.Item1.Distance == 5, "Dist should be 5");
            Assert.IsTrue(tup.Item1.RefrigerationRequired == true, "Refridge should be true");
            Assert.IsTrue(tup.Item2.Length == 0, "should be no error with zero length error msg");
        }

        [TestMethod]
        public void TestReadTransportersAllInvalid()
        {
            BestTransporterView btr = new BestTransporterView();
            TransporterViewInput tqi = new TransporterViewInput();
            tqi.Time = "25:01";
            tqi.Distance = "5";
            tqi.RefrigerationRequired = "Y";
            Tuple<TransporterQueryInput, string> tup = btr.ValidateAll(tqi);
            Assert.IsTrue(tup.Item1.Time == -1, "Time should be invalid");
            Assert.IsTrue(tup.Item1.Distance == 5, "Dist should be 5");
            Assert.IsTrue(tup.Item1.RefrigerationRequired == true, "Refridge should be true");
            Assert.IsTrue(tup.Item2.Length > 0, "should be an invliad msg");
        }

    }
}
