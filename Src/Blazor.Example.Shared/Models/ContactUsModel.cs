using System.ComponentModel.DataAnnotations;

namespace Blazor.Example.Shared.Models
{
    public class ContactUsModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Length is too short!")]
        public string Name { get; set; }

        public string Comments { get; set; }
    }
}
