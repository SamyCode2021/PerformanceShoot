using AutoMapperResearch.Models;
using Riok.Mapperly.Abstractions;

namespace AutoMapperResearch
{
    [Mapper (EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public partial class PersonMapperley
    {
        [MapProperty(nameof(Person.EmploymentStatus), nameof(PersonDto.EmploymentStatus))]
        [MapProperty(nameof(Person.Id), nameof(PersonDto.PersonId))]
        [MapProperty(nameof(Person.Name), nameof(PersonDto.PersonFullName))]
        public partial PersonDto PersonToPersonDto(Person person);

    }
}