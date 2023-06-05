using MediatR;
using RoboContext.Application.Commands;
using RoboContext.Domain.Entities;

namespace RoboContext.Application.Queries
{
    public class GetRoboStateQuery : IRequest<BaseResponse<RoboService>>
    {
    }
}
