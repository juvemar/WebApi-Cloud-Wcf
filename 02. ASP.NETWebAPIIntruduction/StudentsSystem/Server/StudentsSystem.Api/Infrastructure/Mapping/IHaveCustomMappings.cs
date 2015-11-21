namespace StudentsSystem.Api.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CrateMapping(IConfiguration config);
    }
}
