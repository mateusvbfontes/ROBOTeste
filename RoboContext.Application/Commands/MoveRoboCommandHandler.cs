using AutoMapper;
using MediatR;
using RoboContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboContext.Application.Commands
{
    /// <summary>
    /// CommandHandler para tratar as operações do ROBO
    /// </summary>
    public class MoveRoboCommandHandler : IRequestHandler<MoveRoboCommand, BaseResponse<RoboService>>
    {
        private readonly RoboService _roboService;
        private readonly IMapper _mapper;
        private List<string> _errors = new List<string>();

        public MoveRoboCommandHandler(RoboService roboService, IMapper mapper)
        {
            _roboService = roboService;
            _mapper = mapper;
        }

        /// <summary>
        /// Executa cada operação de update nos membros de forma independente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BaseResponse<RoboService>> Handle(MoveRoboCommand request, CancellationToken cancellationToken)
        {
            ExecuteWithExceptionHandling(() => UpdateHead(request));
            ExecuteWithExceptionHandling(() => UpdateLeftArm(request));
            ExecuteWithExceptionHandling(() => UpdateRightArm(request));

            return new BaseResponse<RoboService>(true, "Setted Robot", _errors, _roboService);
        }

        private void UpdateHead(MoveRoboCommand request)
        {
            // Realiza primeiro o update da inclinação
            _roboService.Head.Inclination = request.Robo.Head.Inclination;
            _roboService.Head.RotationAngle = request.Robo.Head.RotationAngle;
        }

        private void UpdateLeftArm(MoveRoboCommand request)
        {
            // Realiza primeiro o update do cotovelo
            _roboService.LeftArm.Elbow = request.Robo.LeftArm.Elbow;
            _roboService.LeftArm.WristRotationAngle = request.Robo.LeftArm.WristRotationAngle;
        }

        private void UpdateRightArm(MoveRoboCommand request)
        {
            // Realiza primeiro o update do cotovelo
            _roboService.RightArm.Elbow = request.Robo.RightArm.Elbow;
            _roboService.RightArm.WristRotationAngle = request.Robo.RightArm.WristRotationAngle;
        }

        /// <summary>
        /// Try catch isolado com callback para função
        /// </summary>
        /// <param name="action"></param>
        private void ExecuteWithExceptionHandling(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _errors.Add(ex.Message);
            }
        }
    }
}
