namespace EventManager.Common
{
    public static class ValidationConstants
    {
        // Event
        public const int EventTitleMinLength = 5;
        public const int EventTitleMaxLength = 100;

        public const int EventDescriptionMinLength = 20;
        public const int EventDescriptionMaxLength = 1000;

        public const int MaxParticipantsMin = 1;
        public const int MaxParticipantsMax = 500;

        // Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;

        // Registration
        public const int ParticipantNameMinLength = 2;
        public const int ParticipantNameMaxLength = 60;
    }
}
