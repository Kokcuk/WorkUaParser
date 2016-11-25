using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Enums
{
    public enum Sex
    {
        [Description("Мужской")]
        Male = 0,

        [Description("Женский")]
        Famale = 1,

        [Description("Не важно")]
        NoDefined = 2
    }
}
