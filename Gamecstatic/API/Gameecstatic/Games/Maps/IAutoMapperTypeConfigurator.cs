using AutoMapper;

namespace Games.Maps
{
    public interface IAutoMapperTypeConfigurator
    {
        void Configure(IMapperConfigurationExpression configuration);
    }
}