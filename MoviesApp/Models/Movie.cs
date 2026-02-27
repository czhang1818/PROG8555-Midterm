using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoviesApp.Models
{
    // Student Name: Chunxi Zhang
    // Student ID: 8971818
    public class Movie
    {
        //Add Model vlaidation attributes
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }  //property can't be null, and start with capital letter
        [Required]
        [Range(1900, 2025)]
        [DisplayName("Release Year")]
        public int ReleaseYear { get; set; } // Show as Release Year in the view, and must be between 1900 and 2025
        [Required]
        public Genre Genre { get; set; } // Must be one of the following values: Action, Comedy, Drama, Horror, SciFi
        [Required]
        [DisplayName("Image URL")]
        public string ImgUrl { get; set; } // Show as Image URL in the view
    }
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        SciFi
    }
}