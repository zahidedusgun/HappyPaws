using HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adopter.GetByIdAdopter
{
    public class GetByIdAdopterQueryHandler : IRequestHandler<GetByIdAdopterQueryRequest, GetByIdAdopterQueryResponse>
    {
        public async Task<GetByIdAdopterQueryResponse> Handle(GetByIdAdopterQueryRequest request, CancellationToken cancellationToken)
        {
            var adopter = ApplicationDbContext.AdopterList.FirstOrDefault(x => x.Id == request.AdopterId);
            return new GetByIdAdopterQueryResponse
            {
                FirstName = adopter.FirstName,
                LastName = adopter.LastName,
                Email = adopter.Email,
                PhoneNumber = adopter.PhoneNumber

            };
        }
    }
}
