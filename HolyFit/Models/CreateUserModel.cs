using System.ComponentModel.DataAnnotations;

namespace HolyFit.Models
{
    public class CreateUserModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string ObjectIdentifier { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string DisplayName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(75)]
        public string EmailAddress { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string Goals { get; set; }   //I would make these hard coded and have a drop down for choices
        [Required]
        public int DaysToWorkOut { get; set; }
    }
}
