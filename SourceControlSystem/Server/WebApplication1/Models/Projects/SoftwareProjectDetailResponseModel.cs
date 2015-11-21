namespace WebApplication1.Models.Projects
{
    using SourceControlSystem.Models;
    using System;
    using System.Linq;
    using Infrastructure.Mapping;
    using AutoMapper;

    public class SoftwareProjectDetailResponseModel : IMapFrom<SoftwareProject>, IHaveCustomMappings
    {
        //public static Expression<Func<SoftwareProject, SoftwareProjectDetailResponseModel>> FromModel
        //{
        //    get
        //    {
        //        return pr => new SoftwareProjectDetailResponseModel()
        //        {
        //            Id = pr.Id,
        //            Name = pr.Name,
        //            CreatedOn = pr.CreatedOn, 
        //            TotalUsers = pr.Users.Count()
        //        };
        //    }
        //}

        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TotalUsers { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<SoftwareProject, SoftwareProjectDetailResponseModel>()
                .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count()));
        }
    }
}