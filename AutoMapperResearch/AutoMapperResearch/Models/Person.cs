namespace AutoMapperResearch.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<PersonEvent> PersonEvents { get; set; } = [];
        public EmploymentStatus EmploymentStatus { get; set; }
    }

    public enum EmploymentStatus
    {
        Employed = 0,
        Unemployed = 1,
        Retired = 2,
        Student = 3
    }

    public class PersonEvent
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Date { get; set; }
    }
}