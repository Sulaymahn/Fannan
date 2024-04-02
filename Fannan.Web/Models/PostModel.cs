using System.ComponentModel.DataAnnotations;

namespace Fannan.Web.Models
{
    public class PostModel
    {
        [Required]
        public string Text { get; set; } = string.Empty;
        public IFormFile? Media { get; set; }
    }
}
