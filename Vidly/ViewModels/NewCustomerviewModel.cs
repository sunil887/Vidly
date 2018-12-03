using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerviewModel
    {
        public IEnumerable<MembershipType> MembershipType{ get; set;}
        public Customer customer { get; set; }
    }
}