using EventManager.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class Event : IValidatableObject
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
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    "End date must be later than start date.",
                    new[] { nameof(EndDate), nameof(StartDate) });
            }
        }
    }
}
