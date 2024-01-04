using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetAllAdoption
{
    public class GetAllAdoptionQueryHandler : IRequestHandler<GetAllAdoptionQueryRequest, List<GetAllAdoptionQueryResponse>>
    {
        public async Task<List<GetAllAdoptionQueryResponse>> Handle(GetAllAdoptionQueryRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.AdoptionList.Select(adoption => new GetAllAdoptionQueryResponse
            {
                AdoptionDate = adoption.AdoptionDate,
                AdoptionNotes = adoption.AdoptionNotes,
                AdoptionStatus = adoption.AdoptionStatus,

            }).ToList();
        }
    }
}
