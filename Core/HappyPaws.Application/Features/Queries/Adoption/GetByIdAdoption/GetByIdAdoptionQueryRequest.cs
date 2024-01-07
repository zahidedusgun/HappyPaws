using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetByIdAdoption
{
    public class GetByIdAdoptionQueryRequest : IRequest<GetByIdAdoptionQueryResponse>
    {
        public string Id { get; set; }
    }
}