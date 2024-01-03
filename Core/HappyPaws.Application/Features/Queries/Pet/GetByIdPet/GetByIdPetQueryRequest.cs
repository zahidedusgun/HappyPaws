using HappyPaws.Application.Features.Queries.Pet.GetByIdPet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetByIdPet
{
    public class GetByIdPetQueryRequest : IRequest<GetByIdPetQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
