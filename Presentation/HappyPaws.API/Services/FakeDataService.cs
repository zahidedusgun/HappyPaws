
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


            var pets = _bogusService.GenerateFakeData(1000);

            foreach (var pet in pets)
            {
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