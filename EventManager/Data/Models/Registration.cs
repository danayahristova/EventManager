using EventManager.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }

        public Event? Event { get; set; } = null!;

        [Required]
        [StringLength(
            ValidationConstants.ParticipantNameMaxLength,
            MinimumLength = ValidationConstants.ParticipantNameMinLength)]
        public string ParticipantName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
