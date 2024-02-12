using System;
using AutoMapper;
using AutoMapperResearch.Mappers;
using AutoMapperResearch.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AutoMapperResearch.Benchmarks
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class MapperBenchmark
    {
        [Params(1_000, 10_000)]
        public int PersonListSize;

        [Params(10_000, 100_000, 1_0000_000)]
        public int EventListSize;

        private readonly IList<Person> personsToMap = [];

        private Mapper personAutoMapper;
        private PersonMapperley personMapperley;

        [GlobalSetup]
        public void Setup()
        {
            var personEvents = new List<PersonEvent>();

            for (var i = 0; i < EventListSize; i++)
            {
                personEvents.Add(
                    new PersonEvent
                    {
                        Id = i,
                        Name = "Event Name" + i,
                        Date = new DateTime(1986, 11, 23)
                    });
            }

            for (var i = 0; i < PersonListSize; i++)
            {
                var person = new Person
                {
                    Id = i,
                    Name = "Name " + i,
                    DateOfBirth = new DateTime(1986, 11, 23),
                    EmploymentStatus = EmploymentStatus.Employed,
                    Salary = 10000 + i,
                    PersonEvents = personEvents
                };

                personsToMap.Add(person);
            }

            //Configure mappers
            var autoMapperConfig = PersonAutoMapper.CreateAutoMapper();
            autoMapperConfig.AssertConfigurationIsValid();
            personAutoMapper = new Mapper(autoMapperConfig);
            personMapperley = new PersonMapperley();
        }


        [Benchmark]
        public void Benchmark_Mapperley()
        {

            foreach (var person in personsToMap)
            {
                var mapResult = personMapperley.PersonToPersonDto(person);
                Console.WriteLine($"{personsToMap.IndexOf(person)} mapped using mapperley!");
            }
        }

        [Benchmark]
        public void Benchmark_AutoMapper()
        {
            foreach (var person in personsToMap)
            {
                var mapResult = personAutoMapper.Map<Person>(person);
                Console.WriteLine($"{personsToMap.IndexOf(person)} mapped using AutoMapper!");
            }
        }


    }
}