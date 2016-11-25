using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeParser.Common.Enums;

namespace ResumeParser.Common.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string[] Specs { get; set; }
        public List<Workplace> WorkPlaces { get; set; }
        public string About { get; set; }
        public List<Education> Educations { get; set; }
        public Dictionary<string, string> Additional { get; set; }
        public Dictionary<string, string> Langs { get; set; }
        public Sex Sex { get; set; }
        public string City { get; set; }
        public BusinessTrip BusinessTrip { get; set; }
        public DateTime BirthDate { get; set; }
        public string Industry { get; set; }
        public string VkProfile { get; set; }
        public string Skills { get; set; }
        public string Subway { get; set; }
        public string Move { get; set; }
        public string SiteName { get; set; }
        public string SiteId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Courses { get; set; }
        public Employment Employment { get; set; } 
        public Place Place { get; set; }
        public Schedule Schedule { get; set; }
        public string Citizenship { get; set; }
        public DriverLicence DriverLicense { get; set; }    // A,B,C,D,E
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public int AccountId { get; set; }
        public int ClientId { get; set; }
        public string Skype { get; set; }
        public string GooglePlus { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Moikrug { get; set; }
        public string ImageUrl { get; set; }
        public List<ParseRecommendation> Recommendations { get; set; }
        public List<Course> ParseCourses { get; set; }
        public int Age { get; set; }
        public int EduLevel { get; set; }
        public string Letter { get; set; }
        public string AddWay { get; set; }
        public int SanBook { get; set; }
        public List<Comment> Comments { get; set; }
        public string HtmlCv { get; set; }
        public DateTime? SourceUpdate { get; set; }
        public int Childs { get; set; }
        public int MaritalStatus { get; set; }
        public string HrBaseMessage { get; set; }
    }
}
