using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class DefaultUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [PersonalData]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [PersonalData]
        [Required]
        public string Address { get; set; } = string.Empty;

        [PersonalData]
        [Required]
        public string ZipCode { get; set; } = string.Empty;

        [PersonalData]
        [Required]
        public string City { get; set; } = string.Empty;

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}