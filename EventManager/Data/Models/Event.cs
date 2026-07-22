using EventManager.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            ValidationConstants.EventTitleMaxLength,
            MinimumLength = ValidationConstants.EventTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(
            ValidationConstants.EventDescriptionMaxLength,
            MinimumLength = ValidationConstants.EventDescriptionMinLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(
            ValidationConstants.MaxParticipantsMin,
            ValidationConstants.MaxParticipantsMax)]
        public int MaxParticipants { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<Registration> Registrations { get; set; }
            = new List<Registration>();
    }
}
