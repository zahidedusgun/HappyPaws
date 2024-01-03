using HappyPaws.Application.Features.Queries.Pet.GetAllPet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetAllPet
{
    public class GetAllPetQueryHandler : IRequestHandler<GetAllPetQueryRequest, List<GetAllPetQueryResponse>>
    {
        public async Task<List<GetAllPetQueryResponse>> Handle(GetAllPetQueryRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.PetList.Select(pet => new GetAllPetQueryResponse
            {
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Gender = pet.Gender,
                CreatedDate = pet.CreatedDate,

            }).ToList();
        }
    }
}
