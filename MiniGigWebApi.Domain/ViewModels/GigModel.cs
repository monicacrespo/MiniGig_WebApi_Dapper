namespace MiniGigWebApi.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Because it's a one-to-one relationship, the MusicGenre information is part of the GigModel. 
    /// In essence, that allows it to flatten the MusicGenre information into the GigModel.    
    /// In AutoMapper, if you prefix the names with the name of the entity type, in this case MusicGenre, so MusicGenreId and MusicGenreCategory,
    /// and not changing the map at all, it'll be able to find it and get the MusicGenre information.
    /// And this is one of the places where using modeling can be really useful because you can change this, 
    /// and you don't have to go find every place in your code because all of this mapping is localized.
    /// Now being able to just prefix it does give you some limitations, so to change these names, 
    /// e.g. instead of a MusicGenreCategory we wanted Category, nice short name, might be easier for people to understand.
    /// To get that to work, gig mapping profile's going to allow you to add through a fluent syntax. 
    /// When it maps Category (from GigModel), goes and gets it from the MusicGenre.Category. 
    /// And any time you have something that doesn't follow conventionally what AutoMapper wants to do,
    /// you need to add one of these for members to tell the map what to do. And so you're centralizing that logic here in the profile. 
    /// So there's a few ways you can do this. We'll actually be looking at another way of actually showing other related data. 
    /// But for data that really is part of this individual model, creating the model that represents the entire object, 
    /// including things that may be stored in the database as separate objects, means you have more control over what your users actually work with.   
    ///  CreateMap<Gig, GigModel>()
    ///     .ForMember(c => c.Category, opt => opt.MapFrom(m => m.MusicGenre.Category))
    /// </summary>
    public class GigModel
    {        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime GigDate { get; set; }

        public int MusicGenreId { get; set; }

        public string Category { get; set; }

        //public string MusicGenreCategory { get; set; }
    }
}