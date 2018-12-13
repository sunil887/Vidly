using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        [Required]
        public int Id { get; set; }
        public String Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
       
        public DateTime? BirthdayDate { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}