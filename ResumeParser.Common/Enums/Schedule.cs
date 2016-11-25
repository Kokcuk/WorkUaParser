using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeParser.Common.Enums
{
    public enum Schedule
    {
        [Description("Полный")]
        Fulltime = 0,

        [Description("Гибкий")]
        Parttime = 1,

        [Description("Вахтовый")]
        Shift = 2,

        [Description("Сменный")]
        Rotating = 3,

        [Description("Неполный")]
        NotFull = 4,

        [Description("Не важно")]
        NotDefined = 5
    }
}
