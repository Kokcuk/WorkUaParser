using System.ComponentModel;

namespace ResumeParser.Common.Enums
{
    public enum Place
    {
        [Description("У работодателя")]
        Office = 0,

        [Description("Удаленно")]
        Remote = 1,

        [Description("Не важно")]
        NotDefined = 2
    }
}