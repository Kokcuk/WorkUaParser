using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public Resume Resume { get; set; }
        public string Text { get; set; }
        public string Account { get; set; }
        public DateTime Date { get; set; }
    }
}
