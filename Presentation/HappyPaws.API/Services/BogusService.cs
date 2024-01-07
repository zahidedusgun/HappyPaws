using Bogus;
using Bogus.DataSets;
using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Enums;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HappyPaws.API.Services
{
    public class BogusService<T> : IBogusService<T> where T : class
    {
        private readonly Faker<T> _faker;

        public BogusService(Faker<T> faker)
        {
            _faker = faker;
            CreatePetRules();
        }

        public List<T> GenerateFakeData(int count)
        {
            return _faker.Generate(count);
        }
        private void CreatePetRules()
        {
            Guid shelterId = Guid.Parse("a37c0420-1651-4762-9a49-b83bd40c39f8");

            _faker.RuleFor(p => ((Pet)(object)p).Id, f => f.Random.Guid())
                    .RuleFor(p => ((Pet)(object)p).Name, f => f.Name.FirstName())
                    .RuleFor(p => ((Pet)(object)p).Type, f => f.PickRandom("Dog", "Cat", "Bird", "Turtle", "Rabbit", "Fish", "Hamster"))
                    .RuleFor(p => ((Pet)(object)p).Breed, "Unknown")
                    .RuleFor(p => ((Pet)(object)p).Age, f => (short)f.Random.Number(1, 15))
                    .RuleFor(p => ((Pet)(object)p).Gender, f => f.PickRandom<Gender>())
                    .RuleFor(p => ((Pet)(object)p).AdoptionStatus, f => f.PickRandom<AdoptionStatus>())
                    .RuleFor(p => ((Pet)(object)p).CreatedDate, DateTime.UtcNow)
                    .RuleFor(p => ((Pet)(object)p).CreatedByUserId, "TestUser")
                    .RuleFor(p => ((Pet)(object)p).IsDeleted, false)
                    .RuleFor(p => ((Pet)(object)p).AdopterId, shelterId);
        }
    }
}


