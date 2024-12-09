using System.ComponentModel.DataAnnotations;

namespace Bookstore.ViewModel
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]

        public string RoleName { get; set; } = string.Empty;
    }
}
