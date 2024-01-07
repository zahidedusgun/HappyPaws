using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetByIdAdoption
{
    public class GetByIdAdoptionQueryHandler : IRequestHandler<GetByIdAdoptionQueryRequest, GetByIdAdoptionQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdAdoptionQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetByIdAdoptionQueryResponse> Handle(GetByIdAdoptionQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Adoption? adoption = await _context.Adoptions.FirstOrDefaultAsync(adoption =>
                adoption.Id.ToString() == request.Id);

            if (adoption is not null)
            {
                return new GetByIdAdoptionQueryResponse
                {
                    AdoptionDate = adoption.AdoptionDate,
                    AdoptionNotes = adoption.AdoptionNotes,
                    AdoptionStatus = adoption.AdoptionStatus,
                    Pet = adoption.Pet,
                    PetId = adoption.PetId,
                    Adopter = adoption.Adopter,
                    AdopterId = adoption.AdopterId
                };
            }
            return new GetByIdAdoptionQueryResponse();

        }
    }
}