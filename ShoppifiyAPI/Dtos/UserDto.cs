using System.ComponentModel.DataAnnotations;

namespace ShoppifiyAPI.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}