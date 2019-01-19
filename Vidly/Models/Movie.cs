using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public Byte GenreId { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }   
}