using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Helper;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; } = 0;
       
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter {  get; set; }

        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        

        [Display(Name = "Date of Birth")]
        [Required]
        //[DataType(DataType.Date)]
        [MinimumAgeCustomer]
        public DateTime BirthDate { get; set; }
    }
}