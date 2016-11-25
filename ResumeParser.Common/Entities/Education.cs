namespace ResumeParser.Common.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public int GraduateYear { get; set; }
        public string University { get; set; }
        public string Chair { get; set; }
        public string Faculty { get; set; }
        public bool IsAutocompleteUniversity { get; set; }
        public int Level { get; set; }
    }
}