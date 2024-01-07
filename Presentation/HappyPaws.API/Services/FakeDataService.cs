
using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Enums;
using HappyPaws.Persistence.Contexts;

namespace HappyPaws.API.Services
{
    public class FakeDataService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IBogusService<Pet> _bogusService;

        public FakeDataService(ApplicationDbContext applicationDbContext, IBogusService<Pet> bogusService)
        {
            _applicationDbContext = applicationDbContext;
            _bogusService = bogusService;
        }

        public async Task<int> GeneratePetDataAsync(CancellationToken cancellationToken)
        {
            Guid shelterId = Guid.Parse("a37c0420-1651-4762-9a49-b83bd40c39f8");

            //var fakePetRules = new Faker<Pet>("en_US")
            //    .RuleFor(p => p.Id, new Guid())
            //    .RuleFor(p => p.Name, f => f.Name.FirstName())
            //    .RuleFor(p => p.Type, f => f.PickRandom("Dog", "Cat", "Bird", "Turtle", "Rabbit", "Fish", "Hamster"))
            //    .RuleFor(p => p.Breed, f => "Unknown")
            //    .RuleFor(p => p.Age, f => Convert.ToInt16(f.Random.Number(1, 15)))
            //    .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
            //    .RuleFor(p => p.AdoptionStatus, f => f.PickRandom<AdoptionStatus>())
            //    .RuleFor(p => p.CreatedDate, DateTime.UtcNow)
            //    .RuleFor(p => p.CreatedByUserId, "TestUser")
            //    .RuleFor(p => p.IsDeleted, false)
            //    .RuleFor(p => p.AdopterId, shelterId);



            var pets = _bogusService.GenerateFakeData(1000);

            foreach (var pet in pets)
            {
                //pet.Id = Guid.NewGuid();

                if (pet is Pet typedPet)
                {
                    typedPet.Id = Guid.NewGuid();
                }
            }

            await _applicationDbContext.Pets.AddRangeAsync(pets, cancellationToken);

            var recordCount = await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return recordCount;
        }



    }
}