using EventManager.Common;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            ValidationConstants.CategoryNameMaxLength,
            MinimumLength = ValidationConstants.CategoryNameMinLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; }
            = new List<Event>();
    }
}
