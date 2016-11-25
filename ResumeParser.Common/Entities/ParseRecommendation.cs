using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Entities
{
    public class ParseRecommendation
    {
        public int Id { get; set; }
        public Resume Resume { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
    }
}
