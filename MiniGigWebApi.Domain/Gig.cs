namespace MiniGigWebApi.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Gig : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Gig Date")]
        public DateTime GigDate { get; set; } = DateTime.MinValue;
       
        //public int MusicGenreId { get; set; }

        public MusicGenre MusicGenre { get; set; }
    }
}