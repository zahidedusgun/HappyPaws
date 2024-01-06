using HappyPaws.Application.Features.Queries.Pet.GetByIdPet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetByIdPet
{
    public class GetByIdPetQueryHandler : IRequestHandler<GetByIdPetQueryRequest, GetByIdPetQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdPetQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetByIdPetQueryResponse> Handle(GetByIdPetQueryRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Pet? pet = await _context.Pets.FirstOrDefaultAsync(pet =>

                pet.Id.ToString() == request.Id);

            if (pet is not null)
            {
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
            return new GetByIdPetQueryResponse();


        }
    }
}