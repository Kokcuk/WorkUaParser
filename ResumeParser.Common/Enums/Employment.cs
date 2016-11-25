using System.ComponentModel;

namespace ResumeParser.Common.Enums
{
    public enum Employment
    {
        [Description("Полная")]
        Fulltime = 0,

        [Description("Частичная")]
        Parttime = 1,

        [Description("Проектная")]
        Project = 2,

        [Description("Стажировка")]
        Trainee = 3,

        [Description("Волонтерство")]
        Volunteer = 4,

        [Description("Не важно")]
        NotDefined = 5
    }
}