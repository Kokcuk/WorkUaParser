using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ResumeParser.Common;
using ResumeParser.Common.Entities;
using ResumeParser.Common.Enums;
using ResumeParser.Common.Helpers;

namespace ResumeParser.WorkUa
{
    public class WorkUaParser : ParserBase
    {
        private readonly DateExtractor dateExtractor;

        public WorkUaParser(IHttpHandler httpHandler) : base(httpHandler)
        {
            this.dateExtractor = new DateExtractor();
        }

        public override Resume Parse(string url)
        {
            var resume = new Resume();

            var content = DownloadString(url);
            var document = new HtmlDocument();
            document.LoadHtml(content);

            ParseName(document, resume);
            ParseResumeUpdateTime(document, resume);
            ParsePosition(document, resume);
            ParseSchedule(document, resume);
            ParseBirthDate(document, resume);
            ParseCity(document, resume);
            ParseWorkPlaces(document, resume);
            ParseEducation(document, resume);
            ParseAdditional(document, resume);

            return resume;
        }
        
        private void ParseName(HtmlDocument document, Resume resume)
        {
            var nameNode = document.DocumentNode.SelectSingleNode(".//*[@class='cut-top']");
            var nodeContent = nameNode.InnerText;
            var parts = nodeContent.Split(' ');
            if(parts.Length < 2) return;
            
            resume.LastName = parts[0];
            resume.FirstName = parts[1];
            if (parts.Length == 3) //middle name presented
                resume.MiddleName = parts[2];
            
        }

        private void ParseResumeUpdateTime(HtmlDocument document, Resume resume)
        {
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='text-muted']");
            var nodeContent = node.InnerText;
            var dates = this.dateExtractor.ExtractDates(nodeContent);
            if (dates.Any())
                resume.UpdateTime = dates.First().Item2;
        }

        private void ParsePosition(HtmlDocument document, Resume resume)
        {
            var positionNode = document.DocumentNode.SelectSingleNode(".//*[@class='col-sm-8']/h2/text()");
            var positionNodeContent = positionNode.InnerText;
            resume.Position = positionNodeContent.Trim();
            if (resume.Position.Last() == ',')
                resume.Position = resume.Position.RemoveLastSymbol();

            var salaryNode =
                document.DocumentNode.SelectSingleNode(".//*[@class='col-sm-8']/h2/*[@class='text-muted nowrap']");
            var salaryNodeContent = salaryNode.InnerText;
            var salaryMatch = Regex.Match(salaryNodeContent, "[0-9 ]+").Value;
            if (!string.IsNullOrEmpty(salaryMatch))
                resume.Salary = int.Parse(salaryMatch.Replace(" ",""));
        }

        private void ParseSchedule(HtmlDocument document, Resume resume)
        {
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='col-sm-8']/p[@class='text-muted']");
            var nodeContent = node.InnerText;
            var parts = nodeContent.Split(',');
            if (parts.Length > 0)
                resume.Employment = EmploymentExtractor(parts[0]);
            if (parts.Length > 1)
                resume.Place = PlaceExtractor(parts[1]);
        }

        private void ParseBirthDate(HtmlDocument document, Resume resume)
        {
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='dl-horizontal']/dd/text()");
            var nodeContent = node.InnerText;
            var dates = this.dateExtractor.ExtractDates(nodeContent);
            if (dates.Any())
                resume.BirthDate = dates.First().Item2;
        }

        private void ParseCity(HtmlDocument document, Resume resume)
        {
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='dl-horizontal']/dd[2]/text()");
            var nodeContent = node.InnerText;
            resume.City = nodeContent.Trim();
        }

        private void ParseWorkPlaces(HtmlDocument document, Resume resume)
        {
            var workPlaces = new List<Workplace>();
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='cut-top' and text()='Опыт работы']");
            while (true)
            {
                var workplace = new Workplace();
                node = node.SelectSingleNode("./following-sibling::h3");
                if(node == null) break;
                var datesNode = node.SelectSingleNode("./following-sibling::p");
                var descriptionNode = datesNode.SelectSingleNode("./following-sibling::p");
                workplace.Position = node.InnerText;
                var dates = this.dateExtractor.ExtractDates(datesNode.InnerText);
                if (dates.Count == 2)
                {
                    workplace.FromMonth = dates[0].Item2.Month;
                    workplace.FromYear = dates[0].Item2.Year;
                    workplace.ToMonth = dates[1].Item2.Month;
                    workplace.ToYear = dates[1].Item2.Year;
                }
                var datesHtml = datesNode.InnerHtml;
                var datesParts = datesHtml.Split(new string[] { "<br>" }, StringSplitOptions.None);
                if (datesParts.Length > 1)
                    workplace.Company = datesParts[1].RemoveTags().Trim().ReplaceHtmlQuotes();
                workplace.Description = descriptionNode.InnerText;

                workPlaces.Add(workplace);
            }
            resume.WorkPlaces = workPlaces;
        }

        private void ParseEducation(HtmlDocument document, Resume resume)
        {
            var educations = new List<Education>();
            var node = document.DocumentNode.SelectSingleNode(".//*[@class='cut-top' and text()='Образование']");
            while (true)
            {
                var education = new Education();
                node = node.SelectSingleNode("./following-sibling::h3");
                if (node == null) break;
                var descritionMini = node.SelectSingleNode("./following-sibling::p");
                var descriptionNode = descritionMini.SelectSingleNode("./following-sibling::p");
                education.University = node.InnerText;
                education.Faculty = descritionMini.InnerText;
                var dates = this.dateExtractor.ExtractDates(descriptionNode.InnerText);
                if (dates.Count == 2)
                    education.GraduateYear = dates.Last().Item2.Year;

                educations.Add(education);


            }
            resume.Educations = educations;
        }

        private void ParseAdditional(HtmlDocument document, Resume resume)
        {
            var additionals = new Dictionary<string, string>();
            var headingNode = document.DocumentNode.SelectSingleNode(".//*[@class='cut-top' and text()='Профессиональные и другие навыки']");
            var nextUlNode = headingNode.SelectSingleNode("./following-sibling::ul");
            var liNodes = nextUlNode.SelectNodes("./li");
            foreach (var liNode in liNodes)
            {
                var contentParts = liNode.InnerHtml.Split(new string[] { "<br>" }, StringSplitOptions.None);
                var key = contentParts[0].RemoveTags().Trim();
                var value = contentParts[1].RemoveTags().Trim();
                additionals.Add(key, value);
            }
            resume.Additional = additionals;
        }

        private Place PlaceExtractor(string place)
        {
            if (place.ToLowerInvariant().Contains("у работодателя"))
                return Place.Office;
            if (place.ToLowerInvariant().Contains("удаленн"))
                return Place.Remote;

            return Place.NotDefined;
        }

        private Employment EmploymentExtractor(string employment)
        {
            if(employment.ToLowerInvariant().Contains("полная"))
                return Employment.Fulltime;
            if (employment.ToLowerInvariant().Contains("частичная"))
                return Employment.Parttime;
            if (employment.ToLowerInvariant().Contains("проектная"))
                return Employment.Project;
            if (employment.ToLowerInvariant().Contains("стажировка"))
                return Employment.Trainee;
            if (employment.ToLowerInvariant().Contains("волонтерство"))
                return Employment.Volunteer;
            
            return Employment.NotDefined;
        }
    }
}