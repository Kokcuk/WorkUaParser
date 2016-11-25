using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeParser.Common.Helpers;

namespace ResumeParser.Tests
{
    [TestClass]
    public class DatesExtractorTests
    {
        [TestMethod]
        public void TestDates()
        {
            var datesExtractor = new DateExtractor();
            var result = datesExtractor.ExtractDates("jhgjhg 05.2015 da");
            Assert.AreEqual(result.Count, 1);
        }
    }
}
