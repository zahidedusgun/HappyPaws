using HappyPaws.Application.Features.Queries.Adoption.GetAllAdoption;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetAllAdoption
{
    public class GetAllAdoptionQueryRequest : IRequest<List<GetAllAdoptionQueryResponse>>
    {

    }
}
