using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeParser.Common;
using ResumeParser.Common.Enums;
using ResumeParser.WorkUa;

namespace ResumeParser.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void WorkUaParseTest()
        {
            var testUrl = "https://www.work.ua/resumes/2117738/";
            var parser = new WorkUaParser(new HttpHandler());
            var resume = parser.Parse(testUrl);

            //names
            Assert.AreEqual(resume.FirstName, "Пётр");
            Assert.AreEqual(resume.LastName, "Юрдакчи");
            Assert.AreEqual(resume.MiddleName, "Петрович");

            //update time
            Assert.AreEqual(resume.UpdateTime, new DateTime(2016,11, 22));

            //position and salary
            Assert.AreEqual(resume.Position, "Торговый представитель, супервайзер менеджер по продажам");
            Assert.AreEqual(resume.Salary, 10000);
            //schedule
            Assert.AreEqual(resume.Employment, Employment.Fulltime);
            Assert.AreEqual(resume.Place, Place.Remote);
            //birthdate
            Assert.AreEqual(resume.BirthDate, new DateTime(1977, 11, 28));
            //city
            Assert.AreEqual(resume.City, "Тарутино");
            //workplaces
            Assert.AreEqual(resume.WorkPlaces.Count, 8);
            //education
            Assert.AreEqual(resume.Educations.Count, 1);
            //additional
            Assert.AreEqual(resume.Additional.Count, 1);
        }

        [TestMethod]
        public void Tets2()
        {
            var testUrl = "https://www.work.ua/resumes/1287655/";
            var parser = new WorkUaParser(new HttpHandler());
            var resume = parser.Parse(testUrl);
        }
    }
}
