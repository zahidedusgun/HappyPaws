using HappyPaws.Application.Features.Queries.Pet.GetByIdPet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetByIdPet
{
    public class GetByIdHealthRecordQueryHandler : IRequestHandler<GetByIdPetQueryRequest, GetByIdPetQueryResponse>
    {
        public async Task<GetByIdPetQueryResponse> Handle(GetByIdPetQueryRequest request, CancellationToken cancellationToken)
        {
            var pet = ApplicationDbContext.PetList.FirstOrDefault(pet =>
                pet.Id == request.Id);
            return new GetByIdPetQueryResponse
            {
                Name = pet.Name,
                Type = pet.Type,
                Breed = pet.Breed,
                Age = pet.Age,
                Gender = pet.Gender,
                CreatedDate = pet.CreatedDate,
            };
        }
    }
}
