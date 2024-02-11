namespace AutoMapperResearch.Models
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public required string PersonFullName { get; set; }
        public required int Salary { get; set; }
        public DateTime PersonDateOfBirth { get; set; }
        public List<PersonEvent> PersonEvents { get; set; } = [];
        public PersonEmploymentStatus EmploymentStatus { get; set; }

        public override string ToString()
            => $"PersonId: {PersonId}" +
               $", PersonFullName : {PersonFullName}" +
               $", Salary : {Salary}" +
               $", PersonDateOfBirth : {PersonDateOfBirth:yyyy-mm-dd}" +
               $", Tags : {string.Join(", ", PersonEvents.SelectMany(e => e.Name))}" +
               $", EmploymentStatus : {EmploymentStatus}";
    }

    public enum PersonEmploymentStatus
    {
        Employed = 0,
        Unemployed = 1,
        Retired = 2,
        Student = 3
    }
}