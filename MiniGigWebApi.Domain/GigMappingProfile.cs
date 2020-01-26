namespace MiniGigWebApi.Domain
{
    using AutoMapper;    

    public class GigMappingProfile : Profile
    {        
        public GigMappingProfile()
        {
            CreateMap<Gig, GigModel>()
              .ForMember(c => c.Category, opt => opt.MapFrom(m => m.MusicGenre.Category))
              //.ForMember(c => c.MusicGenreId, opt => opt.MapFrom(m => m.MusicGenre.Id))
              .ReverseMap();            
        }
    }
}