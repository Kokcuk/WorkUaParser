using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public Resume Resume { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public int Year { get; set; }
    }
}
