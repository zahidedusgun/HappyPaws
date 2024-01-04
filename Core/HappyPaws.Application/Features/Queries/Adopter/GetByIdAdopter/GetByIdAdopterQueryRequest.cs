using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adopter.GetByIdAdopter
{
    public class GetByIdAdopterQueryRequest : IRequest<GetByIdAdopterQueryResponse>
    {
        public Guid AdopterId { get; set; }
    }
}
