using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Entities
{
    public class Workplace
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public int FromYear { get; set; }
        public int FromMonth { get; set; }
        public int ToYear { get; set; }
        public int ToMonth { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
