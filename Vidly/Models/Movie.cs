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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public String Name { get; set; }
        public Genre Genre { get; set; }
        public Byte GenreId{ get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;


    }
}