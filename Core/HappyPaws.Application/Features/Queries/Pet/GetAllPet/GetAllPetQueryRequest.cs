using HappyPaws.Application.Features.Queries.Pet.GetAllPet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetAllPet
{
    public class GetAllPetQueryRequest : IRequest<List<GetAllPetQueryResponse>>
    {

    }
}
