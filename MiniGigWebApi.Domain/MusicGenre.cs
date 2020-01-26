namespace MiniGigWebApi.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class which contains the music genre data
    /// </summary>
    public class MusicGenre : BaseEntity
    {
        [Display(Name = "Music Genre")]
        public string Category { get; set; }    
    }
}