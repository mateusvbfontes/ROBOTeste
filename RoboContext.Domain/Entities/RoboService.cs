using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoboContext.Domain.Entities
{
    public class RoboService
    {
        // Instancia Singleton com Lazy initialization
        private static readonly Lazy<RoboService> instance = new Lazy<RoboService>(() => new RoboService());

        private RoboHeadService _head;
        private RoboArmsService _leftArm;
        private RoboArmsService _rightArm;

        public RoboHeadService Head => _head ??= new RoboHeadService();
        public RoboArmsService LeftArm => _leftArm ??= new RoboArmsService();
        public RoboArmsService RightArm => _rightArm ??= new RoboArmsService();

        // Construtor privado para uso do Singleton
        private RoboService()
        {
        }

        // Propriedade pública privada para acesso da instância do Singleton
        public static RoboService Instance => instance.Value;
       
    }
}
