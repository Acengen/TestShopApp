using System.ComponentModel.DataAnnotations;

namespace ShoppifiyAPI.Dtos
{
    public class UserToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}